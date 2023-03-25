using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
            dgvItem.Columns.Clear();
            dgvItem.DataSource= objClsItem.GetItem();
            cboSearch.SelectedIndex = 0;
        }
        clsBrand objClsBrand = new clsBrand();
        clsType objClsType = new clsType();
        clsDelivery objClsDelivery = new clsDelivery();
        clsItem objClsItem = new clsItem();
        RentalTableAdapters.HireDetailsTableAdapter objHire = new RentalTableAdapters.HireDetailsTableAdapter();
        RentalTableAdapters.ItemTableAdapter objItem = new RentalTableAdapters.ItemTableAdapter();
        private void frmItems_Load(object sender, EventArgs e)
        {
            showData();
            MakeColor();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            frmAddItem frm = new frmAddItem(false);
            frm.ShowDialog();
            dgvItem.DataSource= objClsItem.GetItem();
            showData();
            MakeColor();
        }

        private void showData() //method to show the data in data grid view
        {
            // design the Item grid view
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

            // design the Brand grid view
            dgvBrand.Columns.Clear();
            dgvBrand.DataSource= objClsBrand.GetBrand();
            dgvBrand.Columns[0].Width = (dgvBrand.Width/100)* 20;
            dgvBrand.Columns[1].Width = (dgvBrand.Width/100)* 80;

            // design the Type grid view
            dgvType.Columns.Clear();
            dgvType.DataSource= objClsType.GetType();
            dgvType.Columns[0].Width = (dgvType.Width/100)* 20;
            dgvType.Columns[1].Width = (dgvType.Width/100)* 80;

            // design the Delivery grid view
            dgvDelivery.Columns.Clear();
            dgvDelivery.DataSource= objClsDelivery.GetDelivery();
            dgvDelivery.Columns[0].Width = (dgvDelivery.Width/100)* 20;
            dgvDelivery.Columns[1].Width = (dgvDelivery.Width/100)* 40;
            dgvDelivery.Columns[2].Width = (dgvDelivery.Width/100)* 40;

            dgvItem.Refresh();
            dgvBrand.Refresh();
            dgvType.Refresh();
            dgvDelivery.Refresh();
        }
        private void MakeColor()  // make color red if the item has on hand qty 0
        {
            for (int i = 0; i< dgvItem.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) == 0)
                {
                    dgvItem.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dgvItem.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvItem.CurrentRow.Cells[0].Value.ToString() == string.Empty) // check the user choose which data to update or not
            {
                MessageBox.Show("Plese select a row to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // add data to the item add form to edit
                frmAddItem frm = new frmAddItem(true);
                frm.image = (byte[])(dgvItem.CurrentRow.Cells[10].Value);
                frm.txtItemName.Text = dgvItem.CurrentRow.Cells[3].Value.ToString();
                frm.cboBrand.SelectedValue = dgvItem.CurrentRow.Cells[1].Value.ToString();
                frm.cboType.SelectedValue = dgvItem.CurrentRow.Cells[2].Value.ToString();
                frm.txtPowerUsage.Text = dgvItem.CurrentRow.Cells[4].Value.ToString();
                frm.txtTypicalUsage.Text = dgvItem.CurrentRow.Cells[5].Value.ToString();
                frm.txtModelYear.Text = dgvItem.CurrentRow.Cells[6].Value.ToString();
                frm.txtTotalQty.Text = dgvItem.CurrentRow.Cells[13].Value.ToString();
                frm.txtPricePerMonth.Text = dgvItem.CurrentRow.Cells[8].Value.ToString();
                frm.txtDescription.Text = dgvItem.CurrentRow.Cells[9].Value.ToString();
                frm.ID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                frm.OnHandQty = Convert.ToInt32(dgvItem.CurrentRow.Cells[7].Value);
                frm.TotalQty = Convert.ToInt32(dgvItem.CurrentRow.Cells[13].Value);
                frm.btnSave.Text = "Edit";
                frm.ShowDialog();
                dgvItem.DataSource= objClsItem.GetItem();
                MakeColor();
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
                DataTable DT = new DataTable();
                DT = objHire.CheckItem(dgvItem.CurrentRow.Cells[0].Value.ToString());
                if (DT.Rows.Count == 0)
                {
                    if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                    {
                        objClsItem.DeleteItems(dgvItem.CurrentRow.Cells[0].Value.ToString());
                        
                        dgvItem.DataSource= objClsItem.GetItem();
                        MakeColor();
                        MessageBox.Show("Successfully delete");
                    }
                }
                else
                {
                    MessageBox.Show("This Item is already hire", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
                DataTable DT = new DataTable();
                DT = objItem.ChecktoDelete(dgvBrand.CurrentRow.Cells[0].Value.ToString(), dgvBrand.CurrentRow.Cells[0].Value.ToString());
                if (DT.Rows.Count == 0)
                {
                    if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                    {
                        objClsBrand.BrandID = dgvBrand.CurrentRow.Cells[0].Value.ToString();
                        objClsBrand.RemoveBrand();
                        showData();
                        dgvBrand.DataSource= objClsBrand.GetBrand();

                    }
                }
                else
                {
                    MessageBox.Show("The Brand is used in Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                DataTable DT = new DataTable();
                DT = objItem.ChecktoDelete(dgvType.CurrentRow.Cells[0].Value.ToString(), dgvType.CurrentRow.Cells[0].Value.ToString());
                if (DT.Rows.Count == 0)
                {
                    if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                    {
                        objClsType.TypeID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                        objClsType.RemoveType();
                        showData();
                    }
                }
                else
                {
                    MessageBox.Show("The type is already used in Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable DT = new DataTable();
                DT = objClsDelivery.CheckDelivery(dgvDelivery.CurrentRow.Cells[0].Value.ToString());
                if (DT.Rows.Count == 0)
                {
                    if (MessageBox.Show("Sure to Delete", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to delte
                    {
                        objClsDelivery.DeliveryID = dgvItem.CurrentRow.Cells[0].Value.ToString();
                        objClsDelivery.DeleteDelivery();
                        showData();
                    }
                }
                else
                {
                    MessageBox.Show("The delivery is already used in Hire", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvItem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }

        // method to change the suggestion according to the combobox select
        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                Suggestion("ItemName");
            }
            else if (cboSearch.SelectedIndex == 1)
            {
                Suggestion("NameOfType");
            }
            if (cboSearch.SelectedIndex == 2)
            {
                Suggestion("BrandName");
            }
            txtSearch.Text = "";
        }

        // add suggestion to the item name txt
        public void Suggestion(string FieldName)
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            DataTable DT = objClsItem.GetItem();

            if (DT.Rows.Count > 0)
            {
                txtSearch.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[FieldName].ToString());
                }
                txtSearch.AutoCompleteCustomSource = sourse;
                txtSearch.Text = "";
                txtSearch.Focus();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            dgvItem.DataSource = objClsItem.ItemSearch(cboSearch.SelectedIndex, txtSearch.Text);
            MakeColor();
        }


    }
}
