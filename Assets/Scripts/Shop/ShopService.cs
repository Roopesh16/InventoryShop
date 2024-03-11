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
        private EventService eventService;

        private ShopView shopView;
        private BuyBoxView buyBoxView;
        private BuyBoxController buyBoxController;
        private ShopController shopController;
        #endregion ------------------

        #region --------- Private Methods ---------
        private void InitializeVariables(List<ItemScriptableObject> shopItems)
        {
            itemService.SpawnShopItems();
            shopController = new(eventService, this, shopView, shopItems);
            buyBoxController = new(buyBoxView, this, itemService);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopService(ShopView shopView, BuyBoxView buyBoxView)
        {
            this.shopView = shopView;
            this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService, List<ItemScriptableObject> shopItems)
        {
            this.itemService = itemService;
            this.eventService = eventService;

            InitializeVariables(shopItems);
        }

        public void DisplayItemInfo(string name, Sprite icon, string description, int buyCost, int quantity)
        {
            shopView.DisplayItemInfo(name, icon, description, buyCost, quantity);
        }

        public void SetBuyItemData(string itemName, int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemName, itemBuyCost, itemQuantity);
        public void DisableDescription() => shopController.DisableDescription();
        public void SetItemQuantity(int quantity) => shopController.SetItemQuantity(itemService.ShopSelectedIndex, quantity);
        #endregion ------------------
    }
}
