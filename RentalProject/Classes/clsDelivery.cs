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

        RentalDataSetTableAdapters.DeliveryTableAdapter objDelivery = new RentalDataSetTableAdapters.DeliveryTableAdapter();

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
            objDelivery.Insert(_DeliveryID,_DeliveryName,_DeliveryPhone);
        }
        public void EditDelivery()
        {
            objDelivery.UpdateDelivery(_DeliveryID,_DeliveryName,_DeliveryPhone);   
        }
        public void DeleteDelivery()
        {
            objDelivery.DeleteDelivery(_DeliveryID);
        }
        public DataTable GetDelivery()
        {
            return objDelivery.GetDelivery();
        }
    }
}
