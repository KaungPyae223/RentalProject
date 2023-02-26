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

        private void frmHome_Load(object sender, EventArgs e)
        {
            AddAppliaceItems();
        }
        
        private void AddAppliaceItems()
        {
            for (int i = 0; i< 18; i++)
            {
                frmHomeItems frm = new frmHomeItems();
                frm.Width = ((label1.Width-26)/4)-6;
                frm.Margin= new Padding(3);
                loadform(frm);
            }
        }
        
    }
}
