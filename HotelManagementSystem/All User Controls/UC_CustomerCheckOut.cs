using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.All_User_Controls
{
    public partial class UC_CustomerCheckOut : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_CustomerCheckOut()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
            // Fetches all customers who have not checked out yet
            string query = "SELECT c.cid, c.cName, c.mobile, c.nationality, c.gender, c.dob, c.idproof, c.addres, c.checkin, r.roomNo, r.roomType, r.bed, r.price " +
                           "FROM customer c INNER JOIN rooms r ON c.roomid = r.roomid " +
                           "WHERE c.chekout LIKE 'N%'";

            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.ColumnHeadersVisible = true;
            guna2DataGridView1.ColumnHeadersHeight = 50;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // WARNING: This uses string concatenation, which is vulnerable to SQL injection.
            // If your user types a single quote (') in txtCname.Text, the app will crash. 
            // To prevent this temporarily, you can replace single quotes in the input:
            string safeSearchText = txtCname.Text.Replace("'", "''");

            string query = "SELECT c.cid, c.cName, c.mobile, c.nationality, c.gender, c.dob, c.idproof, c.addres, c.checkin, r.roomNo, r.roomType, r.bed, r.price " +
                           "FROM customer c INNER JOIN rooms r ON c.roomid = r.roomid " +
                           "WHERE c.cName LIKE '" + safeSearchText + "%' AND c.chekout = 'No'";

            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Guard Clause: Ignore clicks on column or row headers
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // 2. Get the specific row that was clicked
            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

            // 3. Ensure the cell actually has data before trying to read it
            if (row.Cells[e.ColumnIndex].Value != null)
            {
                // Use int.TryParse for safety, just in case the ID column is ever empty/invalid
                if (int.TryParse(row.Cells[0].Value?.ToString(), out int parsedId))
                {
                    id = parsedId;
                }

                // Use the null-conditional operator (?.) to avoid crashes if a specific cell is null
                txtCname.Text = row.Cells[1].Value?.ToString();
                txtRoom.Text = row.Cells[9].Value?.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCname.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    String cDate = txtCheckOutDate.Text;

                    // 1. Update Customer status and date
                    // 2. Update Room status to NO (available)
                    query = "UPDATE customer SET chekout = 'YES' WHERE cid = " + id + "; " +
                        "UPDATE rooms SET booked = 'NO' WHERE roomNo = '" + txtRoom.Text + "'";

                    fn.setData(query, "Customer Checked Out Successfully.");

                    // Refresh the grid and clear inputs
                    UC_CustomerCheckOut_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtCname.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtCname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
