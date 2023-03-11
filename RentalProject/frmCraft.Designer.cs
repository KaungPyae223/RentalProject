namespace RentalProject
{
    partial class frmCraft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCraft));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPPM = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHire = new System.Windows.Forms.Button();
            this.craftMainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1213, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "Craft";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnHire);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 84);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblPPM);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTotalQty);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(440, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 84);
            this.panel2.TabIndex = 14;
            // 
            // lblPPM
            // 
            this.lblPPM.AutoSize = true;
            this.lblPPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPM.Location = new System.Drawing.Point(581, 29);
            this.lblPPM.Name = "lblPPM";
            this.lblPPM.Size = new System.Drawing.Size(27, 29);
            this.lblPPM.TabIndex = 3;
            this.lblPPM.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(306, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Rent Price per Month:";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(166, 29);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(27, 29);
            this.lblTotalQty.TabIndex = 1;
            this.lblTotalQty.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Qty:";
            // 
            // btnHire
            // 
            this.btnHire.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHire.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHire.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHire.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHire.Image = ((System.Drawing.Image)(resources.GetObject("btnHire.Image")));
            this.btnHire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHire.Location = new System.Drawing.Point(12, 12);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(155, 60);
            this.btnHire.TabIndex = 12;
            this.btnHire.Text = "       Hire";
            this.btnHire.UseVisualStyleBackColor = false;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // craftMainPanel
            // 
            this.craftMainPanel.AutoScroll = true;
            this.craftMainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.craftMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.craftMainPanel.Location = new System.Drawing.Point(0, 61);
            this.craftMainPanel.Name = "craftMainPanel";
            this.craftMainPanel.Size = new System.Drawing.Size(1213, 305);
            this.craftMainPanel.TabIndex = 4;
            this.craftMainPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.craftMainPanel_ControlRemoved);
            // 
            // frmCraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1213, 450);
            this.Controls.Add(this.craftMainPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCraft";
            this.Text = "frmCraft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCraft_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.FlowLayoutPanel craftMainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPPM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label3;
    }
}