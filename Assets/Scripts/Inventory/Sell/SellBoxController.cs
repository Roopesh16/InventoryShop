using InventoryShop.Services;

namespace InventoryShop.Inventory.SellBox
{
    public class SellBoxController
    {
        #region --------- Private Variables ---------
        private InventoryService inventoryService;

        private SellBoxModel sellBoxModel;
        private SellBoxView sellBoxView;

        private const int itemCount = 0;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public SellBoxController(SellBoxView sellBoxView, InventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            sellBoxModel = new(itemCount);
            sellBoxModel.SetSellBoxController(this);

            this.sellBoxView = sellBoxView;
            this.sellBoxView.SetSellBoxView(itemCount);
            this.sellBoxView.SetSellBoxController(this);
        }

        public void IncrementItemCount()
        {
            sellBoxModel.itemCount++;
            sellBoxView.EnableNegativeBtn();
            if (sellBoxModel.itemCount >= sellBoxModel.itemQuantity)
            {
                sellBoxModel.itemCount = sellBoxModel.itemQuantity;
                sellBoxView.DisablePositiveBtn();
            }
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }

        public void DecrementItemCount()
        {
            sellBoxModel.itemCount--;
            sellBoxView.EnablePositiveBtn();
            if (sellBoxModel.itemCount <= 0)
            {
                sellBoxModel.itemCount = 0;
                sellBoxView.DisableNegativeBtn();
            }
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }

        public void SetSellItemData(int itemSellCost, int itemQuantity)
        {
            sellBoxModel.SetItemData(itemSellCost, itemQuantity);
            sellBoxView.EnableSellBox();
        }

        public void ResetItemCounter(bool hasBought)
        {
            if (hasBought)
            {
                sellBoxModel.itemQuantity -= sellBoxModel.itemCount;
                if (sellBoxModel.itemQuantity <= 0)
                {
                    sellBoxModel.itemQuantity = 0;
                    inventoryService.DisableDescription();
                    sellBoxView.DisablePositiveBtn();
                    sellBoxView.DisableNegativeBtn();
                }
                inventoryService.SetItemQuantity(sellBoxModel.itemQuantity);
            }

            sellBoxModel.itemCount = 0;
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }
        #endregion ------------------
    }
}

