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

namespace UMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text== "")
                lblInvalidUsername.Text = "Username cannot be empty";
            if(txtPassword.Text == "")
                lblInvalidPassword.Text = "Password cannot be empty";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var query = "SELECT * FROM Registration_Table WHERE username='"+ username +"' AND password='"+ password +"'";
            var result = DbHelper.GetQueryData(query);
            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }
            if(result.Data.Rows.Count > 0)
            {
                // Successful login
                MessageBox.Show("Login successful!");
                UserHelper.Username = username; // Store the username
                FinalDashBoard1 fd = new FinalDashBoard1();
                fd.Show(this);
                //this.Hide();
            }
            else
            {
                // Invalid credentials
                lblInvalidUsername.Text = "Invalid username or password";
                lblInvalidPassword.Text = "Invalid username or password";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Hide();
        }
    }
}



