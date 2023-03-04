using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
            this.DT = Program.DT;
            AddInfo();
        }

        DataTable DT = new DataTable();

        private void AddInfo()
        {
            lblName.Text = DT.Rows[0]["CustomerName"].ToString();
            lblAccountName.Text = DT.Rows[0]["AccountName"].ToString();
            lblEmail.Text = DT.Rows[0]["CustomerEmail"].ToString();
            lblID.Text = DT.Rows[0]["CustomerID"].ToString();
            lblLocation.Text = DT.Rows[0]["CustomerLocation"].ToString();
            lblUserLevel.Text = DT.Rows[0]["CustomerLevel"].ToString();

            if(DT.Rows[0]["CustomerPhoto"].ToString() != string.Empty)
            {
                byte[] img = (byte[])(DT.Rows[0]["CustomerPhoto"]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserRegister frm = new frmUserRegister();
            frm.ShowDialog();
        }
    }
}
