using RentalProject.Classes;
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
    public partial class frmUserControl : Form
    {
        public frmUserControl()
        {
            InitializeComponent();
        }
        clsCustomer objClsCustomer = new clsCustomer();
        private void frmUserControl_Load(object sender, EventArgs e)
        {
            Suggestion("CustomerName");
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

        }

        private void TsmCustomerName_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "Customer Name";
            Suggestion("CustomerName");
        }

        private void TsmEmail_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "Customer Email";
            Suggestion( "CustomerEmail");

        }

        private void TsmAccountName_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "Account Name";
            Suggestion( "AccountName");

        }
        public void Suggestion( string FieldName)
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            DataTable DT = objClsCustomer.SelectUser();
            if (DT.Rows.Count > 0)
            {
                txtUser.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[FieldName].ToString());
                }
                txtUser.AutoCompleteCustomSource = sourse;
                txtUser.Text = "";
                txtUser.Focus();
            }
        }
    }
}
