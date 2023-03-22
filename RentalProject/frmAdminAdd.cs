using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RentalProject
{
    public partial class frmAdminAdd : Form
    {
        public frmAdminAdd()
        {
            InitializeComponent();
            DataTable DT = new DataTable();
            DT.Columns.Add("Display",typeof(string));
            DT.Columns.Add("Value", typeof(string));
            DT.Rows.Add("Junior Admin", "Profile,Home,Item");
            DT.Rows.Add("Mid Admin", "Profile,Home,Item,User");
            DT.Rows.Add("Senior Admin", "Profile,Home,Item,User,RentalList");
            DT.Rows.Add("Super Admin", "Profile,Home,Item,User,RentalList,PaymentList,Admin");
            cboPost.DataSource = DT;
            cboPost.DisplayMember = "Display";
            cboPost.ValueMember = "Value";
        }
        public Boolean IsEdit = false;
        string properties;
        string imageLocation;
        public byte[] image;
        RentalTableAdapters.AdminTableAdapter objAdmin = new RentalTableAdapters.AdminTableAdapter();
        private void cboPost_SelectedIndexChanged(object sender, EventArgs e)
        {

            properties =cboPost.SelectedValue.ToString();
            ShowProperties();

        }
        private void ShowProperties()
        {
            string[] check = properties.Split(',');
            for (int i = 0; i < clbProperties.Items.Count; i++)
            {
                for (int j = 0; j < check.Length; j++)
                {
                    if (clbProperties.Items[i].ToString() == check[j].ToString())
                    {
                        clbProperties.SetItemChecked(i, true);
                        break;
                    }
                    else
                        clbProperties.SetItemChecked(i, false);
                }
            }
        }

        private void frmAdminAdd_Load(object sender, EventArgs e)
        {
            if(IsEdit == false)
            {
                cboPost.SelectedIndex= 0;
                AddID();
            }
            if (IsEdit && image != null)
            {
                MemoryStream ms = new MemoryStream(image);
                AdminPicture.Image = Image.FromStream(ms);
            }
        }
        private void AddID()
        {
            DataTable Dt = new DataTable();
            Dt = objAdmin.GetAdmin();
            if (Dt.Rows.Count == 0)  //check there is data or not in Database
            {
                txtID.Text= "A-001";
            }
            else
            {
                int lastIndx = Dt.Rows.Count- 1;                    //get the last Index
                string BrandID = Dt.Rows[lastIndx][0].ToString();   //get the ID from last index
                string[] MakeID = BrandID.Split('-');               // split the ID by using split function from I and 001 seprate to add the ID number
                int IDNum = Convert.ToInt32(MakeID[1])+1;           // add the Id num from behind '-'
                MakeID[1] = IDNum.ToString("000");                  // get the ID number
                txtID.Text= MakeID[0]+"-"+MakeID[1];
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                image = null;
                if(imageLocation != string.Empty)
                {
                    FileStream File = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(File);
                    image = brs.ReadBytes((int)File.Length);
                }
                DataTable DT = new DataTable();
                DT = objAdmin.CheckAdmin(txtEmail.Text.Trim());
                if(DT.Rows.Count == 0)
                {
                    objAdmin.Insert(txtID.Text, cboPost.Text, properties, txtAccountName.Text, txtName.Text, txtLocation.Text, txtEmail.Text, txtPhone.Text, txtNRC.Text, txtPassword.Text, txtInfo.Text, DateTime.Now, image);
                    MessageBox.Show("Successfully Save");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This Admin is already exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }
        private Boolean CheckData()
        {
            string Password = txtPassword.Text;
            if (txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Admin Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            else if (txtAccountName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountName.Focus();
                return false;

            }
            else if (txtLocation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
                return false;

            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;

            }
            else if (txtPhone.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;

            }
            else if (txtNRC.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type an NRC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNRC.Focus();
                return false;

            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Plese type a Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if (Password.Length < 8 || Password.Length>16) //check password length greater than 8 and less than 16
            {
                MessageBox.Show("Password length have to between 8 and 16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if (!Password.Any(char.IsUpper)) //check password contains upper case
            {
                MessageBox.Show("Password have to contain Upper case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if (!Password.Any(char.IsLower)) //check password contains lower case
            {
                MessageBox.Show("Password have to contain Lower case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if (!Password.Any(char.IsDigit)) //check password contains digit
            {
                MessageBox.Show("Password have to contain Digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password have to same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            else if(txtInfo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter a Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInfo.Focus();
                return false;

            }
            else
            {
                return true;
            }

        }

        private void AdminPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFdiag = new OpenFileDialog();
            OFdiag.Filter = "Picture Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (OFdiag.ShowDialog() == DialogResult.OK)
            {
                imageLocation = OFdiag.FileName.ToString();
                AdminPicture.ImageLocation = imageLocation;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
