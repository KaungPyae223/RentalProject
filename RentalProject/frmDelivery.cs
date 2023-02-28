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
            txtDeliveryID.Text = "D-"+(Dt.Rows.Count+1).ToString("000"); //auto ID add to the txtDeliveryID
            
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
