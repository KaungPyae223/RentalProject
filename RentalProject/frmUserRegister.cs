using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RentalProject.Classes;

namespace RentalProject
{
    public partial class frmUserRegister : Form
    {
        public frmUserRegister()
        {
            InitializeComponent();
        }

        clsCustomer objclsCustomer = new clsCustomer();
        string ImageLocation = "";
        byte[] image = null;
        RentalDataSetTableAdapters.CustomerTableAdapter objCustomer = new RentalDataSetTableAdapters.CustomerTableAdapter();
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
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxBlank(txtLocation, lbLocationWarning); // call a method to check textbox blank or not

        }

        private void CheckComplete() //This method is for checking all text boxes situation and make enable to the registers
        {
            if (lblAccountNameWarning.Text == "" && lblNameWraning.Text == "" && lblEmailWarning.Text == "" && lblPhoneWarning.Text == "" && lblNRCWarning.Text == "" && lblPasswordWarning.Text== "" && lblConfirmPassportWarning.Text == "" && lbLocationWarning.Text == "" && cboAggree.Checked == true)
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
                CheckComplete(); //call a method to check and make enable register

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
            if(ImageLocation != string.Empty)
            {
                FileStream File = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(File);
                image = brs.ReadBytes((int)File.Length);
            }

            if (MessageBox.Show("Sure to Register", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK) // confirm to save
            {
                AddData();
                objclsCustomer.SaveUser();
                MessageBox.Show("Successfully Register");
                this.Close();
            }
        }
        private void AddData()
        {
            objclsCustomer.CustomerID = MakeCustomerID();
            objclsCustomer.CustomerLevel = "Bronze";
            objclsCustomer.UserNRC = txtNRC.Text.Trim();
            objclsCustomer.UserEmail = txtEmail.Text.Trim();
            objclsCustomer.UserPhone = txtPhone.Text.Trim();
            objclsCustomer.UserPhoto = image;
            objclsCustomer.AccountName = txtAccountName.Text.Trim();
            objclsCustomer.UserPassword = txtPassword.Text.Trim();
            objclsCustomer.UserInfo = "";
            objclsCustomer.UserName = txtName.Text.Trim();
            objclsCustomer.UserLocation = txtLocation.Text.Trim();

        }
        private string MakeCustomerID()
        {
            DataTable Dt = new DataTable();
            Dt = objCustomer.GetCustomer();
            if (Dt.Rows.Count == 0)  //check there is data or not in Database
            {
                return "C-00001";
            }
            else
            {
                int lastIndx = Dt.Rows.Count- 1;                    //get the last Index
                string BrandID = Dt.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from I and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from behind '-'
                MakeID[1] = IDNum.ToString("00000");                  // get the ID number
                return MakeID[0]+"-"+MakeID[1];
            }
        }

        private void UserPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFdiag = new OpenFileDialog();
            OFdiag.Filter = "Picture Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (OFdiag.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = OFdiag.FileName.ToString();
                UserPicture.ImageLocation = ImageLocation;
            }
        }
    }
}
