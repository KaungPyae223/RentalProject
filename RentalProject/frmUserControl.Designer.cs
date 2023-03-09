namespace RentalProject
{
    partial class frmUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tslLabel = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsmCustomerName = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAccountName = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUser = new System.Windows.Forms.ToolStripTextBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 61);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tslLabel,
            this.txtUser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 61);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(800, 59);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripButton1.Size = new System.Drawing.Size(154, 44);
            this.toolStripButton1.Text = "Update Level";
            // 
            // tslLabel
            // 
            this.tslLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmCustomerName,
            this.TsmEmail,
            this.TsmAccountName});
            this.tslLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslLabel.Image = ((System.Drawing.Image)(resources.GetObject("tslLabel.Image")));
            this.tslLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslLabel.Name = "tslLabel";
            this.tslLabel.Size = new System.Drawing.Size(189, 44);
            this.tslLabel.Text = "Customer Name";
            // 
            // TsmCustomerName
            // 
            this.TsmCustomerName.Name = "TsmCustomerName";
            this.TsmCustomerName.Size = new System.Drawing.Size(274, 38);
            this.TsmCustomerName.Text = "Customer Name";
            this.TsmCustomerName.Click += new System.EventHandler(this.TsmCustomerName_Click);
            // 
            // TsmEmail
            // 
            this.TsmEmail.Name = "TsmEmail";
            this.TsmEmail.Size = new System.Drawing.Size(274, 38);
            this.TsmEmail.Text = "Customer Email";
            this.TsmEmail.Click += new System.EventHandler(this.TsmEmail_Click);
            // 
            // TsmAccountName
            // 
            this.TsmAccountName.Name = "TsmAccountName";
            this.TsmAccountName.Size = new System.Drawing.Size(274, 38);
            this.TsmAccountName.Text = "Account Name";
            this.TsmAccountName.Click += new System.EventHandler(this.TsmAccountName_Click);
            // 
            // txtUser
            // 
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUser.AutoSize = false;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(250, 37);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvUser.ColumnHeadersHeight = 55;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 120);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle24.Padding = new System.Windows.Forms.Padding(10);
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvUser.RowTemplate.Height = 50;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(800, 330);
            this.dgvUser.TabIndex = 7;
            // 
            // frmUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserControl";
            this.Text = "frmUserControl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUserControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton tslLabel;
        private System.Windows.Forms.ToolStripMenuItem TsmCustomerName;
        private System.Windows.Forms.ToolStripMenuItem TsmEmail;
        private System.Windows.Forms.ToolStripTextBox txtUser;
        private System.Windows.Forms.ToolStripMenuItem TsmAccountName;
        private System.Windows.Forms.DataGridView dgvUser;
    }
}