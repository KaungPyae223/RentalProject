using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmDelivery : Form
    {
        public frmDelivery()
        {
            InitializeComponent();
        }
        RentalDataSetTableAdapters.DeliveryTableAdapter objDelivery = new RentalDataSetTableAdapters.DeliveryTableAdapter();

        private void frmDelivery_Load(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = objDelivery.GetDelivery();
            if (Dt.Rows.Count == 0)  //check there is data or not in Database
            {
                txtDeliveryID.Text = "D-001";
            }
            else
            {
                int lastIndx = Dt.Rows.Count- 1;                    //get the last Index
                string BrandID = Dt.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from B and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from 001 to 002
                MakeID[1] = IDNum.ToString("000");                  // get the ID number
                txtDeliveryID.Text = MakeID[0]+"-"+MakeID[1];
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtDeliveryName.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Plese type Delivery Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeliveryName.Focus();
            }
            else if (txtDeliveryPhone.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type Delivery Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeliveryPhone.Focus();
            }
            else
            {
                if (MessageBox.Show("Sure to Save", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                {
                    
                    objDelivery.Insert(txtDeliveryID.Text,txtDeliveryName.Text.Trim(), txtDeliveryPhone.Text.Trim());
                    MessageBox.Show("Successfully Save");
                    this.Close();
                }
            }
        }
    }
}
