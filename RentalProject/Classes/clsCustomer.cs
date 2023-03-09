using System;
using System.Data;

namespace RentalProject.Classes
{
    internal class clsCustomer : clsUser
    {

        private string _CustomerID, _CustomerLevel;
        RentalDataSetTableAdapters.CustomerTableAdapter objCustomer = new RentalDataSetTableAdapters.CustomerTableAdapter();

        public string CustomerID
        {
            set { _CustomerID = value; }
            get { return _CustomerID; }
        }
        public string CustomerLevel
        {
            get { return _CustomerLevel; }
            set { _CustomerLevel = value; }
        }
        public override void SaveUser()
        {
            objCustomer.Insert(CustomerID, CustomerLevel,AccountName,UserName,UserLocation,UserEmail,UserPhone,UserNRC,UserPassword,UserPassword,DateTime.Now,UserPhoto);
        }
        public override void EditUser()
        {
            objCustomer.UpdateCustomer(CustomerLevel, AccountName, UserName, UserLocation, UserEmail, UserPhone, UserNRC, UserPassword, UserPassword, UserPhoto, CustomerID);
        }
        public override void DeleteUser()
        {
            objCustomer.DeleteCustomer(CustomerID);
        }
        public override DataTable SelectUser()
        {
            return objCustomer.GetCustomer();
        }
    }
}
