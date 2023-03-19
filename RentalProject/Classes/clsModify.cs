using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal class clsModify
    {
        private string _ItemID, _AdminID, _Transation;
        RentalTableAdapters.ModifyTableAdapter objModify = new RentalTableAdapters.ModifyTableAdapter();
        RentalTableAdapters.vi_ModifyTableAdapter objvi_Modify = new RentalTableAdapters.vi_ModifyTableAdapter();

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
            objModify.Insert(Program.AdminID, ItemID, DateTime.Now, Transation);
        }
        public DataTable getModify()
        {
            return objvi_Modify.Getvi_modify();
        }
        public DataTable GetModifyByID(string Name)
        {
            return objvi_Modify.GetModifyByAdminName(Name);
        }
    }
}
