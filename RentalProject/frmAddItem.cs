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
            MessageBox.Show(cboBrand.SelectedValue.ToString());
        }
    }
}
