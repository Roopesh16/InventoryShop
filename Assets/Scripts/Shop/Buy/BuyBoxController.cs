using InventoryShop.Services;
using InventoryShop.Managers;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxController
    {
        #region --------- Private Variables ---------

        private ShopService shopService;
        private ItemService itemService;

        private BuyBoxModel buyBoxModel;
        private BuyBoxView buyBoxView;

        private const int itemCount = 0;
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public BuyBoxController(BuyBoxView buyBoxView, ShopService shopService, ItemService itemService)
        {
            this.shopService = shopService;
            this.itemService = itemService;

            buyBoxModel = new(itemCount);
            buyBoxModel.SetBuyBoxController(this);

            this.buyBoxView = buyBoxView;
            this.buyBoxView.SetBuyBoxView(itemCount);
            this.buyBoxView.SetBuyBoxController(this);
        }

        public void IncrementItemCount()
        {
            buyBoxModel.itemCount++;
            buyBoxView.ToggleNegativeBtn(true);
            if (buyBoxModel.itemCount >= buyBoxModel.itemQuantity)
            {
                buyBoxModel.itemCount = buyBoxModel.itemQuantity;
                buyBoxView.TogglePositiveBtn(false);
            }
            buyBoxView.UpdateBuyCounter(buyBoxModel.itemCount, buyBoxModel.itemBuyCost);
        }

        public void DecrementItemCount()
        {
            buyBoxModel.itemCount--;
            buyBoxView.TogglePositiveBtn(true);
            if (buyBoxModel.itemCount <= 0)
            {
                buyBoxModel.itemCount = 0;
                buyBoxView.ToggleNegativeBtn(false);
            }
            buyBoxView.UpdateBuyCounter(buyBoxModel.itemCount, buyBoxModel.itemBuyCost);
        }

        public void SetBuyItemData(string itemName, int itemBuyCost, int itemQuantity, float itemWeight)
        {
            buyBoxModel.SetItemData(itemName, itemBuyCost, itemQuantity, itemWeight);
            buyBoxView.EnableBuyBox();
        }

        public void ResetItemCounter(bool hasBought)
        {
            if (hasBought)
            {
                buyBoxModel.itemQuantity -= buyBoxModel.itemCount;
                if (buyBoxModel.itemQuantity <= 0)
                {
                    buyBoxModel.itemQuantity = 0;
                    shopService.DisableDescription();
                    buyBoxView.TogglePositiveBtn(false);
                    buyBoxView.ToggleNegativeBtn(false);
                }
                shopService.SetItemQuantity(buyBoxModel.itemQuantity);
                itemService.AddInventoryItems(buyBoxModel.itemName, buyBoxModel.itemCount);
            }

            buyBoxModel.itemCount = 0;
            buyBoxView.UpdateBuyCounter(buyBoxModel.itemCount, buyBoxModel.itemBuyCost);
        }

        public void ValidateBuyTransaction()
        {
            if (GameManager.Instance.ValidateBuyTransaction(buyBoxModel.itemCount,
                                                            buyBoxModel.itemCount*buyBoxModel.itemBuyCost,
                                                            buyBoxModel.itemCount*buyBoxModel.itemWeight))
                ResetItemCounter(true);
        }
        #endregion ------------------
    }
}

