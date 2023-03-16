using RentalProject.Classes;
using System;
using System.IO;
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
            showData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            frmAddItem frm = new frmAddItem(false);
            frm.ShowDialog();
            showData();

        }

        private void showData() //method to show the data in data grid view
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

            dgvBrand.Columns.Clear();
            dgvBrand.DataSource= ClsBrand.GetBrand();
            dgvBrand.Columns[0].Width = (dgvBrand.Width/100)* 20;
            dgvBrand.Columns[1].Width = (dgvBrand.Width/100)* 80;

            dgvType.Columns.Clear();
            dgvType.DataSource= ClsType.GetType();
            dgvType.Columns[0].Width = (dgvType.Width/100)* 20;
            dgvType.Columns[1].Width = (dgvType.Width/100)* 80;

            dgvDelivery.Columns.Clear();
            dgvDelivery.DataSource= ClsDelivery.GetDelivery();
            dgvDelivery.Columns[0].Width = (dgvDelivery.Width/100)* 20;
            dgvDelivery.Columns[1].Width = (dgvDelivery.Width/100)* 40;
            dgvDelivery.Columns[2].Width = (dgvDelivery.Width/100)* 40;

            dgvItem.Refresh();
            dgvBrand.Refresh();
            dgvType.Refresh();
            dgvDelivery.Refresh();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvItem.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmAddItem frm = new frmAddItem(true);
                frm.image = (byte[])(dgvItem.CurrentRow.Cells[10].Value);
                frm.txtItemName.Text = dgvItem.CurrentRow.Cells[3].Value.ToString();
                frm.cboBrand.SelectedValue = dgvItem.CurrentRow.Cells[1].Value.ToString();
                frm.cboType.SelectedValue = dgvItem.CurrentRow.Cells[2].Value.ToString();
                frm.txtPowerUsage.Text = dgvItem.CurrentRow.Cells[4].Value.ToString();
                frm.txtTypicalUsage.Text = dgvItem.CurrentRow.Cells[5].Value.ToString();
                frm.txtModelYear.Text = dgvItem.CurrentRow.Cells[6].Value.ToString();
                frm.txtTotalQty.Text = dgvItem.CurrentRow.Cells[11].Value.ToString();
                frm.txtPricePerMonth.Text = dgvItem.CurrentRow.Cells[8].Value.ToString();
                frm.txtDescription.Text = dgvItem.CurrentRow.Cells[9].Value.ToString();
                frm.ID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                frm.OnHandQty = Convert.ToInt32(dgvItem.CurrentRow.Cells[7].Value);
                frm.OnHandQty = Convert.ToInt32(dgvItem.CurrentRow.Cells[11].Value);

                frm.btnSave.Text = "Edit";
                frm.ShowDialog();
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
                
            }
        }

        private void tsbBrandNew_Click(object sender, EventArgs e)
        {
            frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(true, false);
            frm.ShowDialog();
            showData();
        }

        private void tsbTypeNew_Click(object sender, EventArgs e)
        {
            frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(false, false);
            frm.ShowDialog();
            showData();
        }

        private void tsbDeliveryNew_Click(object sender, EventArgs e)
        {
            frmDelivery frm = new frmDelivery(false);
            frm.ShowDialog();
            showData();
        }

        private void tsbBrandEdit_Click(object sender, EventArgs e)
        {
            if (dgvBrand.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(true, true);
                frm.txtID.Text = dgvBrand.CurrentRow.Cells[0].Value.ToString();
                frm.txtName.Text = dgvBrand.CurrentRow.Cells[1].Value.ToString();
                frm.btnAdd.Text = "Edit";
                frm.ShowDialog();
                showData();
            }
        }

        private void tsbTypeEdit_Click(object sender, EventArgs e)
        {
            if (dgvType.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmBrandandCategoryAdd frm = new frmBrandandCategoryAdd(false, true);
                frm.txtID.Text = dgvType.CurrentRow.Cells[0].Value.ToString();
                frm.txtName.Text = dgvType.CurrentRow.Cells[1].Value.ToString();
                frm.btnAdd.Text = "Edit";
                frm.ShowDialog();
                showData();
            }
        }

        private void tsbDeliveryEdit_Click(object sender, EventArgs e)
        {
            if (dgvDelivery.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmDelivery frm = new frmDelivery(true);
                frm.txtDeliveryID.Text = dgvDelivery.CurrentRow.Cells[0].Value.ToString();
                frm.txtDeliveryName.Text = dgvDelivery.CurrentRow.Cells[1].Value.ToString();
                frm.txtDeliveryPhone.Text = dgvDelivery.CurrentRow.Cells[2].Value.ToString();
                frm.btnSave.Text = "Edit";
                frm.ShowDialog();
                showData();
            }
        }

        private void tsbBrandDelete_Click(object sender, EventArgs e)
        {
            if (dgvBrand.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to delete or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                {
                    ClsBrand.BrandID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    ClsBrand.RemoveBrand();
                    showData();
                }
            }
        }

        private void tsbTypeDelete_Click(object sender, EventArgs e)
        {
            if (dgvType.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to delte or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                {
                    ClsType.TypeID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    ClsType.RemoveType();
                    showData();
                }
            }
        }

        private void tsbDeliveryDelete_Click(object sender, EventArgs e)
        {
            if (dgvDelivery.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to delte or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                {
                    ClsDelivery.DeliveryID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                    ClsDelivery.DeleteDelivery();
                    showData();
                }
            }
        }
    }
}
