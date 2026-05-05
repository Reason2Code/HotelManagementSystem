using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Form1 : Form
    {
        private int escPressCount = 0;
        private DateTime firstEscPressTime;
        private readonly TimeSpan escTimeLimit = TimeSpan.FromSeconds(2);
        Function fn = new Function();
        String query;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // 2. Attach the KeyDown event
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed is the Escape key
            if (e.KeyCode == Keys.Escape)
            {
                DateTime now = DateTime.Now;

                // If it's the first press, OR if they took too long since the first press, reset the count
                if (escPressCount == 0 || (now - firstEscPressTime) > escTimeLimit)
                {
                    escPressCount = 1;
                    firstEscPressTime = now;
                }
                else
                {
                    // Otherwise, increment the count
                    escPressCount++;
                }

                // Trigger the fail-safe if they hit 3 presses within the time limit
                if (escPressCount >= 3)
                {
                    // Force close the application immediately
                    Application.Exit();
                }
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username,pass from employee where username = '" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }
    }
}
