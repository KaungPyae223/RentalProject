using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal class clsBrand
    {
        private string _BrandID, _BrandName;
        RentalDataSetTableAdapters.BrandTableAdapter objBrand = new RentalDataSetTableAdapters.BrandTableAdapter();

        public string BrandID
        {
            set { _BrandID = value; }
            get { return _BrandID; }
        }
        public string BrandName
        {
            set { _BrandName = value; }
            get { return _BrandName; }
        }
        public void AddBrand()
        {
            objBrand.Insert(_BrandID, _BrandName);
        }
        public void RemoveBrand()
        {
            objBrand.DeleteBrand(BrandID);
        }
        public void EditBrand()
        {
            objBrand.UpdateBrand(BrandName, BrandID);
        }

        public DataTable GetBrand()
        {
            return objBrand.GetBrand();
        }
    }
}
