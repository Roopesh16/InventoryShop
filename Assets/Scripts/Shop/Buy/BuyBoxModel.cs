namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxModel
    {
        #region --------- Private Variables ---------
        private BuyBoxController buyBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public int itemCount;
        public int itemBuyCost;
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public BuyBoxModel(int itemCount)
        {
            this.itemCount = itemCount;
        }

        public void SetBuyBoxController(BuyBoxController buyBoxController) => this.buyBoxController = buyBoxController;
        #endregion ------------------
    }
}