using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal class clsType
    {
        RentalDataSetTableAdapters.TypeTableAdapter objType = new RentalDataSetTableAdapters.TypeTableAdapter();
        private string _TypeID, _NameOfType;

        public string TypeID
        {
            set { _TypeID = value; }
            get { return _TypeID; }
        }
        public string NameOfType
        {
            set { _NameOfType = value; }
            get { return _NameOfType; }
        }

        public void AddType()
        {
            objType.Insert(TypeID, NameOfType);
        }
        public void RemoveType()
        {
            objType.DeleteType(TypeID);
        }
        public void EditType()
        {
            objType.UpdateType(TypeID, NameOfType);
        }
        public DataTable GetType()
        {
            return objType.GetType();
        }
    }
}
