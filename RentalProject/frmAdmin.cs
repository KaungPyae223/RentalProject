﻿using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        RentalTableAdapters.AdminTableAdapter objAdmin = new RentalTableAdapters.AdminTableAdapter();
        clsModify objClsModify = new clsModify();

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmAdminAdd frm = new frmAdminAdd();
            frm.ShowDialog();
            dgvAdmin.DataSource = objAdmin.GetAdmin();
            MakeColor();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = objAdmin.GetAdmin();
            dgvAdmin.Columns[0].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[1].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[2].Visible = false;
            dgvAdmin.Columns[3].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[4].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[5].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[6].Width = (dgvAdmin.Width/100)*20;
            dgvAdmin.Columns[7].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[8].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[9].Visible = false;
            dgvAdmin.Columns[10].Width = (dgvAdmin.Width/100)*15;
            dgvAdmin.Columns[11].Visible = false;
            dgvAdmin.Columns[12].Visible = false;
            MakeColor();

            dgvAdminProcess.DataSource = objClsModify.getModify();
            dgvAdminProcess.Columns[0].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[1].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[2].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[3].Width = (dgvAdminProcess.Width/100) * 25;
            Suggestion();
        }

        public void Suggestion()
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            DataTable DT = objClsModify.getModify();
            if (DT.Rows.Count > 0)
            {
                txtAdminName.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[0].ToString());
                }
                txtAdminName.AutoCompleteCustomSource = sourse;
                txtAdminName.Text = "";
                txtAdminName.Focus();
            }
        }

        private void txtAdminName_TextChanged(object sender, EventArgs e)
        {
            dgvAdminProcess.DataSource = objClsModify.GetModifyByID(txtAdminName.Text);
            MakeColor();
            dgvAdminProcess.Refresh();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvAdmin.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmAdminAdd frm = new frmAdminAdd();
                frm.txtPassword.Visible = false;
                frm.txtConfirmPassword.Visible = false;
                frm.txtID.Text = dgvAdmin.CurrentRow.Cells[0].Value.ToString();
                frm.txtEmail.Text = dgvAdmin.CurrentRow.Cells[6].Value.ToString();
                frm.txtLocation.Text = dgvAdmin.CurrentRow.Cells[5].Value.ToString();
                frm.txtName.Text = dgvAdmin.CurrentRow.Cells[4].Value.ToString();
                frm.txtAccountName.Text = dgvAdmin.CurrentRow.Cells[3].Value.ToString();
                frm.txtPhone.Text = dgvAdmin.CurrentRow.Cells[7].Value.ToString();
                frm.txtNRC.Text = dgvAdmin.CurrentRow.Cells[8].Value.ToString();
                frm.txtInfo.Text = dgvAdmin.CurrentRow.Cells[10].Value.ToString();
                frm.cboPost.SelectedValue = dgvAdmin.CurrentRow.Cells[2].Value.ToString();
                frm.IsEdit = true;
                frm.image = (byte[])(dgvAdmin.CurrentRow.Cells[12].Value);
                frm.Show();
                dgvAdmin.DataSource = objAdmin.GetAdmin();
                MakeColor();
            }

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvAdmin.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a row to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure to remove "+dgvAdmin.CurrentRow.Cells[4].Value.ToString(), "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    objAdmin.RemoveAdmin("", dgvAdmin.CurrentRow.Cells[0].Value.ToString());
                    dgvAdmin.DataSource = objAdmin.GetAdmin();
                    MakeColor();
                    MessageBox.Show("Successfully remove");
                }
            }
        }
        private void MakeColor()
        {
            int lastIndex = dgvAdmin.Rows.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                if (dgvAdmin.Rows[i].Cells[2].Value.ToString() == "")
                {

                    dgvAdmin.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dgvAdmin.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }

        private void dgvAdmin_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }
    }

}
