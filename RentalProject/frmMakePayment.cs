using RentalProject.Classes;
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
            // add data to the Payment form
            InitializeComponent();
            this.HireID = HireID;
            this.OldDueDate = OldDueDate;
            DataTable DT = objHireDetails.GetDataByHireID(HireID);
            DataTable Item = new DataTable();
            Item.Columns.Add("Item Name");
            Item.Columns.Add("Price");
            // add hire items to the form
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
            // design the item grid view

            // chage the date time format
            lblToday.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblOldDueDate.Text = OldDueDate.ToString("dd MMMM yyyy");
            cboPaymentType.SelectedIndex = 0;
            lblHireID.Text = HireID;
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
            dgvPayment.Rows[dgvPayment.Rows.Count- 1].DefaultCellStyle.BackColor= Color.Yellow;
            dgvPayment.Refresh();
        }

        // method when the month selected inedx change, due date and total cost auto calculate
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
            if (cboMonth.SelectedIndex == 0) // check Month is select or not
            {
                MessageBox.Show("Plese choose a extended month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cboPaymentType.SelectedIndex == 0) // check payment type select or not
            {
                MessageBox.Show("Plese choose a payment type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Sure to Hire all Appliances", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                {
                    try
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
