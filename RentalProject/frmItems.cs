using RentalProject.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }

        clsBrand ClsBrand = new clsBrand();
        clsType ClsType = new clsType();
        clsDelivery ClsDelivery = new clsDelivery();
        clsItem objClsItem = new clsItem();
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
                frmDelivery frm = new frmDelivery(false);
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
            }
            else
            {
                tsbSearch.Enabled = false;
            }
        }

        private void showData() //method to show the data in data grid view
        {
            if(cboList.SelectedIndex == 0)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= objClsItem.GetItem();
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
                dgvItem.DataSource= ClsBrand.GetBrand();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 80;
                
            }
            else if (cboList.SelectedIndex == 2)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= ClsType.GetType();
                dgvItem.Columns[0].Width = (dgvItem.Width/100)* 20;
                dgvItem.Columns[1].Width = (dgvItem.Width/100)* 80;
            }
            else if (cboList.SelectedIndex == 3)
            {
                dgvItem.Columns.Clear();
                dgvItem.DataSource= ClsDelivery.GetDelivery();
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
                    frm.txtID.Text = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    frm.txtName.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
                    frm.btnAdd.Text = "Edit";
                    frm.ShowDialog();
                }
                else if(cboList.SelectedIndex == 2)
                {
                    frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(false, true);
                    frm.txtID.Text = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    frm.txtName.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
                    frm.btnAdd.Text = "Edit";
                    frm.ShowDialog();
                }
                else
                {
                    frmDelivery frm = new frmDelivery(true);
                    frm.txtDeliveryID.Text = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    frm.txtDeliveryName.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
                    frm.txtDeliveryPhone.Text = dgvItem.CurrentRow.Cells[2].Value.ToString();
                    frm.btnSave.Text = "Edit";
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
                if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                {
                    if (cboList.SelectedIndex == 1) // check which type to dele
                    {
                        ClsBrand.BrandID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                        ClsBrand.RemoveBrand();
                    }
                    else if (cboList.SelectedIndex == 2)
                    {
                        ClsType.TypeID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                        ClsType.RemoveType();
                    }
                    else if (cboList.SelectedIndex == 3)
                    {
                        ClsDelivery.DeliveryID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                        ClsDelivery.DeleteDelivery();
                    }
                    MessageBox.Show("Successfully delete");
                    showData();
                }
            }
        }

        
    }
}
