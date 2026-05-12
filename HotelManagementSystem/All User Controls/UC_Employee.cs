using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.All_User_Controls
{
    public partial class UC_Employee : UserControl
    {
        Function fn = new Function();
        String query;
        Int64 employeeID;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaximiumID();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Name, Username, and Password are required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Int64 mobileNumber = 0;
            Int64.TryParse(txtMobile.Text, out mobileNumber);

            if (txtMobile.Text != "" && !Int64.TryParse(txtMobile.Text, out mobileNumber))
            {
                MessageBox.Show("Please enter a valid numeric mobile number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. The Parameterized Query
            string query = "INSERT INTO employee (ename, mobile, gender, emailid, username, pass) " +
                           "VALUES (@ename, @mobile, @gender, @emailid, @username, @pass)";

            // 2. Create the array of parameters mapping to your text boxes
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ename", txtName.Text),
                new SqlParameter("@mobile", mobileNumber == 0 ? (object)DBNull.Value : mobileNumber),
                new SqlParameter("@gender", txtGender.Text),
                new SqlParameter("@emailid", txtEmail.Text),
                new SqlParameter("@username", txtUser.Text),
                new SqlParameter("@pass", txtPassword.Text)
            };

            // 3. Send it to your new, upgraded setData method!
            fn.setData(query, "Employee added successfully!", parameters);

            // Clear fields
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUser.Clear();
            txtPassword.Clear();
        }

        private void tabEmployeeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployeeDetails.SelectedIndex == 1) getEmployeeDetails(guna2DataGridView1);
            else if (tabEmployeeDetails.SelectedIndex == 2) getEmployeeDetails(guna2DataGridView2);
            else if (tabEmployeeDetails.SelectedIndex == 3) getEmployeeDetails(guna2DataGridView3);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "delete from employee where eid =" + txtID.Text + "";
                    fn.setData(query, "Employee deleted successfully.");
                    tabEmployeeDetails_SelectedIndexChanged(this, null);
                    clearAll();
                }
            }
        }
        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
        //To get the next ID from the database then add one, for eg if The ID in the database is 4 it will add one to make it 5. Boom! Brand New ID!!!!!!
        public void getMaximiumID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }
        }
        //To clear all text and combo boxes after submission
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUser.Clear();
            txtPassword.Clear();
        }
        //This method contains the query to view all emoloyee details. It contains an argument of type Datagridview which is passed as the datagrid view name
        public void getEmployeeDetails(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersHeight = 50;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                employeeID = Int64.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMobile.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGender.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUser.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPassword.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtID.Text = employeeID.ToString();
            }
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                employeeID = Int64.Parse(guna2DataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtUpdateID.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUpdateName.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUpdateMobile.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUpdateGender.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUpdateEmail.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUpdateUser.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUpdatePassword.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateName.Text != "" && txtUpdateUser.Text != "" && txtUpdatePassword.Text != "")
            {
                string updateQuery = "UPDATE employee SET ename=@ename, mobile=@mobile, gender=@gender, emailid=@emailid, username=@username, pass=@pass WHERE eid=@eid";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ename", txtUpdateName.Text),
                    new SqlParameter("@mobile", string.IsNullOrEmpty(txtUpdateMobile.Text) ? (object)DBNull.Value : Int64.Parse(txtUpdateMobile.Text)),
                    new SqlParameter("@gender", txtUpdateGender.Text),
                    new SqlParameter("@emailid", txtUpdateEmail.Text),
                    new SqlParameter("@username", txtUpdateUser.Text),
                    new SqlParameter("@pass", txtUpdatePassword.Text),
                    new SqlParameter("@eid", employeeID)
                };

                fn.setData(updateQuery, "Employee updated successfully!", parameters);
                tabEmployeeDetails_SelectedIndexChanged(this, null);
                txtUpdateName.Clear();
                txtUpdateMobile.Clear();
                txtUpdateGender.SelectedIndex = -1;
                txtUpdateEmail.Clear();
                txtUpdateUser.Clear();
                txtUpdatePassword.Clear();
                txtUpdateID.Clear();
            }
            else
            {
                MessageBox.Show("Please complete all required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
