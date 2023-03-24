using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
            dt = Program.DT;
            GridViewShow();

        }
        DataTable dt;
        clsItem objClsItem = new clsItem();
        RentalTableAdapters.HireDetailsTableAdapter objHireDetails = new RentalTableAdapters.HireDetailsTableAdapter();
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        private void frmPayment_Load(object sender, EventArgs e)
        {
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
            MakeColor();
            // make data grid view design
        }
        private void MakeColor() // make color red to row if the due date is over
        {
            for (int i = 0; i < dgvPayment.Rows.Count; i++)
            {
                DateTime Duedate = Convert.ToDateTime(dgvPayment.Rows[i].Cells[8].Value);
                if (Duedate < DateTime.Now) // compare due date and today
                {
                    dgvPayment.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dgvPayment.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void GridViewShow() // add data to the grid view
        {
            string ID = dt.Rows[0][0].ToString();
            DataTable DT = objHire.GetToPayment(ID);
            DataColumn DCHire = new DataColumn("Hire Date", typeof(string));
            DataColumn DCDue = new DataColumn("Due Date", typeof(string));
            DT.Columns.Add(DCHire);
            DT.Columns.Add(DCDue);
            foreach (DataRow dr in DT.Rows) // loop to chage date time format of Hire and Due date
            {
                string Hire = Convert.ToDateTime(dr[5]).ToString("dd MMMM yyyy");

                string DueDate = Convert.ToDateTime(dr[8]).ToString("dd MMMM yyyy");
                dr["Due Date"]=DueDate;
                dr["Hire Date"]=Hire;

            }
            dgvPayment.DataSource =DT;

        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            // check select to make payment
            if (dgvPayment.CurrentRow.Cells[0].Value.ToString() == string.Empty)  
            {
                MessageBox.Show("Plese choose a payment to you want to make", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string HireID = dgvPayment.CurrentRow.Cells[0].Value.ToString();
                DateTime DeadLineDate = Convert.ToDateTime(dgvPayment.CurrentRow.Cells[8].Value);
                frmMakePayment payment = new frmMakePayment(HireID, DeadLineDate);
                payment.ShowDialog();
                GridViewShow();
                MakeColor();
            }
        }

        private void dgvPayment_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // check select hire to make a payment
            if (dgvPayment.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Plese choose a payment to you want to make", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Are you confirm to Return the Hire Items", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                {
                    try
                    {

                        string HireID = dgvPayment.CurrentRow.Cells[0].Value.ToString();
                        DataTable DT = objHireDetails.GetDataByHireID(HireID);
                        foreach (DataRow dr in DT.Rows) //loop to updat on HandQty
                        {
                            DataTable Item = objClsItem.getSP_Item(dr[0].ToString(), 0);
                            int OnHandQty = Convert.ToInt32(Item.Rows[0][7])+1;

                            objClsItem.UpdateOnHandQty(OnHandQty, dr[0].ToString());

                        }
                        clsHire objclsHire = new clsHire();
                        objclsHire.UpdateReturnDate(DateTime.Now.ToString(), HireID);
                        GridViewShow();
                        MakeColor();
                        MessageBox.Show("Our Appliances will take back less than one week and you do not need to give anything about it.\nThe insurance cost will return to you less than one month after checking the home appliances.\nThank you for your rent", "Thank you");

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
