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
using RentalProject.Classes;

namespace RentalProject
{
    public partial class frmDelivery : Form
    {
        public frmDelivery(Boolean IsEdit)
        {
            InitializeComponent();
            this.IsEdit = IsEdit;
        }

        RentalTableAdapters.DeliveryTableAdapter objDelivery = new RentalTableAdapters.DeliveryTableAdapter();
        private Boolean IsEdit = false;
        clsDelivery ClsDelivery = new clsDelivery();
        private void frmDelivery_Load(object sender, EventArgs e)
        {
            if(!IsEdit)
            {
                AddID();
            }

        }
        private void AddID()
        {
            DataTable Dt = new DataTable();
            Dt = ClsDelivery.GetDelivery();
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
                if(IsEdit)
                {
                    if (MessageBox.Show("Sure to Edit", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                    {
                        AddData();
                        ClsDelivery.EditDelivery();
                        MessageBox.Show("Successfully Edit");
                        this.Close();
                    }
                }
                else
                {
                    DataTable DT = new DataTable();
                    DT = objDelivery.CheckDelivery(txtDeliveryName.Text.Trim());
                    if(DT.Rows.Count == 0 ) 
                    {
                        if (MessageBox.Show("Sure to Save", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                        {
                            AddData();
                            ClsDelivery.AddDelivery();
                            MessageBox.Show("Successfully Save");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Delvery is already exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                
            }
        }
        private void AddData()
        {
            ClsDelivery.DeliveryID = txtDeliveryID.Text.Trim();
            ClsDelivery.DeliveryName = txtDeliveryName.Text.Trim();
            ClsDelivery.DeliveryPhone = txtDeliveryPhone.Text.Trim();
        }
        
    }
}
