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
    public partial class AccountantFees1 : Form
    {
        public AccountantFees1()
        {
            InitializeComponent();
        }
        private void LoadUserInfoCommand()
        {
            try
            {

                string query = "SELECT * FROM AccountandFees";
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                //0th index table
                dgvAccountantFees.DataSource = result.Data; //datagridview name
                dgvAccountantFees.Refresh();
                dgvAccountantFees.ClearSelection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void resetCommand()
        {
            txtSerialNo.Text = "Auto Generated";
            txtStudentId.Text = "";
            cmbPaymentType.SelectedItem = null;
            rdbPaid.Checked = rdbPending.Checked = false;

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadUserInfoCommand();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.resetCommand();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string StduentId = txtStudentId.Text;
            string DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string PaymentType;
            if (cmbPaymentType.SelectedItem != null)
            {
                PaymentType = cmbPaymentType.SelectedItem.ToString();
            }
            else
            {
                PaymentType = "Not Selected";
            }
            if (string.IsNullOrWhiteSpace(StduentId))
            {
                MessageBox.Show("Student ID can not be empty!");
                return;
            }
            string status = "";
            if (rdbPaid.Checked)
                status = rdbPaid.Text;
            if (rdbPending.Checked)
                status = rdbPending.Text;
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Select the Status");
                return;
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Select the Status");
                return;
            }

            try
            {

                string query;
                query = "INSERT INTO AccountandFees VALUES ('" + StduentId + "','" + DOB + "','" + PaymentType + "','" + status + "')";
                var result = DbHelper.ExecuteNonResultQuery(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                MessageBox.Show("Save");
                this.LoadUserInfoCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSerialNo.Text == "Auto Generated")
            {
                MessageBox.Show("Error:Select a row first!");
                return;
            }
            if (!int.TryParse(txtSerialNo.Text, out int SerialNo))
            {
                MessageBox.Show("Invalid Serial value!");
                return;
            }

            string query = "DELETE FROM AccountandFees where SerialNo=" + SerialNo;
            var result = DbHelper.ExecuteNonResultQuery(query);
            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }
            MessageBox.Show("Delete ");
            this.LoadUserInfoCommand();
        }

        private void dgvAccountantFees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                {
                    dgvAccountantFees.ClearSelection();
                    return;
                }
                this.resetCommand();
                int SerialNo = int.Parse(dgvAccountantFees.Rows[e.RowIndex].Cells["dgvSerialNo"].Value.ToString());
                string query = "SELECT * FROM AccountandFees where SerialNo=" + SerialNo;
                var result = DbHelper.GetQueryData(query);
                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                //0th index table
                txtSerialNo.Text = result.Data.Rows[0]["SerialNo"].ToString();
                txtStudentId.Text = result.Data.Rows[0]["StudentId"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(result.Data.Rows[0]["Date"]);
                cmbPaymentType.SelectedItem = result.Data.Rows[0]["PaymentType"].ToString();
                rdbPaid.Checked = result.Data.Rows[0]["Status"].ToString() == "Paid";
                rdbPending.Checked = result.Data.Rows[0]["Status"].ToString() == "Pending";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
