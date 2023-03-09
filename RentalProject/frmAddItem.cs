﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmAddItem : Form
    {
        public frmAddItem()
        {
            InitializeComponent();
        }

        string imgLocation = "";
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter(); //call a data set to use and modify data from database
        RentalDataSetTableAdapters.TypeTableAdapter objType = new RentalDataSetTableAdapters.TypeTableAdapter(); //call a data set to use and modify data from database
        RentalDataSetTableAdapters.ItemTableAdapter objItem = new RentalDataSetTableAdapters.ItemTableAdapter();
        private void frmAddItem_Load(object sender, EventArgs e)
        {
            AddBrandandCategory(objBrand.SP_SelectBrand(0), cboBrand);    // call a method to add data to cboBrand 
            AddBrandandCategory(objType.SP_SelectType(0), cboType);    // call a method to add data to cboType
        }
        private void AddBrandandCategory(DataTable DT,ComboBox cbo)   // method to add data to each combo box
        {
           
            DataRow dr = DT.NewRow();   // create a new row from DT
            dr[0] = "";                 // add data column index 0 of data row "dr"
            dr[1] = "Select a Data";    // add data column index 1 of data row "dr"
            DT.Rows.InsertAt(dr, 0);    // add data row "dr" to the DT at row index 0

            cbo.DataSource = DT;        // add all data from DT to combo box      
            cbo.DisplayMember= DT.Columns[1].ToString();    // to show data from the column index 1 in combo box
            cbo.ValueMember = DT.Columns[0].ToString();     
            cbo.SelectedValue="";  // make to select the item which have value ""
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckData();
            byte[] image = null;
            FileStream File = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(File);
            image = brs.ReadBytes((int)File.Length);
            
            if (MessageBox.Show("Sure to Save", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
            {
                string ID = MakeID();
                objItem.Insert(ID, cboBrand.SelectedValue.ToString(), cboType.SelectedValue.ToString(), txtItemName.Text.Trim(), txtPowerUsage.Text.Trim(), txtTypicalUsage.Text.Trim(), txtModelYear.Text.Trim(), Convert.ToInt32(txtOnHandQty.Text), Convert.ToInt32(txtPricePerMonth.Text), txtDescription.Text, image,Convert.ToInt32(txtOnHandQty.Text));
                MessageBox.Show("Successfully Save");
                this.Close();
            }

        }
        private string MakeID()
        {
            DataTable Dt = new DataTable();
            Dt = objItem.GetItem();
            if (Dt.Rows.Count == 0)  //check there is data or not in Database
            {
                return "I-00001";
            }
            else
            {
                int lastIndx = Dt.Rows.Count- 1;                    //get the last Index
                string BrandID = Dt.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from I and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from behind '-'
                MakeID[1] = IDNum.ToString("00000");                  // get the ID number
                return MakeID[0]+"-"+MakeID[1];
            }
        }
        private void CheckData()
        {
            int OK;
            if(txtItemName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Item Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemName.Focus();
            }
            else if(cboBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Plese select a Brand", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboType.SelectedIndex == 0)
            {
                MessageBox.Show("Plese select a Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPowerUsage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Power Usage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPowerUsage.Focus();
            }
            else if (txtTypicalUsage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Typical Usage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTypicalUsage.Focus();
            }
            else if (txtModelYear.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Model Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelYear.Focus();
            }
            else if (int.TryParse(txtModelYear.Text,out OK) == false || txtModelYear.TextLength != 4 || Convert.ToInt32(txtModelYear.Text)<2000 || Convert.ToInt32(txtModelYear.Text)>3000)
            {
                MessageBox.Show("The model year is wrong format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelYear.Focus();
            }
            else if (txtOnHandQty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a On Hand Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOnHandQty.Focus();
            }
            else if (int.TryParse(txtOnHandQty.Text, out OK) == false)
            {
                MessageBox.Show("The On Hand Qty is wrong format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOnHandQty.Focus();
            }
            else if (txtPricePerMonth.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Price Per Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPricePerMonth.Focus();
            }
            else if (int.TryParse(txtPricePerMonth.Text, out OK) == false )
            {
                MessageBox.Show("The Price Per Month is wrong format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPricePerMonth.Focus();
            }
            else if(txtDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFdiag = new OpenFileDialog();
            OFdiag.Filter = "Picture Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (OFdiag.ShowDialog() == DialogResult.OK)
            {
                imgLocation = OFdiag.FileName.ToString();
                ItemPicture.ImageLocation = imgLocation;
            }
        }
    }
}
