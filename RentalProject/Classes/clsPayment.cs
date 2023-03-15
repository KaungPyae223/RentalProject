using System;
using System.Data;

namespace RentalProject.Classes
{
    internal class clsPayment
    {
        private string _HireID, _Description, _PaymentType;
        private int _Tax, _HireAmount, _TotalPaymentAmont;
        RentalTableAdapters.PaymentTableAdapter objPayment = new RentalTableAdapters.PaymentTableAdapter();
        public string HireID
        {
            get { return _HireID; }
            set { _HireID = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string PaymentType
        {
            get { return _PaymentType; }
            set { _PaymentType = value; }
        }
        public int Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public int HireAmount
        {
            get { return _HireAmount; }
            set { _HireAmount = value; }
        }
        public int TotalPaymentAmont
        {
            get { return _TotalPaymentAmont; }
            set { _TotalPaymentAmont = value; }
        }
        public void AddPayment()
        {
            objPayment.Insert(HireID, HireAmount, DateTime.Now, PaymentType, Description, Tax, TotalPaymentAmont);
        }
        public DataTable getpayment()
        {
            return objPayment.GetPayment();

        }
    }
}
