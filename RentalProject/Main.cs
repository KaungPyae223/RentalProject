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
            /*this.DT = Program.DT;
            btnProfile.Text = DT.Rows[0]["AccountName"].ToString();*/
        }
        DataTable DT = new DataTable();


        public void loadform(object Form)
        {
            if (this.mainPannel.Controls.Count > 0)
            {
                this.mainPannel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            f.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            loadform(new frmProfile());
            MakeButtonColor(btnProfile);
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
            /*string[] properties = Program.Properties;
            for (int i = 0; i < properties.Length; i++)
            {
                switch (properties[i])
                {
                    case "Profile":
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
            }*/

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
