using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Classes
{
    internal abstract class clsUser
    {
        private string _AccountName, _UserPassword, _UserEmail, _UserPhone, _UserLocation, _UserNRC, _UserName, _UserInfo;
        private DateTime _UserRegisterDate;
        private byte[] _UserPhoto;

        public string AccountName
        {
            set { _AccountName = value; }
            get { return _AccountName; }
        }
        public string UserPassword
        {
            set { _UserPassword = value; }
            get { return _UserPassword; }
        }
        public string UserEmail
        {
            set { _UserEmail = value; }
            get { return _UserEmail; }
        }
        public string UserPhone
        {
            set { _UserPhone = value; }
            get { return _UserPhone; }
        }
        public string UserLocation
        {
            set { _UserLocation = value; }
            get { return _UserLocation; }
        }
        public string UserNRC
        {
            set { _UserNRC = value; }
            get { return _UserNRC; }
        }
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        public string UserInfo
        {
            set { _UserInfo = value; }
            get { return _UserInfo; }
        }
        public byte[] UserPhoto
        {
            set { _UserPhoto = value; }
            get { return _UserPhoto; }
        }
        public DateTime UserRegisterDate
        {
            set { _UserRegisterDate = value; }
            get { return _UserRegisterDate; }

        }

        public abstract void SaveUser();
        public abstract void EditUser();
        public abstract void DeleteUser();
        public abstract DataTable SelectUser();
    }
}
