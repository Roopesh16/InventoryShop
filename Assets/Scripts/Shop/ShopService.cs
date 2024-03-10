using InventoryShop.Services.Events;
using InventoryShop.Shop.BuyBox;
using InventoryShop.Shop;
using UnityEngine;
using System.Collections.Generic;
using InventoryShop.ScriptableObjects;

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
        private void InitializeVariables(EventService eventService, List<ItemScriptableObject> shopItems)
        {
            itemService.SpawnItems(eventService, shopGridTransform);
            shopController = new(eventService, this, shopView, shopItems);
            buyBoxController = new(buyBoxView, this);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopService(Transform shopGridTransform, ShopView shopView, BuyBoxView buyBoxView)
        {
            this.shopGridTransform = shopGridTransform;
            this.shopView = shopView;
            this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService, List<ItemScriptableObject> shopItems)
        {
            this.itemService = itemService;

            InitializeVariables(eventService, shopItems);
        }

        public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => shopController.DisableDescription();
        #endregion ------------------
    }
}
