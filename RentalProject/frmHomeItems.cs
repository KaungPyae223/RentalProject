using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmHomeItems : Form
    {
        public frmHomeItems(DataRow dr, bool drop)  
        {
            InitializeComponent();

            //add all data get from parameter to the form
            ItemName = dr[3].ToString();
            Description = dr[9].ToString();
            Brand = dr[11].ToString();
            Type = dr[12].ToString();
            TypicalUsage = dr[5].ToString();
            PowerUsage = dr[4].ToString();
            ModelYear = dr[6].ToString();
            PricePerMonth = dr[8].ToString() + " £";
            ID = dr[0].ToString();
            byte[] img = (byte[])(dr[10]);  
            MemoryStream ms = new MemoryStream(img);    // change byte to memoary stream
            HomeItemPicture.Image = Image.FromStream(ms);   //change memoary stream to Image
            Drop=drop;
        }
        private string ItemName;
        private string Description;
        private string Brand;
        private string Type;
        private string TypicalUsage;
        private string PowerUsage;
        private string ModelYear;
        private string PricePerMonth;
        private string ID;
        private Boolean Drop;
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
            if(btnCraft.Text == "Add to Craft") // check the button text
            {
                Program.Craft.Add(ID);  // add item Id to the program's Craft list
                btnCraft.Text = "Cancel";
                btnCraft.BackColor = Color.Orange;
                btnCraft.ForeColor = Color.White;
                // change appearance
            }
            else if(Drop)
            {
                btnCraft.Text = "Add to Craft";
                Program.Craft.Remove(ID);   //remove Id from program's craft
                this.Close();
            }
            else
            {
                btnCraft.Text = "Add to Craft";
                Program.Craft.Remove(ID);
                btnCraft.BackColor = Color.Bisque;
                btnCraft.ForeColor = Color.Black;
            }

        }

        private void frmHomeItems_Load(object sender, EventArgs e)
        {
            SetInfo();
        }

        /*  
         
            Disclaimer

            This form is do not run separately. It is used for
            show the items in Home page as a control.
         
         */
    }
}
