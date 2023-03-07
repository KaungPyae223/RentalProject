using RentalProject.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmBrandandCategoryAdd : Form
    {
        public frmBrandandCategoryAdd(Boolean kind, Boolean IsEdit)
        {

            InitializeComponent();
            this.kind=kind;
            this.IsEdit=IsEdit;
            lblBrand.Text = (kind) ? "Brand" : "Type";          //check and add the appropriate label
            lblBrandID.Text = (kind) ? "Brand ID" : "Type ID";  //check and add the appropriate label
            btnAdd.Text = (IsEdit) ? "Edit" : "Add";
        }

        private Boolean kind;       // make a parameter to know to modify type or brand
        private Boolean IsEdit;     // make a parameter to know edit or add

        clsBrand ClsBrand = new clsBrand();
        clsType ClsType = new clsType();

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == string.Empty)       //check the Brand is empty or not
            {
                MessageBox.Show("Plese type a Brand", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                if (IsEdit)
                {
                    if (MessageBox.Show("Sure to Edit", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                    {
                        if (kind)   // check the kind and add data to appropriate database 
                        {
                            AddData();
                            ClsBrand.EditBrand();
                        }
                        else
                        {
                            AddData();
                            ClsType.EditType();
                        }

                        MessageBox.Show("Successfully Edit");
                        this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("Sure to Save", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                    {
                        if (kind)   // check the kind and add data to appropriate database 
                        {
                            AddData();
                            ClsBrand.AddBrand();
                        }
                        else
                        {
                            AddData();
                            ClsType.AddType();
                        }

                        MessageBox.Show("Successfully saved");
                        this.Close();
                    }
                }

            }
        }

        private void frmBrandAdd_Load(object sender, EventArgs e)
        {
            if (!IsEdit)
                AutoID();   // call a method to add ID
        }
        private void AutoID()
        {
            DataTable DT = new DataTable();


            if (kind)   // check which ID to add
                DT = ClsBrand.GetBrand();
            else
                DT = ClsType.GetType();


            if (DT.Rows.Count == 0)  //check there is data or not in Database
            {
                txtID.Text = (kind) ? "B-001" : "T-001"; // check the which type of the ID to add and add the appropriate ID to txtBrand
            }
            else
            {
                int lastIndx = DT.Rows.Count- 1;                    //get the last Index
                string BrandID = DT.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from B and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from 001 to 002
                MakeID[1] = IDNum.ToString("000");                  // get the ID number
                txtID.Text = MakeID[0]+"-"+MakeID[1];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddData()
        {
            if (kind)
            {
                ClsBrand.BrandID = txtID.Text.Trim();
                ClsBrand.BrandName = txtName.Text.Trim();
            }
            else
            {
                ClsType.TypeID = txtID.Text.Trim();
                ClsType.NameOfType = txtName.Text.Trim();
            }
        }
    }
}
