namespace UMS
{
    partial class Librarian
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLibrarian = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnLibrarianDashboard = new System.Windows.Forms.Button();
            this.btnIssueReturn = new System.Windows.Forms.Button();
            this.dgvLibrarian.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLibrarian
            // 
            this.dgvLibrarian.ColumnCount = 2;
            this.dgvLibrarian.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.dgvLibrarian.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dgvLibrarian.Controls.Add(this.pnlMain, 1, 0);
            this.dgvLibrarian.Controls.Add(this.panel1, 0, 0);
            this.dgvLibrarian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibrarian.Location = new System.Drawing.Point(0, 0);
            this.dgvLibrarian.Name = "dgvLibrarian";
            this.dgvLibrarian.RowCount = 1;
            this.dgvLibrarian.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dgvLibrarian.Size = new System.Drawing.Size(1030, 550);
            this.dgvLibrarian.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnIssueReturn);
            this.panel1.Controls.Add(this.btnLibrarianDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 544);
            this.panel1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(153, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(874, 544);
            this.pnlMain.TabIndex = 1;
            // 
            // btnLibrarianDashboard
            // 
            this.btnLibrarianDashboard.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnLibrarianDashboard.Location = new System.Drawing.Point(9, 9);
            this.btnLibrarianDashboard.Name = "btnLibrarianDashboard";
            this.btnLibrarianDashboard.Size = new System.Drawing.Size(132, 33);
            this.btnLibrarianDashboard.TabIndex = 0;
            this.btnLibrarianDashboard.Text = "Librarian Dashboard";
            this.btnLibrarianDashboard.UseVisualStyleBackColor = false;
            this.btnLibrarianDashboard.Click += new System.EventHandler(this.btnLibrarianDashboard_Click);
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIssueReturn.Location = new System.Drawing.Point(9, 48);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(132, 33);
            this.btnIssueReturn.TabIndex = 1;
            this.btnIssueReturn.Text = "Issue/Return";
            this.btnIssueReturn.UseVisualStyleBackColor = false;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            // 
            // Librarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 550);
            this.Controls.Add(this.dgvLibrarian);
            this.Name = "Librarian";
            this.Text = "Librarian";
            this.dgvLibrarian.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dgvLibrarian;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLibrarianDashboard;
        private System.Windows.Forms.Button btnIssueReturn;
    }
}