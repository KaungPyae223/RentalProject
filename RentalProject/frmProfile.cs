﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
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
            AddHistory();
        }
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        RentalTableAdapters.vi_CustomerPaymentTableAdapter objHistory = new RentalTableAdapters.vi_CustomerPaymentTableAdapter();
        DataTable DT = new DataTable();

        private void AddHistory()
        {
            string Description;
            DataTable Return = new DataTable();
            Return = objHire.GetReturnDate(DT.Rows[0][0].ToString());
            DataTable History = new DataTable();
            History = objHistory.GetData(DT.Rows[0][0].ToString());
            DataTable ShowHistory = new DataTable();
            ShowHistory.Columns.Add("HireID", typeof(string));
            ShowHistory.Columns.Add("Description", typeof(string));
            ShowHistory.Columns.Add("Date", typeof(string));
            int a = 0;
            foreach (DataRow Row in History.Rows)
            {
                
                int i = a;
                while(i<Return.Rows.Count)
                {
                    if(Convert.ToDateTime(Row[4])<=Convert.ToDateTime(Return.Rows[i][10]))
                    {
                        DataRow Ret = ShowHistory.NewRow();
                        Ret[0] = Return.Rows[i][0].ToString();
                        Description = "Return an Hire";
                        Ret[1]= Description;
                        Ret[2]= Convert.ToDateTime(Return.Rows[i][10]).ToString("dd MMMM yyyy");
                        ShowHistory.Rows.Add(Ret);
                        a++;
                    }
                    i++;
                }
                DataRow dr = ShowHistory.NewRow();
                dr[0] = Row[1].ToString();
                Description = Row[6].ToString();
                Description = (Description.Contains("New Hire")) ? "New Hire" : Row[6].ToString();
                dr[1]= Description;
                dr[2]= Convert.ToDateTime(Row[4]).ToString("dd MMMM yyyy");
                ShowHistory.Rows.Add(dr);
            }
            dgvUserHistory.DataSource = ShowHistory;
            dgvUserHistory.Columns[0].Width = (dgvUserHistory.Width/100)*10;
            dgvUserHistory.Columns[1].Width = (dgvUserHistory.Width/100)*70;
            dgvUserHistory.Columns[2].Width = (dgvUserHistory.Width/100)*20;

        }
        private void AddInfo()
        {
            if (Program.Type == "User")
            {
                lblName.Text = DT.Rows[0]["CustomerName"].ToString();
                lblAccountName.Text = DT.Rows[0]["AccountName"].ToString();
                lblEmail.Text = DT.Rows[0]["CustomerEmail"].ToString();
                lblID.Text = DT.Rows[0]["CustomerID"].ToString();
                lblLocation.Text = DT.Rows[0]["CustomerLocation"].ToString();
                lblUserLevel.Text = DT.Rows[0]["CustomerLevel"].ToString();

                if (DT.Rows[0]["CustomerPhoto"].ToString() != string.Empty)
                {
                    byte[] img = (byte[])(DT.Rows[0]["CustomerPhoto"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                lblName.Text = DT.Rows[0]["AdminName"].ToString();
                lblAccountName.Text = DT.Rows[0]["AccountName"].ToString();
                lblEmail.Text = DT.Rows[0]["AdminEmail"].ToString();
                lblID.Text = DT.Rows[0]["AdminID"].ToString();
                lblLocation.Text = DT.Rows[0]["AdminLocation"].ToString();
                lblUserLevel.Text = DT.Rows[0]["AdminPost"].ToString();

                if (DT.Rows[0]["AdminPhoto"].ToString() != string.Empty)
                {
                    byte[] img = (byte[])(DT.Rows[0]["AdminPhoto"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserRegister frm = new frmUserRegister();
            frm.ShowDialog();
        }
    }
}
