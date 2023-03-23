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
    public partial class frmHireDetailsView : Form
    {
        public frmHireDetailsView(string HireID)
        {
            int totalPricePerMonth = 0;
            InitializeComponent();
            DataTable DT = objHireDetails.GetDataByHireID(HireID);
            DataTable Item = new DataTable();
            Item.Columns.Add("Item Name");
            Item.Columns.Add("Price");
            foreach (DataRow dr in DT.Rows)
            {
                DataRow DRItem = Item.NewRow();
                DRItem[0] = dr[2].ToString();
                DRItem[1] = dr[3].ToString() + " £";
                totalPricePerMonth += Convert.ToInt32(dr[3]);
                Item.Rows.Add(DRItem);
            }
            DataRow DRTotal = Item.NewRow();
            DRTotal[0]="Total price per Month";
            DRTotal[1]=totalPricePerMonth.ToString() + " £";
            Item.Rows.Add(DRTotal);
            dgvHireDetals.DataSource = Item;
            dgvHireDetals.Columns[0].Width = (dgvHireDetals.Width/100)*50;
            dgvHireDetals.Columns[1].Width = (dgvHireDetals.Width/100)*50;

        }
        RentalTableAdapters.vi_HireDetailsTableAdapter objHireDetails = new RentalTableAdapters.vi_HireDetailsTableAdapter();

        private void frmHireDetailsView_Load(object sender, EventArgs e)
        {
            dgvHireDetals.Rows[dgvHireDetals.Rows.Count- 2].DefaultCellStyle.BackColor= Color.Yellow;

        }
    }
}
