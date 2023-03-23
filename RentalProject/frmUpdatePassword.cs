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
    public partial class frmUpdatePassword : Form
    {
        public frmUpdatePassword(string Password,string ID)
        {
            InitializeComponent();
            this.Password = Password;
            this.ID = ID;
        }
        string Password;
        string ID;
        RentalTableAdapters.AdminTableAdapter objAdmin = new RentalTableAdapters.AdminTableAdapter();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtOldPassword.Text != Password)
            {
                MessageBox.Show("Your Password is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else if (txtPassword.Text.Length < 8 || txtPassword.Text.Length>16) //check password length greater than 8 and less than 16
            {
                MessageBox.Show("Password length have to between 8 and 16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else if (!txtPassword.Text.Any(char.IsUpper)) //check password contains upper case
            {
                MessageBox.Show("Password have to contain Upper case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else if (!txtPassword.Text.Any(char.IsLower)) //check password contains lower case
            {
                MessageBox.Show("Password have to contain Lower case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else if (!txtPassword.Text.Any(char.IsDigit)) //check password contains digit
            {
                MessageBox.Show("Password have to contain Digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                objAdmin.UpdatePassword(txtPassword.Text, ID);
                MessageBox.Show("Successfully Update");
                this.Close();
            }
        }
    }
}
