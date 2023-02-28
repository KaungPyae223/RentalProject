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
    public partial class frmBrandAdd : Form
    {
        public frmBrandAdd()
        {
            InitializeComponent();
        }
       
        RentalDataSetTableAdapters.BrandTableAdapter objBrand= new RentalDataSetTableAdapters.BrandTableAdapter(); //call a data set to use and modify data from database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtBrand.Text.Trim() == string.Empty)//check the Brand is empty or not
            {
                MessageBox.Show("Plese type a Brand", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                objBrand.Insert(txtBrandID.Text.Trim(),txtBrand.Text.Trim());
            }
        }

        private void frmBrandAdd_Load(object sender, EventArgs e)
        {
            AutoID(); // call a method to add ID
        }
        private void AutoID()
        {
            DataTable DT = new DataTable();
            DT = objBrand.GetBrand();
            if(DT.Rows.Count == 0) //check there is data in Database
            {
                txtBrandID.Text = "B-001";
            }
            else
            {
                int lastIndx = DT.Rows.Count- 1; //get the last Index
                string BrandID = DT.Rows[lastIndx][0].ToString(); //get the ID from last index
                string[] MakeID = BrandID.Split('-'); // split the ID by using split function from B and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1; // add the Id num from 001 to 002
                MakeID[1] = IDNum.ToString("000"); // get the ID number
                txtBrandID.Text = MakeID[0]+"-"+MakeID[1];

            }
        }
    }
}
