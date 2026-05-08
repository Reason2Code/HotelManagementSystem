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
    public partial class UC_AddRoom : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
            DataGridView1.ColumnHeadersVisible = true;
            DataGridView1.ColumnHeadersHeight = 50;
            if (DataGridView1.Columns.Count > 0)
            {
                DataGridView1.Columns["roomid"].Visible = false;
                DataGridView1.Columns["roomNo"].HeaderText = "Room Number";
                DataGridView1.Columns["roomType"].HeaderText = "Room Type";
                DataGridView1.Columns["bed"].HeaderText = "Bed Type";
                DataGridView1.Columns["price"].HeaderText = "Price";
                DataGridView1.Columns["booked"].HeaderText = "Is Booked?";
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text !="" && txtPrice.Text !="")
            {
                String roomno = txtRoomNo.Text;
                String type = txtType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into rooms(roomNo, roomType, bed, price) values('"+roomno+"', '"+type+"', '"+bed+"', '"+price+"')";
                fn.setData(query, "Room Added");
                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("All Fields are mandatory", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNo.Text;
                String type = txtType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                // SQL Query to update room details based on Room Number
                query = "UPDATE rooms SET roomType = '" + type + "', bed = '" + bed + "', price = " + price + " WHERE roomNo = '" + roomno + "'";

                fn.setData(query, "Room Details Updated Successfully.");

                // Refresh the grid and clear fields
                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Please select a room and fill all fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete Room No: " + txtRoomNo.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    String roomno = txtRoomNo.Text;

                    // SQL Query to delete the room
                    query = "DELETE FROM rooms WHERE roomNo = '" + roomno + "'";

                    fn.setData(query, "Room Deleted.");

                    // Refresh the grid and clear fields
                    UC_AddRoom_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please enter or select a Room Number to delete.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomNo.Clear();
            txtType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
