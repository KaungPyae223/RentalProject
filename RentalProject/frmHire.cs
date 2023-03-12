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
            DataTable DT = objClsDelivery.GetDelivery();
            cboDelivery.DataSource = DT;
            cboDelivery.DisplayMember = DT.Columns[1].ColumnName;
            cboDelivery.ValueMember = DT.Columns[0].ColumnName;
            cboDelivery.SelectedIndex = 0;
            lblToday.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            DataTable Customer = Program.DT;
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
            DataTable Date = objDate.GetDate(DateTime.Now, 3);
            lblDeadLine.Text = Convert.ToDateTime(Date.Rows[0][0]).ToString("dd-MMMM-yyyy");
        }

        RentalTableAdapters.SP_ExtendedDateTableAdapter objDate = new RentalTableAdapters.SP_ExtendedDateTableAdapter();
        clsCustomer objClsCustomer = new clsCustomer();
        clsDelivery objClsDelivery = new clsDelivery();
        clsItem objClsItem = new clsItem();
        private void frmHire_Load(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            Item.Columns.Add("Item Name");
            Item.Columns.Add("Price");
            int Total = 0;
            int Quantity = 0;
            foreach (string ID in Program.Craft)
            {
                Quantity++;
                DataTable DT = objClsItem.getSP_Item(ID, 0);
                string Name = DT.Rows[0][3].ToString();
                string Price = DT.Rows[0][8].ToString()+ " £";
                Total += Convert.ToInt32(DT.Rows[0][8]);
                DataRow ItemDR = Item.NewRow();
                ItemDR["Item Name"]=Name;
                ItemDR["Price"]=Price;
                Item.Rows.Add(ItemDR);
            }
            DataRow DR = Item.NewRow();
            DR["Item Name"]="Total Hire Price Per Month";
            DR["Price"]=Total.ToString()+" £";
            Item.Rows.Add(DR);
            dgvItem.DataSource = Item;
            dgvItem.Columns[1].Width = (dgvItem.Width/100)*30;
            dgvItem.Columns[0].Width = (dgvItem.Width/100)*70;
            dgvItem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItem.Rows[dgvItem.Rows.Count- 2].DefaultCellStyle.BackColor= Color.Yellow;
            lblTotalQty.Text = Quantity.ToString();
            lblDeliveryCost.Text = (Quantity*25).ToString()+" £";
            lblInsuranceCost.Text = (Total*6).ToString()+" £";
            lblTotalHirePrice.Text = (Total*3).ToString()+" £";
            int MainTotal = ((Total*9)+(Quantity*25));
            int Tax = (MainTotal/100)*5;
            lblTax.Text = Tax.ToString()+" £";
            lblTotal.Text = (MainTotal+Tax).ToString()+" £";
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            if(txtLocation.Text == string.Empty)
            {
                MessageBox.Show("Plese type a Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
            }
            else if(txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Plese type a Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
            }
            else if(cboPayment.SelectedIndex == 0)
            {
                MessageBox.Show("Plese Select a payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if(txtAggree.Text != "I aggree with all")
            {
                MessageBox.Show("Plese type a \"I aggree with all\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAggree.Focus();
            }
            else
            {

            }
        }
    }
}
