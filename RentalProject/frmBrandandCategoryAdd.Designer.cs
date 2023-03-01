namespace RentalProject
{
    partial class frmBrandandCategoryAdd
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblBrandID = new System.Windows.Forms.Label();
            this.txtBrandID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(57, 141);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(64, 25);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(190, 138);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(215, 30);
            this.txtBrand.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(62, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(297, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 44);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblBrandID
            // 
            this.lblBrandID.AutoSize = true;
            this.lblBrandID.Location = new System.Drawing.Point(57, 63);
            this.lblBrandID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrandID.Name = "lblBrandID";
            this.lblBrandID.Size = new System.Drawing.Size(88, 25);
            this.lblBrandID.TabIndex = 4;
            this.lblBrandID.Text = "Brand ID";
            // 
            // txtBrandID
            // 
            this.txtBrandID.Location = new System.Drawing.Point(190, 60);
            this.txtBrandID.Name = "txtBrandID";
            this.txtBrandID.ReadOnly = true;
            this.txtBrandID.Size = new System.Drawing.Size(215, 30);
            this.txtBrandID.TabIndex = 5;
            // 
            // frmBrandandCategoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(473, 331);
            this.Controls.Add(this.txtBrandID);
            this.Controls.Add(this.lblBrandID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblBrand);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrandandCategoryAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.frmBrandAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblBrandID;
        public System.Windows.Forms.TextBox txtBrandID;
        public System.Windows.Forms.TextBox txtBrand;
    }
}