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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = System.Drawing.Color.Black;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtSetPassword.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("First Name and Last Name cannot be empty");
                return;
            }

            string email = txtEmail.Text;
            int number = Convert.ToInt32(txtNumber.Text);
            if (string.IsNullOrWhiteSpace(number.ToString()))
            {
                MessageBox.Show("Enter a valid 10 digit number");
                return;
            }
            string dept;
            if (cmbDepartment.SelectedItem != null)
            {
                dept = cmbDepartment.SelectedItem.ToString();
            }
            else
            {
                dept = "Not Selected";
            }
            string address = txtAddress.Text;
            string dob = dtpDOB.Text;
            string Gender = "";
            string Skill = "";
            if (cbTechnicalSkill.Checked)
            {
                Skill += cbTechnicalSkill.Text + " ";
            }
            if (cbDomainSkill.Checked)
            {
                Skill += string.IsNullOrWhiteSpace(Skill) ? cbDomainSkill.Text : ", " + cbDomainSkill.Text;
            }
            if (rdbMale.Checked)
                Gender = rdbMale.Text;
            if (rdbFemale.Checked)
                Gender = rdbFemale.Text;
            if (string.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("Select the Gender");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
                {
                MessageBox.Show("Username cannot be empty");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty");
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty");
                return;
            }
            if (string.IsNullOrWhiteSpace(number.ToString()))
            {
                MessageBox.Show("Enter a valid digit number");
                return;
            }
            if (string.IsNullOrWhiteSpace(dept) || dept == "Not Selected")
            {
                MessageBox.Show("Select the Department");
                return;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address cannot be empty");
                return;
            }
            if (string.IsNullOrWhiteSpace(dob))
            {
                MessageBox.Show("Date of Birth cannot be empty");
                return;
            }
            if (string.IsNullOrWhiteSpace(Skill))
            {
                MessageBox.Show("Select at least one Skill");
                return;
            }

            //MessageBox.Show(firstName + " " + lastName + " " + email + " " + cbMarit + " " + number + " " + department + " " + address + " " + dob + " " + Gender);

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=KING\SQLEXPRESS;Initial Catalog=UMS;Integrated Security=True;TrustServerCertificate=True");
                con.Open();

                string query = "INSERT INTO Registration_Table VALUES ('" + username + "','" + password + "','" + Gender + "','" + email + "'," + number
 + ",'" + dept + "','" + Skill + "','" + dtpDOB.Value.ToString("yyyy-MM-dd") + "','" + address + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registered Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
