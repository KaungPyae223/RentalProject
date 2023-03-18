using RentalProject.Classes;
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
    public partial class frmPaymentLists : Form
    {
        public frmPaymentLists()
        {
            InitializeComponent();
        }
        RentalTableAdapters.PaymentTableAdapter objPayment = new RentalTableAdapters.PaymentTableAdapter();
        clsPayment objclsPayment = new clsPayment();
        private void frmPaymentLists_Load(object sender, EventArgs e)
        {
           
            dgvPaymentList.DataSource = objclsPayment.getpayment();
            dgvPaymentList.Columns[0].Visible = false;
            dgvPaymentList.Columns[1].Width = (dgvPaymentList.Width/100)*13;
            dgvPaymentList.Columns[2].Width = (dgvPaymentList.Width/100)*13;
            dgvPaymentList.Columns[3].Width = (dgvPaymentList.Width/100)*15;
            dgvPaymentList.Columns[4].Width = (dgvPaymentList.Width/100)*15;
            dgvPaymentList.Columns[5].Width = (dgvPaymentList.Width/100)*25;
            dgvPaymentList.Columns[6].Width = (dgvPaymentList.Width/100)*10;
            dgvPaymentList.Columns[7].Width = (dgvPaymentList.Width/100)*15;
            dgvPaymentList.Columns[2].DisplayIndex=6;
        }

        private void txtHireID_TextChanged(object sender, EventArgs e)
        {
            dgvPaymentList.DataSource = objPayment.GetPaymentListByHireID(txtHireID.Text); 
        }
    }
}
