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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        public void loadform(Form f)
        {
            f.TopLevel = false;
            HomeMainPannel.Controls.Add(f);
            HomeMainPannel.Tag = f;
            f.Show();
            
        }
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter();
        RentalDataSetTableAdapters.TypeTableAdapter objType = new RentalDataSetTableAdapters.TypeTableAdapter();
        RentalDataSetTableAdapters.vi_ItemTableAdapter objItem = new RentalDataSetTableAdapters.vi_ItemTableAdapter();
        private void frmHome_Load(object sender, EventArgs e)
        {
            AddAppliaceItems();
            AddComboBox(objBrand.SP_SelectBrand(0),cboBrand);
            AddComboBox(objType.SP_SelectType(0), cboType);

        }
        private void AddComboBox(DataTable DT,ComboBox cbo)
        {
            DataRow DR = DT.NewRow();
            DR[0] = "";
            DR[1] = "All";
            DT.Rows.InsertAt(DR,0);
            cbo.DataSource= DT;
            cbo.DisplayMember = DT.Columns[1].ToString();
            cbo.ValueMember = DT.Columns[0].ToString();
            cbo.SelectedValue = "";

        }
        private void AddAppliaceItems()
        {
            DataTable DT = objItem.GetVi_Item();
            foreach (DataRow dr in DT.Rows)
            {
                frmHomeItems frm = new frmHomeItems(dr);
                frm.Width = ((label1.Width-26)/3)-6;
                frm.Margin= new Padding(3);

                loadform(frm);
            }
        }
        
    }
}
