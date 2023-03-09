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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        clsItem objclsitem = new clsItem();
        clsBrand objclsBrand = new clsBrand();
        clsType objclsType = new clsType();
         private void frmHome_Load(object sender, EventArgs e)
        {
            AddAppliaceItems();
            AddComboBox(objclsBrand.GetSP_Brand(0),cboBrand);
            AddComboBox(objclsType.GetSP_GetType(0), cboType);

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
        public void loadform(Form f)
        {
            f.TopLevel = false;
            HomeMainPannel.Controls.Add(f);
            HomeMainPannel.Tag = f;
            f.Show();

        }
        private void AddAppliaceItems()
        {
            DataTable DT = objclsitem.GetItem();
            foreach (DataRow dr in DT.Rows)
            {
                frmHomeItems frm = new frmHomeItems(dr,false);
                frm.Width = ((label1.Width-26)/3)-6;
                frm.Margin= new Padding(3);
                foreach (string ID in Program.Craft)
                {
                    if (dr[0].ToString() == ID)
                        frm.btnCraft.Text = "Cancel";
                }
                loadform(frm);
            }
        }
        
    }
}
