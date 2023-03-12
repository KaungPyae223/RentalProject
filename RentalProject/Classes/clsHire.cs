using System;
using System.Data;

namespace RentalProject.Classes
{
    internal class clsHire
    {
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        RentalTableAdapters.SP_ExtendedDateTableAdapter objDate = new RentalTableAdapters.SP_ExtendedDateTableAdapter();

        private string _HireID, _CustomerID, _DeliveryID, _HireLocation, _CustomerPhone;
        private int _DeliveryCost, _TotalHirePricePerMonth, _InsuranceCost, _TotalHireQty;
        private DateTime _HireDate, _DeadlineDate, _ReturnDate;

        public string HireID
        {
            get { return _HireID; }
            set { _HireID = value; }
        }
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string DeliveryID
        {
            get { return _DeliveryID; }
            set { _DeliveryID = value; }
        }
        public string HireLocation
        {
            get { return _HireLocation; }
            set { _HireLocation = value; }
        }
        public string CustomerPhone
        {
            get { return _CustomerPhone; }
            set { _CustomerPhone = value; }
        }
        public int DeliveryCost
        {
            get { return _DeliveryCost; }
            set { _DeliveryCost = value; }
        }
        public int TotalHirePricePerMonth
        {
            get { return _TotalHirePricePerMonth; }
            set { _TotalHirePricePerMonth = value; }
        }
        public int InsuranceCost
        {
            get { return _InsuranceCost; }
            set { _InsuranceCost = value; }
        }
        public int TotalHireQty
        {
            get { return _TotalHireQty; }
            set { _TotalHireQty = value; }
        }

        public DateTime HireDate
        {
            get { return _HireDate; }
            set { _HireDate = value; }
        }
        public DateTime DeadlineDate
        {
            get { return _DeadlineDate; }
            set { _DeadlineDate = value; }
        }
        public DateTime ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }
        public void SaveHire()
        {
            DataTable DT = objDate.GetDate(DateTime.Now, 3);
            DateTime Deadline = Convert.ToDateTime(DT.Rows[0][0]);
            objHire.Insert(HireID, CustomerID, DeliveryID, DeliveryCost, TotalHirePricePerMonth, DateTime.Now, HireLocation, CustomerPhone, Deadline, InsuranceCost, null, TotalHireQty);
        }

    }
}
