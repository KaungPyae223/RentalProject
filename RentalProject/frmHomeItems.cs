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
    public partial class frmHomeItems : Form
    {
        public frmHomeItems()
        {
            InitializeComponent();
        }
        private string ItemName;
        private string Description;
        private string Brand;
        private string Type;
        private string TypicalUsage;
        private string PowerUsage;
        private string ModelYear;
        private string PricePerMonth;

        private void SetInfo()
        {
            lblItemName.Text = ItemName;
            lblDescription.Text = Description;
            lblModelYear.Text = ModelYear;
            lblPowerUsage.Text = PowerUsage;
            lblPricePerMonth.Text = PricePerMonth;
            lblDescription.Text= Description;
            lblBrand.Text = Brand;
            lblType.Text = Type;
            lblTypicalUsage.Text = TypicalUsage;
        }
        private void btnCraft_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
