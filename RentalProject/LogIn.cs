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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        RentalTableAdapters.CustomerTableAdapter objCustomer = new RentalTableAdapters.CustomerTableAdapter();
        RentalTableAdapters.AdminTableAdapter objAdmin = new RentalTableAdapters.AdminTableAdapter();
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmUserRegister frm = new frmUserRegister();
            frm.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objCustomer.GetSP_Customer(txtEmail.Text, txtPassword.Text, 0);
            if(dt.Rows.Count > 0 )
            {
                clearData();
                Program.DT = dt;
                string level = "Profile,Home,Craft,Payment,History";
                string[] properties = level.Split(',');
                Array.Resize(ref Program.Properties,properties.Length);
                Program.Properties = properties;
                Program.Type = "User";
                Main main = new Main();
                main.ShowDialog();
            }
            else
            {
                dt.Clear();
                dt = objAdmin.GetSP_Admin(txtEmail.Text,txtPassword.Text,0);
                if(dt.Rows.Count > 0 )
                {
                    clearData();
                    Program.DT = dt;
                    string level = dt.Rows[0][2].ToString();
                    string[] properties = level.Split(',');
                    Array.Resize(ref Program.Properties, properties.Length);
                    Program.Properties = properties;
                    Program.Type = "Admin";
                    Main main = new Main();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password or Email is wrong", "Wrong Password or Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void clearData()
        {
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}
