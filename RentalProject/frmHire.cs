using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
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
        }
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
    }
}
