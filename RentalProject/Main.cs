using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.DT = Program.DT;   
            //call the data table DT from program and add the DT in the Main.cs

            btnProfile.Text = DT.Rows[0]["AccountName"].ToString();
        }
        DataTable DT = new DataTable();

        // method for the appropriate window form to run on the main panel
        public void loadform(object Form)
        {
            // check form run on the maim panel
            if (this.mainPannel.Controls.Count > 0)
            {
                this.mainPannel.Controls.RemoveAt(0);
                // if there, close the form run on main panel
            }
            Form f = Form as Form; // call the form
            f.TopLevel = false;

            f.Dock = DockStyle.Fill; 
            // form to make dock fill to show full space in main panel

            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            // add form to the main panel as a control

            f.Show();
            // show a form
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            loadform(new frmProfile()); 
            // call a method to show a Profile on the main panel

            MakeButtonColor(btnProfile);
            // to change the button color when click the button
        }

        private void btnCraft_Click(object sender, EventArgs e)
        {
            loadform(new frmCraft());
            MakeButtonColor(btnCraft);

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            loadform(new frmPayment());
            MakeButtonColor(btnPayment);

        }

        // method to change the button color when click it
        public void MakeButtonColor(Button btn)
        {
            btnCraft.BackColor = Color.White;
            btnPayment.BackColor = Color.White;
            btnProfile.BackColor = Color.White;
            btnHistory.BackColor = Color.White;
            btnHireList.BackColor = Color.White;
            btnPaymentList.BackColor = Color.White;
            btnHome.BackColor = Color.White;
            btnItems.BackColor = Color.White;
            btnAdmin.BackColor = Color.White;
            btnUser.BackColor = Color.White;
            btn.BackColor = Color.Silver;
        }




        private void Main_Load(object sender, EventArgs e)
        {
            // add data from the program.properties to the main properties
            string[] properties = Program.Properties;
            for (int i = 0; i < properties.Length; i++) // loop all the data in array
            {
                switch (properties[i]) // check the properties to user allow to use
                {
                    case "Profile": // if the properties contain Profile, user can use Profile
                        btnProfile.Visible = true;
                        break;
                    case "Craft":
                        btnCraft.Visible = true;
                        break;
                    case "Payment":
                        btnPayment.Visible = true;
                        break;
                    case "History":
                        btnHistory.Visible = true;
                        break;
                    case "Home":
                        btnHome.Visible = true;
                        break;
                    case "Item":
                        btnItems.Visible = true;
                        break;
                    case "User":
                        btnUser.Visible = true;
                        break;
                    case "Admin":
                        btnAdmin.Visible = true;
                        break;
                    case "RentalList":
                        btnHireList.Visible = true;
                        break;
                    case "PaymentList":
                        btnPaymentList.Visible = true;
                        break;
                }
            }

            loadform(new frmProfile()); // call a method to show Profile in main panel when start Main form
            MakeButtonColor(btnProfile);    
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            loadform(new frmItems());
            MakeButtonColor(btnItems);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            loadform(new frmUserControl());
            MakeButtonColor(btnUser);
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            loadform(new frmHome());
            MakeButtonColor(btnHome);

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            loadform(new frmAdmin());
            MakeButtonColor(btnAdmin);
        }

        private void btnHireList_Click(object sender, EventArgs e)
        {
            loadform(new frmHireList());
            MakeButtonColor(btnHireList);

        }

        private void btnPaymentList_Click(object sender, EventArgs e)
        {
            loadform(new frmPaymentLists());
            MakeButtonColor(btnPaymentList);

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            loadform(new frmHistory());
            MakeButtonColor(btnHistory);
        }
    }
}
