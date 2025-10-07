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
    public partial class manageStaff : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=KING\SQLEXPRESS;Initial Catalog=UMS;Integrated Security=True;TrustServerCertificate=True");

        public manageStaff()
        {
            InitializeComponent();
        }
        private void LoadUserInfoCommand(string searchValue="")

        {
            try
            {
                
                
                string query = "SELECT * FROM Registration_Table";
                if(!string.IsNullOrWhiteSpace(searchValue))
                {
                    int id;
                    if (int.TryParse(searchValue, out id))
                    {
                        query += " where id=" + id + " OR username LIKE '%" + searchValue + "%'";
                    }
                    else
                    {
                        query += " where username LIKE '%" + searchValue + "%' OR email LIKE '%" + searchValue + "%' OR department LIKE '%" + searchValue + "%'";
                    }
                }
                var result = DbHelper.GetQueryData(query);
                if(result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                dgvManagerInfo.DataSource = result.Data; //datagridview name
                dgvManagerInfo.Refresh();
                dgvManagerInfo.ClearSelection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void resetCommand()
        {
            txtId.Text = "Auto Generated";
            txtUsername.Text = "Username";
            txtUsername.ForeColor = System.Drawing.Color.Gray;
            txtSetPassword.Text = "Set Password";
            txtNumber.Text = "";
            txtEmail.Text = "";
            cmbDepartment.SelectedItem=null;
            txtAddress.Text = "";
            rdbMale.Checked = rdbFemale.Checked = false;
            cbTechnicalSkill.Checked = cbDomainSkill.Checked = false;
            txtSearch.Text = "";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadUserInfoCommand();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSetPassword_Click(object sender, EventArgs e)
        {
            txtSetPassword.Text = "";
            txtSetPassword.ForeColor = System.Drawing.Color.Black;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.resetCommand();
        }

        private void btnInsert_Click(object sender, EventArgs e)
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

                string query;
                if (txtId.Text == "Auto generated")
                {
                     query = "INSERT INTO Registration_Table VALUES ('" + username + "','" + password + "','" + Gender + "','" + email + "'," + number
                     + ",'" + dept + "','" + Skill + "','" + dtpDOB.Value.ToString("yyyy-MM-dd") + "','" + address + "')";
                }
                else
                {
                     query = "UPDATE Registration_Table SET username='" + username + "',password='" + password + "',gender ='" + Gender + "',email='" + email + "',number=" + number +
                        ",department='" + dept + "',skill='" + Skill + "',dateOfBirth='" + dob + "',address='" + address + "' where id=" + txtId.Text;
                }



                var result = DbHelper.ExecuteNonResultQuery(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                MessageBox.Show("Saved ");
                this.LoadUserInfoCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvManagerInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (e.RowIndex < 0)
                {
                    dgvManagerInfo.ClearSelection();
                    return;
                }
                this.resetCommand();
                int id = int.Parse(dgvManagerInfo.Rows[e.RowIndex].Cells["id"].Value.ToString());
                
                string query = "SELECT * FROM Registration_Table where id=" + id;

                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
    
                txtId.Text = result.Data.Rows[0]["id"].ToString();
                txtUsername.Text = result.Data.Rows[0]["username"].ToString();
                txtSetPassword.Text = result.Data.Rows[0]["password"].ToString();
                dtpDOB.Value = Convert.ToDateTime(result.Data.Rows[0]["dateOfBirth"]);
                rdbMale.Checked = result.Data.Rows[0]["gender"].ToString() == "Male";
                rdbFemale.Checked = result.Data.Rows[0]["gender"].ToString() == "Female";
                cmbDepartment.SelectedItem = result.Data.Rows[0]["department"].ToString();
                txtEmail.Text = result.Data.Rows[0]["email"].ToString();
                txtNumber.Text = result.Data.Rows[0]["number"].ToString();
   
                txtAddress.Text = result.Data.Rows[0]["Address"].ToString();
                string[] skills= result.Data.Rows[0]["skill"].ToString().Split(',');

                foreach(string skill in skills)
                {
                    if(skill.Trim() == cbTechnicalSkill.Text)
                        cbTechnicalSkill.Checked = true;
                    if (skill.Trim() == cbDomainSkill.Text)
                        cbDomainSkill.Checked = true;
                }
                cmbDepartment.SelectedItem = result.Data.Rows[0]["department"].ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "Auto Generated")
            {
                MessageBox.Show("Error:Select a row first!");
                return;
            }
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Invalid ID value!");
                return;
            }

            string query = "DELETE FROM Registration_Table where id=" + id;
            var result = DbHelper.ExecuteNonResultQuery(query);
            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }
            MessageBox.Show("Deleted ");
            this.LoadUserInfoCommand();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadUserInfoCommand(txtSearch.Text);
        }
    }
}
