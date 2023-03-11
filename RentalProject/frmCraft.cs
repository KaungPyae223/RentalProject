using RentalProject.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmCraft : Form
    {
        public frmCraft()
        {
            InitializeComponent();
        }
        int total = 0;
        int PricePerMont = 0;
        Boolean FirstTime = true;
        clsItem obClsLsItem = new clsItem();
        private void frmCraft_Load(object sender, EventArgs e)
        {
            
            AddCraftItems();
            FirstTime = false;
        }
        
        public void AddCraftItems()
        {
            foreach (string ID in Program.Craft)
            {

                DataTable DT = obClsLsItem.getSP_Item(ID, 0);
                frmHomeItems frm = new frmHomeItems(DT.Rows[0],true);
                frm.Width = ((label1.Width-26)/3)-6;
                frm.Margin= new Padding(3);
                frm.btnCraft.Text = "Cancel";
                
                total ++;
                PricePerMont += Convert.ToInt32(DT.Rows[0][8]);

                if (FirstTime)
                    loadform(frm);
            }
            lblTotalQty.Text = total.ToString();
            lblPPM.Text = PricePerMont.ToString()+" £";
        }
        public void loadform(Form f)
        {

            f.TopLevel = false;
            craftMainPanel.Controls.Add(f);
            craftMainPanel.Tag = f;
            f.Show();
        }

        

        private void craftMainPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            total = 0;
            PricePerMont = 0;
            
            AddCraftItems();
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            frmHire frm = new frmHire();
            frm.Show();
        }
    }
}
