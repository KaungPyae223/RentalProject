using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
            DataTable dt = Program.DT;
            string ID = dt.Rows[0][0].ToString();
            DT = objHire.GetPayment(ID);
            DataColumn DCHire = new DataColumn("Hire Date", typeof(string));
            DataColumn DCDue = new DataColumn("Due Date", typeof(string));
            DT.Columns.Add(DCHire);
            DT.Columns.Add(DCDue);
            foreach (DataRow dr in DT.Rows) // to chage date time format
            {
                string Hire = Convert.ToDateTime(dr[5]).ToString("dd MMMM yyyy");

                string DueDate = Convert.ToDateTime(dr[8]).ToString("dd MMMM yyyy");
                dr["Due Date"]=DueDate;
                dr["Hire Date"]=Hire;
            }   

            dgvHire.DataSource = DT;
            dgvCustomerPayment.DataSource = objCustomerPayment.GetData(ID);

        }
        DataTable DT;
        RentalTableAdapters.vi_CustomerPaymentTableAdapter objCustomerPayment = new RentalTableAdapters.vi_CustomerPaymentTableAdapter();
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        private void frmHistory_Load(object sender, EventArgs e)
        {
            // design hire list
            dgvHire.Columns[0].Width = (dgvHire.Width/100)*15;
            dgvHire.Columns[1].Visible = false;
            dgvHire.Columns[2].Visible = false;
            dgvHire.Columns[3].Width = (dgvHire.Width/100)*15;
            dgvHire.Columns[4].Width = (dgvHire.Width/100)*15;
            dgvHire.Columns[5].Visible = false;
            dgvHire.Columns[6].Visible = false;
            dgvHire.Columns[7].Visible = false;
            dgvHire.Columns[8].Visible = false;
            dgvHire.Columns[9].Width = (dgvHire.Width/100)*15;
            dgvHire.Columns[10].Visible = false;
            dgvHire.Columns[11].Width = (dgvHire.Width/100)*10;
            dgvHire.Columns[12].Width = (dgvHire.Width/100)*18;
            dgvHire.Columns[13].Width = (dgvHire.Width/100)*18;
            dgvHire.Columns[11].DisplayIndex = 13;

            // design payment list
            dgvCustomerPayment.Columns[0].Width = (dgvCustomerPayment.Width/100)*10;
            dgvCustomerPayment.Columns[1].Width = (dgvCustomerPayment.Width/100)*15;
            dgvCustomerPayment.Columns[2].Visible = false;
            dgvCustomerPayment.Columns[3].Width = (dgvCustomerPayment.Width/100)*10;
            dgvCustomerPayment.Columns[4].Width = (dgvCustomerPayment.Width/100)*15;
            dgvCustomerPayment.Columns[5].Width = (dgvCustomerPayment.Width/100)*10;
            dgvCustomerPayment.Columns[6].Width = (dgvCustomerPayment.Width/100)*25;
            dgvCustomerPayment.Columns[7].Width = (dgvCustomerPayment.Width/100)*10;
            dgvCustomerPayment.Columns[8].Width = (dgvCustomerPayment.Width/100)*10;
            dgvCustomerPayment.Columns[9].Visible = false;

            MakeColor();
        }
        private void MakeColor() // make color if the hire is still hire
        {
            
            for (int i = 0; i < dgvHire.RowCount; i++)
            {
                if (dgvHire.Rows[i].Cells[10].Value.ToString() == string.Empty)
                {
                    dgvHire.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    DateTime Duedate = Convert.ToDateTime(dgvHire.Rows[i].Cells[8].Value);
                    if (Duedate < DateTime.Now) // make color red if the due date is over
                    {
                        dgvHire.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgvHire.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }

            }
        }

        private void dgvHire_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MakeColor();
        }

        private void dgvHire_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }

        private void dgvHire_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmHireDetailsView frm = new frmHireDetailsView(dgvHire.CurrentRow.Cells[0].Value.ToString());
            frm.Text = "Hire Details of "+ dgvHire.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();

        }
    }

}
