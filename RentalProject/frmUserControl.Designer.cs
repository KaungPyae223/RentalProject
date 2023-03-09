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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tslLabel = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsmCustomerName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbItemName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.dgvPawn = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPawn)).BeginInit();
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
            this.label1.Text = "Users";
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
            this.toolStripTextBox1});
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
            this.toolStripButton1.Size = new System.Drawing.Size(90, 44);
            this.toolStripButton1.Text = "Delete";
            // 
            // tslLabel
            // 
            this.tslLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmCustomerName,
            this.tsmAmount,
            this.TsbItemName});
            this.tslLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslLabel.Image = ((System.Drawing.Image)(resources.GetObject("tslLabel.Image")));
            this.tslLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslLabel.Name = "tslLabel";
            this.tslLabel.Size = new System.Drawing.Size(139, 44);
            this.tslLabel.Text = "User Name";
            // 
            // TsmCustomerName
            // 
            this.TsmCustomerName.Name = "TsmCustomerName";
            this.TsmCustomerName.Size = new System.Drawing.Size(227, 38);
            this.TsmCustomerName.Text = "User Name";
            // 
            // tsmAmount
            // 
            this.tsmAmount.Name = "tsmAmount";
            this.tsmAmount.Size = new System.Drawing.Size(227, 38);
            this.tsmAmount.Text = "User Phone";
            // 
            // TsbItemName
            // 
            this.TsbItemName.Name = "TsbItemName";
            this.TsbItemName.Size = new System.Drawing.Size(227, 38);
            this.TsbItemName.Text = "User Email";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(250, 37);
            // 
            // dgvPawn
            // 
            this.dgvPawn.AllowUserToResizeRows = false;
            this.dgvPawn.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPawn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPawn.ColumnHeadersHeight = 35;
            this.dgvPawn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPawn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPawn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPawn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvPawn.Location = new System.Drawing.Point(0, 120);
            this.dgvPawn.MultiSelect = false;
            this.dgvPawn.Name = "dgvPawn";
            this.dgvPawn.ReadOnly = true;
            this.dgvPawn.RowHeadersVisible = false;
            this.dgvPawn.RowHeadersWidth = 62;
            this.dgvPawn.RowTemplate.Height = 28;
            this.dgvPawn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPawn.Size = new System.Drawing.Size(800, 330);
            this.dgvPawn.TabIndex = 4;
            // 
            // frmUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPawn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserControl";
            this.Text = "frmUserControl";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPawn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton tslLabel;
        private System.Windows.Forms.ToolStripMenuItem TsmCustomerName;
        private System.Windows.Forms.ToolStripMenuItem tsmAmount;
        private System.Windows.Forms.ToolStripMenuItem TsbItemName;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        public System.Windows.Forms.DataGridView dgvPawn;
    }
}