using RentalProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dgvAdminProcess.Refresh();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            frmAdminAdd frm = new frmAdminAdd();
            frm.txtPassword.Visible = false;
            frm.txtConfirmPassword.Visible = false;
        }
    }
    
}
