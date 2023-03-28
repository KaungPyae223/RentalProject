using RentalProject.Classes;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmCraft : Form
    {
        public frmCraft()
        {
            InitializeComponent();
        }
        int total = 0;  // calculate total qty
        int PricePerMont = 0;   // calculate total hire price per month
        Boolean FirstTime = true;
        clsItem obClsLsItem = new clsItem();
        private void frmCraft_Load(object sender, EventArgs e)
        {
            
            AddCraftItems();    // method to show items in craft
            FirstTime = false;  
        }
        
        public void AddCraftItems()
        {
            //looping all items in craft
            foreach (string ID in Program.Craft)   
            {

                DataTable DT = obClsLsItem.getSP_Item(ID, 0);   
                // select a item data from the data base with ID

                // add item data to the frmHomeItems and show on Craft
                frmHomeItems frm = new frmHomeItems(DT.Rows[0],true);
                frm.Width = ((label1.Width-26)/3)-6;
                frm.Margin= new Padding(3);
                frm.btnCraft.Text = "Cancel";
                frm.btnCraft.BackColor = Color.Orange;
                frm.btnCraft.ForeColor = Color.White;
                total ++;   // add 1 to get total Qty
                PricePerMont += Convert.ToInt32(DT.Rows[0][8]); 
                // add hire price per month to get total hire price per month

                if (FirstTime)  // check first time
                    loadform(frm);  // method to add form to the craft
            }
            lblTotalQty.Text = total.ToString();  // add total Qty to the craft
            lblPPM.Text = PricePerMont.ToString()+" £"; // add total Hire Qty to the craft
       
        
            /* 
                Disclaimer

                This method is also used for calculate total hir qty 
                and total Price per month. So, use first time boolean
                variable and when run this method first time, add form to 
                Craft main panel and when second time, only the calculation 
                make
             
             */
        
        }
        public void loadform(Form f)    // method to add form in CraftMainPanel
        {

            f.TopLevel = false;
            craftMainPanel.Controls.Add(f);
            craftMainPanel.Tag = f;
            f.Show();
        }

        
        // method if the control is removed
        private void craftMainPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            total = 0;
            PricePerMont = 0;
            
            AddCraftItems();
            // method to change the PricePerMonth and qty
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            if(craftMainPanel.Controls.Count > 0) // check ther is an item in craft
            {
                frmHire frm = new frmHire();    // call a hire form
                frm.Show();                     // show a hire form
                craftMainPanel.Controls.Clear();
                lblPPM.Text = "0 £";        
                lblTotalQty.Text = "0";
            }
            else
            {
                MessageBox.Show("There is no items in Craft", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
