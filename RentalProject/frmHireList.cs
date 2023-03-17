using RentalProject.Classes;
using System;
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

        }
        clsHire objClsHire = new clsHire();
        private void frmHireList_Load(object sender, EventArgs e)
        {
            MakeColor();
        }
        private void MakeColor()
        {
            int lastIndex = dgvHireList.Rows.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                if (dgvHireList.Rows[i].Cells[11].Value.ToString() == string.Empty)
                {
                    dgvHireList.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    DateTime Duedate = Convert.ToDateTime(dgvHireList.Rows[i].Cells[9].Value);
                    if (Duedate < DateTime.Now)
                    {
                        dgvHireList.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgvHireList.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    }
                }
            }
        }

        private void dgvHireList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MakeColor();
        }
    }
}
