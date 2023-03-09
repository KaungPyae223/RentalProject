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
    public partial class frmAdminProcess : Form
    {
        clsModify objClsModify = new clsModify();
        public frmAdminProcess()
        {
            InitializeComponent();
            dgvAdminProcess.DataSource = objClsModify.getModify();
            dgvAdminProcess.Columns[0].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[1].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[2].Width = (dgvAdminProcess.Width/100) * 25;
            dgvAdminProcess.Columns[3].Width = (dgvAdminProcess.Width/100) * 25;

        }
    }
}
