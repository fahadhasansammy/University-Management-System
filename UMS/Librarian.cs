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
    public partial class Librarian : Form
    {
        public Librarian()
        {
            InitializeComponent();
        }

        private void btnLibrarianDashboard_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            LibrarianDashBoard lbd = new LibrarianDashBoard();
            lbd.TopLevel = false;
            lbd.FormBorderStyle = FormBorderStyle.None;
            lbd.AutoScroll = true;
            lbd.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lbd);
            lbd.Show();
            
        }

        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            LibrarianIssueReturn1 lir = new LibrarianIssueReturn1();
            lir.TopLevel = false;
            lir.FormBorderStyle = FormBorderStyle.None;
            lir.AutoScroll = true;
            lir.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(lir);
            lir.Show();
        }
    }
}
