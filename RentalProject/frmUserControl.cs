using RentalProject.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmUserControl : Form
    {
        public frmUserControl()
        {
            InitializeComponent();
        }
        clsCustomer objClsCustomer = new clsCustomer();
        RentalTableAdapters.CustomerTableAdapter objcustomer = new RentalTableAdapters.CustomerTableAdapter();
        private void frmUserControl_Load(object sender, EventArgs e)
        {
            //design a user list
            dgvUser.DataSource = objClsCustomer.SelectUser();
            dgvUser.Columns[0].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[1].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[2].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[3].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[4].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[5].Width = (dgvUser.Width/100)*20;
            dgvUser.Columns[6].Width = (dgvUser.Width/100)*15;
            dgvUser.Columns[7].Visible = false;
            dgvUser.Columns[8].Visible = false;
            dgvUser.Columns[9].Visible = false;
            dgvUser.Columns[10].Visible = false;
            dgvUser.Columns[11].Visible = false;
            Suggestion();
        }


        public void Suggestion()
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            DataTable DT = objClsCustomer.SelectUser();
            if (DT.Rows.Count > 0)
            {
                txtUser.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[3].ToString());
                }
                txtUser.AutoCompleteCustomSource = sourse;
                txtUser.Text = "";
                txtUser.Focus();
            }
        }



        private void txtUser_TextChanged(object sender, EventArgs e)
        {

            dgvUser.DataSource = objcustomer.GetCustomerByName(txtUser.Text);

        }

        private void frmUpdateUserLevel_Click(object sender, EventArgs e) // method to update user level
        {
            if (dgvUser.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a user to update level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Are you sure to update level", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string userlevel = dgvUser.CurrentRow.Cells[1].Value.ToString();
                    switch(userlevel)
                    {
                        case "Bronze":
                            userlevel = "Silver";
                            break;
                        case "Silver":
                            userlevel = "Gold";
                            break;
                        case "Gole":
                            userlevel = "Diamond";
                            break;
                    }
                    objcustomer.UpdateCustomerLevel(userlevel, dgvUser.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show("Successfully update level to "+userlevel);
                }
            }
        }
    }
}
