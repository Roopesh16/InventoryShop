namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxController
    {
        #region --------- Private Variables ---------
        private BuyBoxModel buyBoxModel;
        private BuyBoxView buyBoxView;

        private const int itemCount = 0;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public BuyBoxController(BuyBoxView buyBoxView)
        {
            buyBoxModel = new(itemCount);
            buyBoxModel.SetBuyBoxController(this);

            this.buyBoxView = buyBoxView;
            this.buyBoxView.SetBuyBoxView(itemCount);
            this.buyBoxView.SetBuyBoxController(this);
        }

        public void IncrementItemCount()
        {
            buyBoxModel.itemCount++;
            buyBoxView.EnableNegativeBtn();
            if (buyBoxModel.itemCount >= buyBoxModel.itemQuantity)
            {
                buyBoxModel.itemCount = buyBoxModel.itemQuantity;
                buyBoxView.DisablePositiveBtn();
            }
            buyBoxView.UpdateBuyCounter(buyBoxModel.itemCount, buyBoxModel.itemBuyCost);
        }

        public void DecrementItemCount()
        {
            buyBoxModel.itemCount--;
            buyBoxView.EnablePositiveBtn();
            if (buyBoxModel.itemCount <= 0)
            {
                buyBoxModel.itemCount = 0;
                buyBoxView.DisableNegativeBtn();
            }
            buyBoxView.UpdateBuyCounter(buyBoxModel.itemCount, buyBoxModel.itemBuyCost);
        }

        public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxModel.SetItemData(itemBuyCost, itemQuantity);
        #endregion ------------------
    }
}

