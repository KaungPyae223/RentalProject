using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHire : Form
    {
        public frmHire()
        {
            InitializeComponent();

            // Add delivery data to the cboDelivery
            DataTable DT = objClsDelivery.GetDelivery();
            cboDelivery.DataSource = DT;
            cboDelivery.DisplayMember = DT.Columns[1].ColumnName;
            cboDelivery.ValueMember = DT.Columns[0].ColumnName;
            cboDelivery.SelectedIndex = 0;

            // Add data to the form
            lblToday.Text = DateTime.Now.ToString("dd MMMM yyyy");
            DataTable Customer = Program.DT; // customer data to the form
            lblName.Text = Customer.Rows[0][3].ToString();
            lblEmail.Text = Customer.Rows[0][5].ToString();
            lblCustomerID.Text = Customer.Rows[0][0].ToString();
            lblNRC.Text = Customer.Rows[0][7].ToString();
            txtLocation.Text = Customer.Rows[0][4].ToString();
            txtPhone.Text = Customer.Rows[0][6].ToString();
            if (Customer.Rows[0]["CustomerPhoto"].ToString() != string.Empty)
            {
                byte[] img = (byte[])(Customer.Rows[0]["CustomerPhoto"]);
                MemoryStream ms = new MemoryStream(img);
                CustomrePicture.Image = Image.FromStream(ms);
            }
            cboPayment.SelectedIndex = 0;

            // add deadline day
            DateTime DeadLine = DateTime.Now.AddMonths(3);
            lblDeadLine.Text = DeadLine.ToString("dd MMMM yyyy");

            // add ID
            DataTable Dt = new DataTable();
            Dt = objClsHire.GetHireList();
            if (Dt.Rows.Count == 0)  //check there is data or not in Database
            {
                lblHireID.Text = "H-0000001";
            }
            else
            {
                int lastIndx = Dt.Rows.Count- 1;                    //get the last Index
                string BrandID = Dt.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from I and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from behind '-'
                MakeID[1] = IDNum.ToString("0000000");              // get the ID number
                lblHireID.Text = MakeID[0]+"-"+MakeID[1];
            }
        }
        int Quantity = 0;
        int Total = 0;
        int MainTotal;
        clsCustomer objClsCustomer = new clsCustomer();
        clsDelivery objClsDelivery = new clsDelivery();
        clsItem objClsItem = new clsItem();
        clsHire objClsHire = new clsHire();
        clsPayment objClsPayment = new clsPayment();
        clsHieDetails objClsHireDetails = new clsHieDetails();
        private void frmHire_Load(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            Item.Columns.Add("Item Name");
            Item.Columns.Add("Price");

            // Add hite Items in the form
            foreach (string ID in Program.Craft)
            {
                Quantity++;
                DataTable DT = objClsItem.getSP_Item(ID, 0);
                string Name = DT.Rows[0][3].ToString();
                string Price = DT.Rows[0][8].ToString()+ " £";
                Total += Convert.ToInt32(DT.Rows[0][8]); // calculate total price per month
                DataRow ItemDR = Item.NewRow();
                ItemDR["Item Name"]=Name;
                ItemDR["Price"]=Price;
                Item.Rows.Add(ItemDR);
            }

            // add total hire qty to the table
            DataRow DR = Item.NewRow();
            DR["Item Name"]="Total Hire Price Per Month";
            DR["Price"]=Total.ToString()+" £";
            Item.Rows.Add(DR);

            // Add data from the data table Item to the dgvItem to show 
            dgvItem.DataSource = Item;
            dgvItem.Columns[1].Width = (dgvItem.Width/100)*30;
            dgvItem.Columns[0].Width = (dgvItem.Width/100)*70;
            dgvItem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItem.Rows[dgvItem.Rows.Count-1].DefaultCellStyle.BackColor= Color.Yellow;
            
            // show the prices in the form
            lblTotalQty.Text = Quantity.ToString();
            lblDeliveryCost.Text = (Quantity*25).ToString()+" £";
            lblInsuranceCost.Text = (Total*6).ToString()+" £";
            lblTotalHirePrice.Text = (Total*3).ToString()+" £";
            MainTotal = ((Total*9)+(Quantity*25));
            int Tax = (MainTotal/100)*5;
            lblTax.Text = Tax.ToString()+" £";
            lblTotal.Text = (MainTotal+Tax).ToString()+" £";
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text == string.Empty)   // check location is empty
            {
                MessageBox.Show("Plese type a Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
            }
            else if (txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Plese type a Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
            }
            else if (cboPayment.SelectedIndex == 0) // check cboPayment is not selected
            {
                MessageBox.Show("Plese choose a payment type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtAggree.Text != "I agree with all")
            {
                MessageBox.Show("Plese type a \"I agree with all\" ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAggree.Focus();
            }
            else
            {

                if (MessageBox.Show("Sure to Hire all Appliances", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
                {
                    try
                    {
                        saveData();
                        objClsHire.SaveHire();
                        foreach (string ID in Program.Craft) // loop items to change On Hand Qty
                        {

                            objClsHireDetails.ItemID = ID;
                            objClsHireDetails.HireID = lblHireID.Text;
                            objClsHireDetails.AddHireDetails();
                            DataTable DT = objClsItem.getSP_Item(ID, 0);
                            int OnHandQty = Convert.ToInt32(DT.Rows[0][7])-1;

                            objClsItem.UpdateOnHandQty(OnHandQty, ID); // update on Hand Qty

                        }
                        objClsPayment.AddPayment();
                        MessageBox.Show("Successfully Hire the Home Appliances \nThe Home appliances will deliver to your location within one week", "Successfully Hire");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        public void saveData() // method to save data to the class Hire
        {
            objClsHire.CustomerID = lblCustomerID.Text;
            objClsHire.HireID = lblHireID.Text;
            objClsHire.DeliveryID = cboDelivery.SelectedValue.ToString();
            objClsHire.HireLocation = txtLocation.Text;
            objClsHire.CustomerPhone = txtPhone.Text;
            objClsHire.DeliveryCost = (Quantity*25);
            objClsHire.TotalHirePricePerMonth = Total;
            objClsHire.InsuranceCost = (Total*6);
            objClsHire.TotalHireQty = Quantity;
            objClsPayment.Tax =  (MainTotal/100)*5;
            objClsPayment.Description = "New Hire with 3 monthes extended";
            objClsPayment.HireID = lblHireID.Text;
            objClsPayment.PaymentType = cboPayment.SelectedItem.ToString();
            objClsPayment.HireAmount = MainTotal;
            objClsPayment.TotalPaymentAmont = MainTotal+(MainTotal/100)*5;


        }
    }
}
