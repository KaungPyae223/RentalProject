using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal class clsDelivery
    {
        private string _DeliveryID, _DeliveryName, _DeliveryPhone;

        RentalTableAdapters.DeliveryTableAdapter objDelivery = new RentalTableAdapters.DeliveryTableAdapter();
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();

        public string DeliveryID
        {
            set { _DeliveryID = value; }
            get { return _DeliveryID; }
        }
        public string DeliveryName
        {
            set { _DeliveryName = value; }
            get { return _DeliveryName; }
        }
        public string DeliveryPhone
        {
            set { _DeliveryPhone = value; }
            get { return _DeliveryPhone; }
        }

        public void AddDelivery()
        {
            objDelivery.Insert(DeliveryID,DeliveryName,DeliveryPhone);
        }
        public void EditDelivery()
        {
            objDelivery.UpdateDelivery(DeliveryID,DeliveryName,DeliveryPhone);   
        }
        public void DeleteDelivery()
        {
            objDelivery.DeleteDelivery(DeliveryID);
        }
        public DataTable GetDelivery()
        {
            return objDelivery.GetDelivery();
        }
        public DataTable CheckDelivery(string DeliveryID)
        {
            return objHire.CheckDelivery(DeliveryID);
        }
    }
}
