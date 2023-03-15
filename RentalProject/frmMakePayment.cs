﻿using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmMakePayment : Form
    {
        public frmMakePayment(string HireID,DateTime OldDueDate)
        {
            InitializeComponent();
            this.HireID = HireID;
            this.OldDueDate = OldDueDate;
            DataTable DT = objHireDetails.GetDataByHireID(HireID);
            DataTable Item = new DataTable();
            Item.Columns.Add("Item Name");
            Item.Columns.Add("Price");
            foreach (DataRow dr in DT.Rows)
            {
                DataRow DRItem = Item.NewRow();
                DRItem[0] = dr[2].ToString();
                DRItem[1] = dr[3].ToString() + " £";
                totalPricePerMonth += Convert.ToInt32(dr[3]);
                Item.Rows.Add(DRItem);
            }
            DataRow DRTotal = Item.NewRow();
            DRTotal[0]="Total price per Month";
            DRTotal[1]=totalPricePerMonth.ToString() + " £";
            Item.Rows.Add(DRTotal);
            dgvPayment.DataSource = Item;
            dgvPayment.Columns[0].Width = (dgvPayment.Width/100)*75;
            dgvPayment.Columns[1].Width = (dgvPayment.Width/100)*35;
            lblToday.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblOldDueDate.Text = OldDueDate.ToString("dd MMMM yyyy");
            cboPaymentType.SelectedIndex = 0;
        }
        clsPayment objClsPayment = new clsPayment();
        clsHire objClsHire = new clsHire();
        RentalTableAdapters.vi_HireDetailsTableAdapter objHireDetails = new RentalTableAdapters.vi_HireDetailsTableAdapter();

        String HireID;
        int totalPricePerMonth = 0;
        int total = 0;
        int tax = 0;
        int GrandTotal = 0;
        DateTime OldDueDate;
        DateTime NewDueDate;
        private void frmMakePayment_Load(object sender, EventArgs e)
        {
            cboMonth.SelectedIndex = 0;
            dgvPayment.Rows[dgvPayment.Rows.Count- 2].DefaultCellStyle.BackColor= Color.Yellow;
            dgvPayment.Refresh();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            total = totalPricePerMonth*cboMonth.SelectedIndex;
            tax = (total/100)*5;
            if (tax < 5)
                tax = 5;
            if(total == 0) 
                tax = 0;
            GrandTotal = tax+total;
            lblTotalHireAmont.Text = total.ToString()+" £";
            lblTotalTax.Text = tax.ToString()+" £";
            lblGrandTotal.Text = GrandTotal.ToString()+" £";
            if(cboMonth.SelectedIndex == 0)
            {
                lblNewDueDate.Text = "";
            }
            else
            {
                NewDueDate = OldDueDate.AddMonths(cboMonth.SelectedIndex);
                lblNewDueDate.Text = NewDueDate.ToString("dd MMMM yyyy");
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Plese choose a extended month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cboPaymentType.SelectedIndex == 0)
            {
                MessageBox.Show("Plese choose a payment type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Sure to Hire all Appliances", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                {
                    objClsHire.DeadlineDate = NewDueDate;
                    objClsHire.HireID = HireID;
                    objClsHire.UpdateHire();
                    objClsPayment.Tax = tax;
                    objClsPayment.HireID = HireID;
                    objClsPayment.HireAmount = total;
                    objClsPayment.TotalPaymentAmont = GrandTotal;
                    objClsPayment.PaymentType = cboPaymentType.SelectedItem.ToString();
                    objClsPayment.Description = "Extended "+cboMonth.SelectedItem.ToString();
                    objClsPayment.AddPayment();
                    MessageBox.Show("Successfully Make a Payment. \nPlease check an due date");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}