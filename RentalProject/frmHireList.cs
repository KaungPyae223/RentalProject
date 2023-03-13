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
    public partial class frmHireList : Form
    {
        public frmHireList()
        {
            InitializeComponent();
        }
        clsHire objClsHire = new clsHire();
        private void frmHireList_Load(object sender, EventArgs e)
        {
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
    }
}
