using InventoryShop.Services.Events;
using InventoryShop.Shop.BuyBox;
using InventoryShop.Shop;
using UnityEngine;

namespace InventoryShop.Services
{
    public class ShopService
    {
        #region --------- Private Variables ---------
        private ItemService itemService;

        private Transform shopGridTransform;
        private ShopView shopView;
        private BuyBoxView buyBoxView;
        private BuyBoxController buyBoxController;
        private ShopController shopController;
        #endregion ------------------

        #region --------- Private Methods ---------
        private void InitializeVariables(EventService eventService)
        {
            itemService.SpawnItems(eventService, shopGridTransform);
            shopController = new(eventService, this, shopView);
            buyBoxController = new(buyBoxView,this);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopService(Transform shopGridTransform, ShopView shopView, BuyBoxView buyBoxView)
        {
            this.shopGridTransform = shopGridTransform;
            this.shopView = shopView;
            this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService)
        {
            this.itemService = itemService;

            InitializeVariables(eventService);
        }

        public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => shopController.DisableDescription();
        #endregion ------------------
    }
}
