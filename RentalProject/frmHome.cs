using RentalProject.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            AddComboBox(objclsBrand.GetSP_Brand(0), cboBrand);
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
            cboBrand.SelectedValue = "";
            cboType.SelectedValue = "";
            CanSearch = true;
            Suggestion();

        }
        private void AddComboBox(DataTable DT, ComboBox cbo)
        {
            DataRow DR = DT.NewRow();
            DR[0] = "";
            DR[1] = "All";
            DT.Rows.InsertAt(DR, 0);
            cbo.DataSource= DT;
            cbo.DisplayMember = DT.Columns[1].ToString();
            cbo.ValueMember = DT.Columns[0].ToString();
            

        }
        public void loadform(Form f)
        {
            f.TopLevel = false;
            HomeMainPannel.Controls.Add(f);
            HomeMainPannel.Tag = f;
            f.Show();

        }
        private void AddAppliaceItems(DataTable DT)
        {
            HomeMainPannel.Controls.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                int OnHandQty = Convert.ToInt32(dr[7]);
                if (OnHandQty > 0)
                {
                    frmHomeItems frm = new frmHomeItems(dr, false);
                    frm.Width = ((label1.Width-26)/3)-6;
                    frm.Margin= new Padding(3);
                    foreach (string ID in Program.Craft)
                    {
                        if (dr[0].ToString() == ID)
                            frm.btnCraft.Text = "Cancel";
                    }
                    loadform(frm);
                }
            }
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                int MaxPrice = (txtMaxPrice.Text == string.Empty) ? 9999 : Convert.ToInt32(txtMaxPrice.Text);
                DataTable dt = objvi_Item.GetDataByUserSeach(txtItemName.Text, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
                AddAppliaceItems(dt);
                Suggestion();
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
        public void Suggestion()
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            int MaxPrice = (txtMaxPrice.Text == string.Empty) ? 9999 : Convert.ToInt32(txtMaxPrice.Text);
            DataTable DT = objvi_Item.GetDataByUserSeach("", cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), MaxPrice);
            if (DT.Rows.Count > 0)
            {
                txtItemName.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[3].ToString());
                }
                txtItemName.AutoCompleteCustomSource = sourse;
                txtItemName.Text = "";
                txtItemName.Focus();
            }
        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            int Ok;
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
