using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        int Counter = 0;
        RentalTableAdapters.CustomerTableAdapter objCustomer = new RentalTableAdapters.CustomerTableAdapter();
        RentalTableAdapters.AdminTableAdapter objAdmin = new RentalTableAdapters.AdminTableAdapter();
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmUserRegister frm = new frmUserRegister(); //call a register form
            frm.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objCustomer.GetSP_Customer(txtEmail.Text, txtPassword.Text, 0);    
            // select data from the User table

            if(Counter == 3)
            {
                MessageBox.Show("Your available log in time is over");
            }
            else
            {
                if (dt.Rows.Count > 0) // check the user ID and password correct or not
                {
                    clearData();
                    Program.DT = dt;
                    string level = "Profile,Home,Craft,Payment,History";
                    string[] properties = level.Split(',');
                    // split the properties with "," and add to the array

                    Array.Resize(ref Program.Properties, properties.Length);

                    Program.Properties = properties;
                    // add properties to the Program.cs's propertes array

                    Program.Type = "User";
                    // add type to the Program.cs's type variable

                    Main main = new Main();
                    // call a Main form
                    main.ShowDialog();
                }
                else
                {
                    dt.Clear();
                    dt = objAdmin.GetSP_Admin(txtEmail.Text, txtPassword.Text, 0);
                    if (dt.Rows.Count > 0)  // check the user ID and password correct or not
                    {
                        clearData();
                        Program.DT = dt;
                        string level = dt.Rows[0][2].ToString();
                        string[] properties = level.Split(',');
                        Array.Resize(ref Program.Properties, properties.Length);
                        Program.Properties = properties;
                        Program.AdminID = dt.Rows[0][0].ToString();
                        Program.Type = "Admin";
                        Main main = new Main();
                        main.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Password or Email is wrong", "Wrong Password or Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Counter++;
                    }
                }
            }
            
        }
        private void clearData()
        {
            txtPassword.Text = string.Empty;    //clear password from the password text box
            txtEmail.Text = string.Empty;       //clear Email from the Email text box
        }
    }
}
