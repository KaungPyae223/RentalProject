using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            AddComboBox(objclsBrand.GetSP_Brand(0), cboBrand);  // Add data to the combo box
            AddComboBox(objclsType.GetSP_GetType(0), cboType);
            
        }

        Boolean CanSearch = false;
        clsItem objclsitem = new clsItem();
        clsBrand objclsBrand = new clsBrand();
        clsType objclsType = new clsType();
        RentalTableAdapters.vi_ItemTableAdapter objvi_Item = new RentalTableAdapters.vi_ItemTableAdapter();
        private void frmHome_Load(object sender, EventArgs e)
        {
            AddAppliaceItems(objclsitem.GetItem()); 
            // call a method to add all items from database to the Home main panel

            cboBrand.SelectedValue = "";
            cboType.SelectedValue = "";
            CanSearch = true;
            Suggestion();

        }
        private void AddComboBox(DataTable DT, ComboBox cbo)  //method to add data to the combobox
        {
            DataRow DR = DT.NewRow();
            DR[0] = "";
            DR[1] = "All";
            DT.Rows.InsertAt(DR, 0);
            cbo.DataSource= DT;
            cbo.DisplayMember = DT.Columns[1].ToString();
            cbo.ValueMember = DT.Columns[0].ToString();
            

        }
        public void loadform(Form f) // method to add item to the home main panel
        {
            f.TopLevel = false;
            HomeMainPannel.Controls.Add(f);
            HomeMainPannel.Tag = f;
            f.Show();

        }
        private void AddAppliaceItems(DataTable DT) // method to all items
        {
            HomeMainPannel.Controls.Clear(); // clear all control in Home main panel
            foreach (DataRow dr in DT.Rows)
            {
                int OnHandQty = Convert.ToInt32(dr[7]);
                if (OnHandQty > 0)  // check it the item's on hand qty is if 0 do not show
                {
                    frmHomeItems frm = new frmHomeItems(dr, false); // call HomeItems form
                    
                    frm.Width = ((label1.Width-26)/3)-6;    
                    frm.Margin= new Padding(3);
                    // create form width and appearance

                    foreach (string ID in Program.Craft) // loop items in the craft
                    {
                        if (dr[0].ToString() == ID) // check item is same in the craft
                        {
                            frm.btnCraft.Text = "Cancel";
                            frm.btnCraft.BackColor = Color.Orange;
                            frm.btnCraft.ForeColor = Color.White;
                            // change the item appearance if in the craft

                        }

                    }
                    loadform(frm);  // call a method to add Item
                }
            }
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                int MaxPrice = (txtMaxPrice.Text == string.Empty) ? 9999 : Convert.ToInt32(txtMaxPrice.Text);
                DataTable dt = objvi_Item.GetDataByUserSeach(txtItemName.Text, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
                AddAppliaceItems(dt);   // change the items in home panel according to search
                Suggestion();   // call a method to give suggestion in item text box
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanSearch)
            { 
                int MaxPrice = (txtMaxPrice.Text == string.Empty)? 9999: Convert.ToInt32(txtMaxPrice.Text);
                DataTable dt = objvi_Item.GetDataByUserSeach(txtItemName.Text, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
                AddAppliaceItems(dt);
                Suggestion();
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                int MaxPrice = (txtMaxPrice.Text == string.Empty) ? 9999 : Convert.ToInt32(txtMaxPrice.Text);

                DataTable dt = objvi_Item.GetDataByUserSeach(txtItemName.Text, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
                AddAppliaceItems(dt);
            }
        }
        public void Suggestion()    // method to give suggestion
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection(); // call a autocomplete source
            int MaxPrice = (txtMaxPrice.Text == string.Empty) ? 9999 : Convert.ToInt32(txtMaxPrice.Text);
            DataTable DT = objvi_Item.GetDataByUserSeach("", cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
            if (DT.Rows.Count > 0)
            {
                txtItemName.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[3].ToString());   // add data to the auto complete source
                }
                txtItemName.AutoCompleteCustomSource = sourse;  // add source to the Item text box
                txtItemName.Text = "";
                txtItemName.Focus();
            }
            /* 
                
                Disclaimer
                    
                 To use the suggestion, at first, in text box change the properties like 
            
                AutoCompleteMode = Suggest 
                AutoCompleteSource = CustomSource
             
             */
        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            int Ok;

            // check in text box write except number
            if(int.TryParse(txtMaxPrice.Text,out Ok)== false && txtMaxPrice.Text != string.Empty)
            {
                MessageBox.Show("Plese type only a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaxPrice.Text = txtMaxPrice.Text.Remove(txtMaxPrice.Text.Length - 1,1);  // remove the last word that the user add not number
                
            }
            else
            {
                int MaxPrice = (txtMaxPrice.Text == string.Empty)? 9999: Convert.ToInt32(txtMaxPrice.Text);
                DataTable dt = objvi_Item.GetDataByUserSeach(txtItemName.Text, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
                AddAppliaceItems(dt);
                Suggestion();
            }
        }
    }
}
