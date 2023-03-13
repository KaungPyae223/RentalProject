namespace RentalProject.Classes
{
    internal class clsHieDetails
    {
        private string _ItemID, _HireID;
        RentalTableAdapters.HireDetailsTableAdapter objHireDeatils = new RentalTableAdapters.HireDetailsTableAdapter();
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string HireID
        {
            get { return _HireID; }
            set { _HireID = value; }
        }
        public void AddHireDetails()
        {
            objHireDeatils.Insert(ItemID, HireID);
        }
    }
}
