﻿using System;
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
            ItemName = dr[3].ToString();
            Description = dr[9].ToString();
            Brand = dr[11].ToString();
            Type = dr[12].ToString();
            TypicalUsage = dr[5].ToString();
            PowerUsage = dr[4].ToString();
            ModelYear = dr[6].ToString();
            PricePerMonth = dr[8].ToString();
            ID = dr[0].ToString();
            byte[] img = (byte[])(dr[10]);
            MemoryStream ms = new MemoryStream(img);
            HomeItemPicture.Image = Image.FromStream(ms);
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
            if(btnCraft.Text == "Add to Craft")
            {
                Program.Craft.Add(ID);
                btnCraft.Text = "Cancel";
            }
            else if(Drop)
            {
                btnCraft.Text = "Add to Craft";
                Program.Craft.Remove(ID);
                this.Close();
            }
            else
            {
                btnCraft.Text = "Add to Craft";
                Program.Craft.Remove(ID);
            }

        }

        private void frmHomeItems_Load(object sender, EventArgs e)
        {
            SetInfo();
        }
    }
}
