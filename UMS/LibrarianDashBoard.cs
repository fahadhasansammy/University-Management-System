using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UMS
{
    public partial class LibrarianDashBoard : Form
    {
        public LibrarianDashBoard()
        {
            InitializeComponent();
        }
        
        private void LoadUserInfoCommand()
        {
            try
            {
                
                string query = "SELECT * FROM LibraryBookManager";
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                dgvBookManage.AutoGenerateColumns = false;
                //0th index table
                dgvBookManage.DataSource = result.Data; //datagridview name
                dgvBookManage.Refresh();
                dgvBookManage.ClearSelection();
                

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
        private void resetCommand()
        {
            txtId.Text = "Auto Generated";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtISBN.Text = "";
            cmbDept.SelectedItem = null;
        }

        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("title and author cannot be empty");
                return;
            }
            int isbn = Convert.ToInt32(txtISBN.Text);
            if (string.IsNullOrWhiteSpace(isbn.ToString()))
            {
                MessageBox.Show("Enter a valid ISBN number");
                return;
            }
            string dept;
            if (cmbDept.SelectedItem != null)
            {
                dept = cmbDept.SelectedItem.ToString();
            }
            else
            {
                dept = "Not Selected";
            }
            //MessageBox.Show(title + " " + author + " " + isbn + " " + dept);
            try
            {
                
                string query;
                query = "INSERT INTO LibraryBookManager VALUES ('" + title + "','" + author + "'," + isbn + ",'" + dept + "')";
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
        private void dgbBookManage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                {
                    dgvBookManage.ClearSelection();
                    return;
                }
                this.resetCommand();
                int id = int.Parse(dgvBookManage.Rows[e.RowIndex].Cells["dgvId"].Value.ToString());
                
                string query = "SELECT * FROM LibraryBookManager where id=" + id;
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                 //0th index table
                txtId.Text = result.Data.Rows[0]["id"].ToString();
                txtTitle.Text = result.Data.Rows[0]["title"].ToString();
                txtAuthor.Text = result.Data.Rows[0]["author"].ToString();
                txtISBN.Text = result.Data.Rows[0]["isbn"].ToString();
                cmbDept.SelectedItem = result.Data.Rows[0]["dept"].ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.resetCommand();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "Auto Generated")
            {
                MessageBox.Show("Error:Select a row first!");
                return;
            }
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Invalid ID value!");
                return;
            }

            string query = "DELETE FROM LibraryBookManager where id=" + id;
            var result = DbHelper.ExecuteNonResultQuery(query);
            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }
            MessageBox.Show("Deleted ");
            this.LoadUserInfoCommand();
        }
    }
}
