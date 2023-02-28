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
    public partial class frmAddItem : Form
    {
        public frmAddItem()
        {
            InitializeComponent();
        }
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter(); //call a data set to use and modify data from database
        RentalDataSetTableAdapters.TypeTableAdapter objType = new RentalDataSetTableAdapters.TypeTableAdapter(); //call a data set to use and modify data from database
        private void frmAddItem_Load(object sender, EventArgs e)
        {
            AddBrandandCategory();    // call a method to add data to cboBrand and cboType
        }
        private void AddBrandandCategory()   // method to add data to cbo Brand and cbo type from the data base
        {
            DataTable DT = new DataTable();
            DT = objBrand.GetBrand();               // add the all the data from the Brand data set
            cboBrand.Items.Clear();                 //clear all data from cboBrand
            cboBrand.Items.Add("Select a Brand");   //add "Select a Brand" data to the cboBrand first
            foreach (DataRow dr in DT.Rows)    // looping to select all the data from DT to each row
            {
                cboBrand.Items.Add(dr[1]);     //add data from the DT to the cboBrand
            }
            DT.Clear();                        // clear all data from the DT
            DT = objType.GetType();            // add the all the data from the Type data set
            cboType.Items.Clear();             //clear all data from cboType
            cboType.Items.Add("Select a Type");     //add "Select a Type" data to the cboType first
            foreach (DataRow dr in DT.Rows)
            {
                cboType.Items.Add(dr[1]);
            }
            cboBrand.SelectedIndex= 0;
            cboType.SelectedIndex= 0;
        }
    }
}
