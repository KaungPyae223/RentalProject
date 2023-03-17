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
            foreach (DataRow dr in DT.Rows)
            {
                string Hire = Convert.ToDateTime(dr[5]).ToString("dd MMMM yyyy");

                string DueDate = Convert.ToDateTime(dr[8]).ToString("dd MMMM yyyy");
                dr["Due Date"]=DueDate;
                dr["Hire Date"]=Hire;
            }
            dgvHire.DataSource =DT;

            

        }
        DataTable DT;
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        private void frmHistory_Load(object sender, EventArgs e)
        {
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

            MakeColor();
        }
        private void MakeColor()
        {
            int lastIndex = dgvHire.Rows.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                if (dgvHire.Rows[i].Cells[10].Value.ToString() == string.Empty)
                {
                    dgvHire.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    DateTime Duedate = Convert.ToDateTime(dgvHire.Rows[i].Cells[8].Value);
                    if (Duedate < DateTime.Now)
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
    }

}
