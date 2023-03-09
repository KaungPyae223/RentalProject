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
    public partial class frmAdminInfo : Form
    {
        public frmAdminInfo()
        {
            InitializeComponent();
        }
        RentalDataSetTableAdapters.AdminTableAdapter objAdmin = new RentalDataSetTableAdapters.AdminTableAdapter();
        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmAdminAdd frm = new frmAdminAdd();
            frm.ShowDialog();
        }

        private void frmAdminInfo_Load(object sender, EventArgs e)
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

        }
    }
}
