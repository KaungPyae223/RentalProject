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
            dgvPayment.DataSource = objHire.GetPayment(ID);
            dgvPayment.Columns[0].Width = (dgvPayment.Width/100)*15;
            dgvPayment.Columns[1].Visible = false;
            dgvPayment.Columns[2].Visible = false;
            dgvPayment.Columns[3].Visible = false;
            dgvPayment.Columns[4].Width = (dgvPayment.Width/100)*23;
            dgvPayment.Columns[5].Width = (dgvPayment.Width/100)*23;
            dgvPayment.Columns[6].Visible = false;
            dgvPayment.Columns[7].Visible = false;
            dgvPayment.Columns[8].Width = (dgvPayment.Width/100)*20;
            dgvPayment.Columns[9].Visible = false;
            dgvPayment.Columns[10].Visible = false;
            dgvPayment.Columns[11].Width = (dgvPayment.Width/100)*20;

        }
    }
}
