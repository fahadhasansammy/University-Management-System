using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS
{
    public partial class FinalDashBoard1 : Form
    {
        public FinalDashBoard1()
        {
            InitializeComponent();
        }
        
        
        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            Librarian lbd = new Librarian();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }

        private void btnAccountant_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            Accountant lbd = new Accountant();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }

        private void FinalDashBoard1_Load(object sender, EventArgs e)
        {
            if(this.Owner != null)
                this.Owner.Hide();
            this.lblWelcome.Text += UserHelper.Username;
        }

        private void FinalDashBoard1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            Registration lbd = new Registration();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            manageStaff lbd = new manageStaff();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
            MessageBox.Show("Logged out successfully");
        }
    }
}
