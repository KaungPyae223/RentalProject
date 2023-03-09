using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal class clsModify
    {
        private string _ItemID, _AdminID, _Transation;
        RentalDataSetTableAdapters.ModifyTableAdapter objModify = new RentalDataSetTableAdapters.ModifyTableAdapter();
        public string ItemID
        {
            set { _ItemID = value; }
            get { return _ItemID; }
        }
        public string Transation
        {
            set { _Transation = value; }
            get { return _Transation; }
        }

        public void saveTransation()
        {
            objModify.Insert(_AdminID, ItemID, DateTime.Now, Transation);
        }
    }
}
