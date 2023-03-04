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
        RentalDataSetTableAdapters.vi_ItemTableAdapter objItem = new RentalDataSetTableAdapters.vi_ItemTableAdapter();
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter();
        RentalDataSetTableAdapters.TypeTableAdapter objType = new RentalDataSetTableAdapters.TypeTableAdapter();
        RentalDataSetTableAdapters.DeliveryTableAdapter objDelivery = new RentalDataSetTableAdapters.DeliveryTableAdapter();
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
            else if (cboList.SelectedIndex == 1)
            {
                frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(true, false);
                frm.ShowDialog();
            }
            else if (cboList.SelectedIndex == 2)
            {
                frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(false, false);
                frm.ShowDialog();
            }
            else
            {
                frmDelivery frm = new frmDelivery();
                frm.ShowDialog();
            }
            showData();

        }

        private void cboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            showData();
            if(cboList.SelectedIndex == 0)
            {
                tsbSearch.Enabled = true;
                tstSearch.Enabled = true;
            }
            else
            {
                tsbSearch.Enabled = false;
                tstSearch.Enabled = false;
            }
        }

        private void showData() //method to show the data in data grid view
        {
            if(cboList.SelectedIndex == 0)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= objItem.GetVi_Item();
                dgvItem.Columns[0].Width = (label1.Width/100)* 10;
                dgvItem.Columns[1].Visible = false;
                dgvItem.Columns[2].Visible = false;
                dgvItem.Columns[3].Width = (dgvItem.Width/100)* 25;
                dgvItem.Columns[4].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[5].Width = (dgvItem.Width/100)* 15;
                dgvItem.Columns[6].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[7].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[8].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[9].Visible = false;
                dgvItem.Columns[10].Visible = false;
                dgvItem.Columns[11].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[12].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[13].Width = (dgvItem.Width/100)* 10;
                dgvItem.Columns[13].DisplayIndex = 8;
            }
            else if (cboList.SelectedIndex == 1)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= objBrand.GetBrand();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 80;
                
            }
            else if (cboList.SelectedIndex == 2)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= objType.GetType();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 80;
            }
            else if (cboList.SelectedIndex == 3)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= objDelivery.GetDelivery();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 40;
                dgvItem.Columns[2].Width = (dgvItem.Width/100)* 40;

            }
            dgvItem.Refresh();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvItem.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (cboList.SelectedIndex == 1)
                {
                    frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(true, true);
                    frm.txtBrandID.Text = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    frm.txtBrand.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
                    frm.ShowDialog();
                }
                else
                {
                    frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(false, true);
                    frm.txtBrandID.Text = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    frm.txtBrand.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
                    frm.ShowDialog();
                }
            }

            showData();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvItem.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to delete or not
            {
                MessageBox.Show("Plese select a row to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Sure to Edit", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                {
                    if (cboList.SelectedIndex == 1) // check which type to dele
                    {
                        objBrand.DeleteBrand(dgvItem.CurrentRow.Cells[0].Value.ToString());
                    }
                    if (cboList.SelectedIndex == 2)
                    {
                        objType.DeleteType(dgvItem.CurrentRow.Cells[0].Value.ToString());
                    }
                    MessageBox.Show("Successfully delet");
                    showData();
                }
            }
        }

        
    }
}
