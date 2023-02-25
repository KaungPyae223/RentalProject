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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        public void loadform(object Form,ref TabPage Tabpg)
        {
            if (Tabpg.Controls.Count > 0)
            {
                Tabpg.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            Tabpg.Controls.Add(f);
            Tabpg.Tag = f;
            f.Show();
        }
       
        

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            loadform(new frmAdminProcess(), ref TabAdminProcess);
            loadform(new frmAdminInfo(), ref TabAdminInfo);

        }
    }
}
