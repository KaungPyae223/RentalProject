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
        RentalDataSetTableAdapters.vi_ItemTableAdapter objItem = new RentalDataSetTableAdapters.vi_ItemTableAdapter();
        private void frmCraft_Load(object sender, EventArgs e)
        {
            AddAppliaceItems();

        }
        private void AddAppliaceItems()
        {
            foreach (string ID in Program.Craft)
            {

                DataTable DT = objItem.GetSP_Item(ID, 0);
                frmHomeItems frm = new frmHomeItems(DT.Rows[0]);
                frm.Width = ((label1.Width-26)/3)-6;
                frm.Margin= new Padding(3);
                frm.btnCraft.Text = "Cancel";
                loadform(frm);
            }
        }
        public void loadform(Form f)
        {
            f.TopLevel = false;
            craftMainPanel.Controls.Add(f);
            craftMainPanel.Tag = f;
            f.Show();
        }
    }
}
