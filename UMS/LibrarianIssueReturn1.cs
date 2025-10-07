using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS
{
    public partial class LibrarianIssueReturn1 : Form
    {
        public LibrarianIssueReturn1()
        {
            InitializeComponent();
        }
        private void LoadUserInfoCommand()
        {
            try
            {

                string query = "SELECT * FROM LibrarianIssueReturn";
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                //0th index table
                dgvIssueReturn.DataSource = result.Data; //datagridview name
                dgvIssueReturn.Refresh();
                dgvIssueReturn.ClearSelection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void resetCommand()
        {
            txtSerial.Text = "Auto Generated";
            txtStudentId.Text = "";
            txtBookTitle.Text = "";
            dtpDueDate.Value = DateTime.Now;
        } 
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string StduentId = txtStudentId.Text;
            string BookTitle = txtBookTitle.Text;
            if (string.IsNullOrWhiteSpace(StduentId) || string.IsNullOrWhiteSpace(BookTitle))
            {
                MessageBox.Show("title and author cannot be empty");
                return;
            }
            string DOB = dtpDueDate.Value.ToString("yyyy-MM-dd");

            try
            {

                string query;
                query = "INSERT INTO LibrarianIssueReturn VALUES ('" + StduentId + "','" + BookTitle + "','" + DOB + "')";
                var result = DbHelper.ExecuteNonResultQuery(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                MessageBox.Show("Book Borrow ");
                this.LoadUserInfoCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadUserInfoCommand();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.resetCommand();
        }

        private void dgvIssueReturn_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                {
                    dgvIssueReturn.ClearSelection();
                    return;
                }
                this.resetCommand();
                int Serial = int.Parse(dgvIssueReturn.Rows[e.RowIndex].Cells["dgvSerial"].Value.ToString());
                string query = "SELECT * FROM LibrarianIssueReturn where Serial=" + Serial;
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                //0th index table
                txtSerial.Text = result.Data.Rows[0]["Serial"].ToString();
                txtStudentId.Text = result.Data.Rows[0]["StudentId"].ToString();
                txtBookTitle.Text = result.Data.Rows[0]["BookTitle"].ToString();
                dtpDueDate.Value = Convert.ToDateTime(result.Data.Rows[0]["Date"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRetrn_Click(object sender, EventArgs e)
        {
            if (txtSerial.Text == "Auto Generated")
            {
                MessageBox.Show("Error:Select a row first!");
                return;
            }
            if (!int.TryParse(txtSerial.Text, out int Serial))
            {
                MessageBox.Show("Invalid Sesrial value!");
                return;
            }

            string query = "DELETE FROM LibrarianIssueReturn where Serial=" + Serial;
            var result = DbHelper.ExecuteNonResultQuery(query);
            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }
            MessageBox.Show("Return ");
            this.LoadUserInfoCommand();
        }
    }
}
