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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        private void frmPayment_Load(object sender, EventArgs e)
        {
            DataTable dt = Program.DT;
            string ID = dt.Rows[0][0].ToString();
            DataTable DT = objHire.GetPayment(ID);
            DataColumn DCHire = new DataColumn("Hire Date", typeof(string));
            DataColumn DCDue = new DataColumn("Due Date",typeof(string));
            DT.Columns.Add(DCHire);
            DT.Columns.Add(DCDue);
            foreach(DataRow dr in DT.Rows)
            {
                string Hire = Convert.ToDateTime(dr[5]).ToString("dd MMMM yyyy");

                string DueDate = Convert.ToDateTime(dr[8]).ToString("dd MMMM yyyy");
                dr["Due Date"]=DueDate;
                dr["Hire Date"]=Hire;
            }
            dgvPayment.DataSource =DT; 
            dgvPayment.Columns[0].Width = (dgvPayment.Width/100)*15;
            dgvPayment.Columns[1].Visible = false;
            dgvPayment.Columns[2].Visible = false;
            dgvPayment.Columns[3].Visible = false;
            dgvPayment.Columns[4].Width = (dgvPayment.Width/100)*23;
            dgvPayment.Columns[5].Visible = false;
            dgvPayment.Columns[6].Visible = false;
            dgvPayment.Columns[7].Visible = false;
            dgvPayment.Columns[8].Visible = false;
            dgvPayment.Columns[9].Visible = false;
            dgvPayment.Columns[10].Visible = false;
            dgvPayment.Columns[11].Width = (dgvPayment.Width/100)*20;
            dgvPayment.Columns[12].Width = (dgvPayment.Width/100)*20;
            dgvPayment.Columns[13].Width = (dgvPayment.Width/100)*20;
            dgvPayment.Columns[11].DisplayIndex = 13;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvPayment.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Plese choose a payment to you want to make", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string HireID = dgvPayment.CurrentRow.Cells[0].Value.ToString();
                DateTime DeadLineDate = Convert.ToDateTime(dgvPayment.CurrentRow.Cells[8].Value);
                frmMakePayment payment = new frmMakePayment(HireID,DeadLineDate);
                payment.ShowDialog();
            }
        }
    }
}
