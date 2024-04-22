using InventoryShop.Services;
using InventoryShop.Services.Events;
using InventoryShop.Managers;
namespace InventoryShop.Inventory.SellBox
{
    public class SellBoxController
    {
        #region --------- Private Variables ---------

        private InventoryService inventoryService;
        private ItemService itemService;

        private SellBoxModel sellBoxModel;
        private SellBoxView sellBoxView;

        private const int itemCount = 0;
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public SellBoxController(SellBoxView sellBoxView, InventoryService inventoryService, ItemService itemService)
        {
            this.inventoryService = inventoryService;
            this.itemService = itemService;

            sellBoxModel = new(itemCount);
            sellBoxModel.SetSellBoxController(this);

            this.sellBoxView = sellBoxView;
            this.sellBoxView.SetSellBoxView(itemCount);
            this.sellBoxView.SetSellBoxController(this);
        }

        public void IncrementItemCount()
        {
            sellBoxModel.itemCount++;
            sellBoxView.ToggleNegativeBtn(true);
            if (sellBoxModel.itemCount >= sellBoxModel.itemQuantity)
            {
                sellBoxModel.itemCount = sellBoxModel.itemQuantity;
                sellBoxView.TogglePositiveBtn(false);
            }
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }

        public void DecrementItemCount()
        {
            sellBoxModel.itemCount--;
            sellBoxView.TogglePositiveBtn(true);
            if (sellBoxModel.itemCount <= 0)
            {
                sellBoxModel.itemCount = 0;
                sellBoxView.ToggleNegativeBtn(false);
            }
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }

        public void SetSellItemData(string itemName, int itemSellCost, int itemQuantity, float itemWeight)
        {
            sellBoxModel.SetItemData(itemName, itemSellCost, itemQuantity, itemWeight);
            sellBoxView.EnableSellBox();
        }

        public void ResetItemCounter(bool hasSold)
        {
            if (hasSold)
            {
                sellBoxModel.itemQuantity -= sellBoxModel.itemCount;
                if (sellBoxModel.itemQuantity <= 0)
                {
                    sellBoxModel.itemQuantity = 0;
                    inventoryService.DisableDescription();
                    sellBoxView.TogglePositiveBtn(false);
                    sellBoxView.ToggleNegativeBtn(false);
                    itemService.RemoveInventoryItem(sellBoxModel.itemName);
                }
                inventoryService.SetItemQuantity(sellBoxModel.itemQuantity);
                itemService.AddShopItems(sellBoxModel.itemName, sellBoxModel.itemCount);
            }

            sellBoxModel.itemCount = 0;
            sellBoxView.UpdateSellCounter(sellBoxModel.itemCount, sellBoxModel.itemSellCost);
        }

        public void ValidateSellTransaction()
        {
            if (GameManager.Instance.ValidateSellTransaction(sellBoxModel.itemCount, sellBoxModel.itemCount * sellBoxModel.itemSellCost, sellBoxModel.itemCount * sellBoxModel.itemWeight))
                ResetItemCounter(true);
        }
        #endregion ------------------
    }
}

