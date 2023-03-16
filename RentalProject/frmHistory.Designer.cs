namespace RentalProject
{
    partial class frmHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayment = new System.Windows.Forms.TabControl();
            this.HireHistory = new System.Windows.Forms.TabPage();
            this.dgvHire = new System.Windows.Forms.DataGridView();
            this.PaymentHistory = new System.Windows.Forms.TabPage();
            this.dgvBrand = new System.Windows.Forms.DataGridView();
            this.dgvPayment.SuspendLayout();
            this.HireHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHire)).BeginInit();
            this.PaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1067, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPayment
            // 
            this.dgvPayment.Controls.Add(this.HireHistory);
            this.dgvPayment.Controls.Add(this.PaymentHistory);
            this.dgvPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPayment.Location = new System.Drawing.Point(0, 61);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.Padding = new System.Drawing.Point(15, 12);
            this.dgvPayment.SelectedIndex = 0;
            this.dgvPayment.Size = new System.Drawing.Size(1067, 501);
            this.dgvPayment.TabIndex = 6;
            // 
            // HireHistory
            // 
            this.HireHistory.Controls.Add(this.dgvHire);
            this.HireHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HireHistory.Location = new System.Drawing.Point(4, 56);
            this.HireHistory.Margin = new System.Windows.Forms.Padding(0);
            this.HireHistory.Name = "HireHistory";
            this.HireHistory.Size = new System.Drawing.Size(1059, 441);
            this.HireHistory.TabIndex = 0;
            this.HireHistory.Text = "Hire";
            this.HireHistory.UseVisualStyleBackColor = true;
            // 
            // dgvHire
            // 
            this.dgvHire.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvHire.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvHire.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvHire.ColumnHeadersHeight = 55;
            this.dgvHire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHire.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvHire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHire.Location = new System.Drawing.Point(0, 0);
            this.dgvHire.Name = "dgvHire";
            this.dgvHire.ReadOnly = true;
            this.dgvHire.RowHeadersVisible = false;
            this.dgvHire.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(10);
            this.dgvHire.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvHire.RowTemplate.Height = 50;
            this.dgvHire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHire.Size = new System.Drawing.Size(1059, 441);
            this.dgvHire.TabIndex = 9;
            // 
            // PaymentHistory
            // 
            this.PaymentHistory.Controls.Add(this.dgvBrand);
            this.PaymentHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentHistory.Location = new System.Drawing.Point(4, 56);
            this.PaymentHistory.Margin = new System.Windows.Forms.Padding(0);
            this.PaymentHistory.Name = "PaymentHistory";
            this.PaymentHistory.Size = new System.Drawing.Size(1059, 441);
            this.PaymentHistory.TabIndex = 1;
            this.PaymentHistory.Text = "Payment";
            this.PaymentHistory.UseVisualStyleBackColor = true;
            // 
            // dgvBrand
            // 
            this.dgvBrand.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvBrand.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvBrand.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrand.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvBrand.ColumnHeadersHeight = 55;
            this.dgvBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBrand.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBrand.Location = new System.Drawing.Point(0, 0);
            this.dgvBrand.Name = "dgvBrand";
            this.dgvBrand.ReadOnly = true;
            this.dgvBrand.RowHeadersVisible = false;
            this.dgvBrand.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle24.Padding = new System.Windows.Forms.Padding(10);
            this.dgvBrand.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvBrand.RowTemplate.Height = 50;
            this.dgvBrand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBrand.Size = new System.Drawing.Size(1059, 441);
            this.dgvBrand.TabIndex = 10;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHistory";
            this.Text = "frmHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.dgvPayment.ResumeLayout(false);
            this.HireHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHire)).EndInit();
            this.PaymentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl dgvPayment;
        private System.Windows.Forms.TabPage HireHistory;
        private System.Windows.Forms.DataGridView dgvHire;
        private System.Windows.Forms.TabPage PaymentHistory;
        private System.Windows.Forms.DataGridView dgvBrand;
    }
}