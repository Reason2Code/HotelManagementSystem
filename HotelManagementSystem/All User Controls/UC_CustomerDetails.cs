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
    public partial class UC_CustomerDetails : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Common part of the query to keep your code clean
            string baseQuery = "select customer.cid, customer.cName, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.addres, customer.checkin, customer.chekout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";

            if (txtSearchBy.SelectedIndex == 0) 
            {
                query = baseQuery;
                getRecords(query);
            }
            else if (txtSearchBy.SelectedIndex == 1) 
            {
                query = baseQuery + " where customer.chekout = 'No'";
                getRecords(query);
            }
            else if (txtSearchBy.SelectedIndex == 2) 
            {
                query = baseQuery + " where customer.chekout = 'YES'";
                getRecords(query);
            }
        }
        private void getRecords(String displayQuery) 
        {
            DataSet ds = fn.getData(displayQuery);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.ColumnHeadersVisible = true;
            guna2DataGridView1.ColumnHeadersHeight = 50;
        }
    }
}
