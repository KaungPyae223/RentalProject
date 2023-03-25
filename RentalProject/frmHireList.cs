using RentalProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHireList : Form
    {
        public frmHireList()
        {
            InitializeComponent();
            dgvHireList.DataSource = objClsHire.GetHireList();
            dgvHireList.Columns[0].Width = (dgvHireList.Width/100)*15;
            dgvHireList.Columns[7].Width = (dgvHireList.Width/100)*10;
            dgvHireList.Columns[6].Width = (dgvHireList.Width/100)*10;
            dgvHireList.Columns[5].Width = (dgvHireList.Width/100)*10;
            dgvHireList.Columns[4].Width = (dgvHireList.Width/100)*10;
            dgvHireList.Columns[3].Visible = false;
            dgvHireList.Columns[2].Width = (dgvHireList.Width/100)*15;
            dgvHireList.Columns[1].Width = (dgvHireList.Width/100)*15;
            dgvHireList.Columns[8].Width = (dgvHireList.Width/100)*15;
            dgvHireList.Columns[9].Width = (dgvHireList.Width/100)*15;
            dgvHireList.Columns[10].Width = (dgvHireList.Width/100)*10;
            dgvHireList.Columns[11].Width = (dgvHireList.Width/100)*13;
            dgvHireList.Columns[12].Width = (dgvHireList.Width/100)*13;
            // design the user list

        }
        clsHire objClsHire = new clsHire();
        RentalTableAdapters.vi_HireTableAdapter objHire = new RentalTableAdapters.vi_HireTableAdapter();
        private void frmHireList_Load(object sender, EventArgs e)
        {
            MakeColor();    // call a method to make color
            cboType.SelectedIndex = 0;
            Suggestion();   //call a method to add suggestion
        }
        private void MakeColor()
        {
            
            for (int i = 0; i < dgvHireList.Rows.Count; i++)
            {
                if (dgvHireList.Rows[i].Cells[11].Value.ToString() == string.Empty) // check still hire
                {
                    dgvHireList.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    DateTime Duedate = Convert.ToDateTime(dgvHireList.Rows[i].Cells[9].Value);
                    if (Duedate < DateTime.Now) // check due date is over
                    {
                        dgvHireList.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgvHireList.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    }
                }
            }
        }
        public void Suggestion()    // method to add suggestion
        {
            AutoCompleteStringCollection sourse = new AutoCompleteStringCollection();
            DataTable DT = objHire.GetHireList(txtCustomerName.Text.ToString(), cboType.SelectedIndex);
            if (DT.Rows.Count > 0)
            {
                txtCustomerName.AutoCompleteCustomSource.Clear();
                foreach (DataRow dr in DT.Rows)
                {
                    sourse.Add(dr[1].ToString());
                }
                txtCustomerName.AutoCompleteCustomSource = sourse;
                txtCustomerName.Text = "";
                txtCustomerName.Focus();
            }
        }
        private void dgvHireList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suggestion();
            AddData();  // call a method to change the data
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            AddData();  
        }
        private void AddData()  // method to chage the data according to the user action
        {
            dgvHireList.DataSource = objHire.GetHireList(txtCustomerName.Text.ToString(),cboType.SelectedIndex);
            MakeColor();
        }

        // method show all hire items when double click hire
        private void dgvHireList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmHireDetailsView frm = new frmHireDetailsView(dgvHireList.CurrentRow.Cells[0].Value.ToString());
            frm.Text = "Hire Details of "+ dgvHireList.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            
        }
    }
}
