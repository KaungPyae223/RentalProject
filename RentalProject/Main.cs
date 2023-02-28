using System;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        

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
            btnHistory.BackColor = Color.White;
            btnHome.BackColor = Color.White;
            btnItems.BackColor = Color.White;
            btnAdmin.BackColor = Color.White;
            btnUser.BackColor = Color.White;
            btnDashBoard.BackColor = Color.White;
            btn.BackColor = Color.Silver;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new frmAdmin());
            MakeButtonColor(btnAdmin);
        }

        
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void hidebuttons(ref Button btn)
        {
            btn.Enabled= false;
            btn.Visible= false;
            btn.Height=0;
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

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            loadform(new frmAdminDashboard());
            MakeButtonColor(btnDashBoard);
        }
    }
}
