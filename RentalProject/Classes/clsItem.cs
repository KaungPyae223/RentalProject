using System.Data;

namespace RentalProject.Classes
{
    internal class clsItem
    {
        private string _ItemID, _ItemName, _BrandID, _TypeID, _PowerUsage, _TypicalUsage, _ModelYear, _Description;
        private int _OnHandQty, _PricePerMonth,_TotalQty;
        private byte[] _ItemImage;
        RentalTableAdapters.ItemTableAdapter objItem = new RentalTableAdapters.ItemTableAdapter();
        RentalTableAdapters.vi_ItemTableAdapter objvi_Item = new RentalTableAdapters.vi_ItemTableAdapter();
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        public string BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        public string PowerUsage
        {
            get { return _PowerUsage; }
            set { _PowerUsage = value; }
        }
        public string TypicalUsage
        {
            get { return _TypicalUsage; }
            set { _TypicalUsage = value; }
        }
        public string ModelYear
        {
            get { return _ModelYear; }
            set { _ModelYear = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int OnHandQty
        {
            get { return _OnHandQty; }
            set { _OnHandQty = value; }
        }
        public int PricePerMonth
        {
            get { return _PricePerMonth; }
            set { _PricePerMonth = value; }
        }
        public int TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }
        public byte[] ItemImage
        {
            get { return _ItemImage; }
            set { _ItemImage = value; }
        }
        
        public void InsertItem()
        {
            objItem.Insert(ItemID, BrandID, TypeID, ItemName, PowerUsage, TypicalUsage, ModelYear, TotalQty, PricePerMonth, Description, ItemImage, TotalQty);
        }
        public void UpdateItem()
        {
            objItem.UpdateItem(BrandID, TypeID, ItemName, PowerUsage,TypicalUsage,ModelYear, OnHandQty,PricePerMonth,Description,ItemImage,TotalQty,ItemID);
        }
        public DataTable GetItem()
        {
            return objvi_Item.GetVi_Item();

        }
        public DataTable getSP_Item(string ID, int a)
        {
            return objvi_Item.GetSP_Item(ID, a);
        }
        public void UpdateOnHandQty()
        {
            objItem.UpdateOnHandQty(OnHandQty, ItemID);
        }
        
    }
}
