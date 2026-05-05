using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem.All_User_Controls
{
    public partial class UC_Registeration : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_Registeration()
        {
            InitializeComponent();
        }
        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close(); 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UC_Registeration_Load(object sender, EventArgs e)
        {

        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomno.Items.Clear();
            txtPrice.Clear();
            query = "select roomNo from rooms where bed = '" + txtbed.Text + "' and roomType = '" + txtRoom.Text + "' and booked = 'No'";
            setComboBox(query, txtRoomno);
        }

        private void txtbed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomno.Items.Clear();
            txtPrice.Clear();
        }

        int rid;
        private void txtRoomno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Safety Check: If the combobox is empty/cleared, do nothing and exit early.
            if (txtRoomno.SelectedIndex == -1 || string.IsNullOrEmpty(txtRoomno.Text))
            {
                txtPrice.Clear();
                rid = 0; // Reset the global room ID variable just in case
                return;
            }

            query = "select price, roomid from rooms where roomNo = '" + txtRoomno.Text + "'";
            DataSet ds = fn.getData(query);

            // 2. Safety Check: Ensure the database actually returned at least 1 row of data
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                // Fallback in case a room number exists in the dropdown but somehow got deleted from the database
                txtPrice.Clear();
                rid = 0;
            }
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (txtName.Text != "" && txtContact.Text != "" && txtNation.Text != "" &&
                txtGender.Text != "" && txtDob.Text != "" && txtId.Text != "" &&
                txtAddress.Text != "" && txtCheckIn.Text != "")
            {
                try
                {
                    // Gather data from textboxes
                    string name = txtName.Text;
                    Int64 mobile = Int64.Parse(txtContact.Text);
                    string nation = txtNation.Text;
                    string gender = txtGender.Text;
                    string dob = txtDob.Text;
                    string idproof = txtId.Text;
                    string address = txtAddress.Text;
                    string checkin = txtCheckIn.Text;

                    // THE QUERY: 
                    // 1. Adds customer (setting chekout to 'No')
                    // 2. Updates the room status to 'YES' (Booked)
                    // FIXED: Changed txtRoomNo to txtRoomno below
                    query = "insert into customer (cName, mobile, nationality, gender, dob, idproof, addres, checkin, roomid, chekout) " +
                            "values ('" + name + "', " + mobile + ", '" + nation + "', '" + gender + "', '" + dob + "', '" + idproof + "', '" + address + "', '" + checkin + "', " + rid + ", 'No'); " +
                            "update rooms set booked = 'YES' where roomNo = '" + txtRoomno.Text + "'";

                    // FIXED: Changed txtRoomNo to txtRoomno below
                    fn.setData(query, "Room No. " + txtRoomno.Text + " Allocated Successfully.");

                    // Clear the form for the next customer
                    clearAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Allocation Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all information before allocating.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNation.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtId.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtbed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomno.Items.Clear();
            txtPrice.Clear();
        }

        private void UC_Registeration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
