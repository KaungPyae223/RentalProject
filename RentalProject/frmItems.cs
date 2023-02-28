using System;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter();
        private void frmItems_Load(object sender, EventArgs e)
        {
            cboList.SelectedIndex= 0;
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            //check which category to create new
            if (cboList.SelectedIndex == 0)
            {
                frmAddItem frm = new frmAddItem();
                frm.ShowDialog();
            }
            if (cboList.SelectedIndex == 1)
            {
                frmBrandAdd frm = new frmBrandAdd();
                frm.ShowDialog();
            }
        }

        private void cboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboList.SelectedIndex == 1) 
            {
                dgvItem.DataSource= objBrand.GetBrand();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 80;

            }
            dgvItem.Refresh();
        }
    }
}
