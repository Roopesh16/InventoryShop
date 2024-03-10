namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxModel
    {
        #region --------- Private Variables ---------
        private BuyBoxController buyBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public string itemName;
        public int itemCount;
        public int itemBuyCost;
        public int itemQuantity;
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public BuyBoxModel(int itemCount)
        {
            this.itemCount = itemCount;
        }

        public void SetBuyBoxController(BuyBoxController buyBoxController) => this.buyBoxController = buyBoxController;

        public void SetItemData(string itemName,int itemBuyCost, int itemQuantity)
        {
            this.itemName = itemName;
            this.itemBuyCost = itemBuyCost;
            this.itemQuantity = itemQuantity;
        }
        #endregion ------------------
    }
}
