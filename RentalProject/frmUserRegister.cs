using System;
using System.Linq;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmUserRegister : Form
    {
        public frmUserRegister()
        {
            InitializeComponent();
        }
        string ImageLocation;
        private void txtPassport_TextChanged(object sender, EventArgs e)
        {
            //add Password from the txtPassport to the Password variable
            string Password = txtPassword.Text;

            if (Password.Length < 8 || Password.Length>16) //check password length greater than 8 and less than 16
            {
                lblPasswordWarning.Text = "Password length have to between 8 and 16";
                CheckComplete(); //call a method to check and make enable register
            }
            else if (!Password.Any(char.IsUpper)) //check password contains upper case
            {
                lblPasswordWarning.Text = "Password have to contain upper case";
                CheckComplete(); //call a method to check and make enable register
            }
            else if (!Password.Any(char.IsLower)) //check password contains lower case
            {
                lblPasswordWarning.Text = "Password have to contain lower case";
                CheckComplete(); //call a method to check and make enable register
            }
            else if (!Password.Any(char.IsDigit)) //check password contains digit
            {
                lblPasswordWarning.Text = "Password have to contain digit number";
                CheckComplete(); //call a method to check and make enable register
            }
            else
            {
                lblPasswordWarning.Text = "";
                if (txtPassword.Text != txtConfirmPassword.Text) // check password form password and confirm password same or not
                {
                    lblConfirmPassportWarning.Text = "Do not match two passwords";
                }
                CheckComplete(); //call a method to check and make enable register
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text) // check password form password and confirm password same or not
            {
                lblConfirmPassportWarning.Text = "Do not match two passwords";
                CheckComplete(); //call a method to check and make enable register
            }
            else
            {
                lblConfirmPassportWarning.Text = "";
                CheckComplete(); //call a method to check and make enable register
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtName, lblNameWraning); // call a method to check textbox blank or not
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtAccountName, lblAccountNameWarning); // call a method to check textbox blank or not
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtEmail, lblEmailWarning); // call a method to check textbox blank or not
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtPhone, lblPhoneWarning); // call a method to check textbox blank or not
        }

        private void txtNRC_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtNRC, lblNRCWarning); // call a method to check textbox blank or not
        }

        private void cboAggree_CheckedChanged(object sender, EventArgs e)
        {
            CheckComplete(); //call a method to check and make enable register
        }

        private void CheckComplete() //This method is for checking all text boxes situation and make enable to the registers
        {
            if (lblAccountNameWarning.Text == "" && lblNameWraning.Text == "" && lblEmailWarning.Text == "" && lblPhoneWarning.Text == "" && lblNRCWarning.Text == "" && lblPasswordWarning.Text== "" && lblConfirmPassportWarning.Text == "" && cboAggree.Checked == true)
            {
                btnRegister.Enabled = true;
            }
            else
            {
                btnRegister.Enabled = false;
            }
        }

        private void CheckTextBoxBlank(TextBox txt, Label lbl) // check the text box is blank or not
        {
            if (txt.Text.Trim() == string.Empty)
            {
                lbl.Text = "Required!";
            }
            else
            {
                lbl.Text = "";
                CheckComplete(); //call a method to check and make enable register
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpb|All files(*.*)|*.*";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = diag.FileName.ToString();
                UserPicture.ImageLocation = ImageLocation;
            }
        }
    }
}
