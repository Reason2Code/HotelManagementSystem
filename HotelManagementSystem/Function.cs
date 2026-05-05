using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    class Function
    {
        // Connection to Database
        protected SqlConnection getConnection()
        {
            string currentPcName = Environment.MachineName;
            string connectionString = Properties.Settings.Default.ConnectionString;

            // changed on 28/04/26 to use connection string from the settings file 

            //string connectionString = $@"Data Source={currentPcName}\SQLEXPRESS;Initial Catalog=YOUR_DB_NAME;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            return new SqlConnection(connectionString);
        }

        // To get data from the database (Supports optional parameters)
        public DataSet getData(String query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = getConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        public void setData(String query, String message, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection con = getConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SqlDataReader getForCombo(String query, SqlParameter[] parameters = null)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr;
        }
    }
}