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
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }

        private void btnAccountantFees_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            AccountantFees1 lbd = new AccountantFees1();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }

        private void btnAccountantStaffSalary_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            AccountantStaffSalary lbd = new AccountantStaffSalary();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
        }
    }
}
