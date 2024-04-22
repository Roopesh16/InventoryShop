using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using InventoryShop.Shop;
using InventoryShop.Shop.BuyBox;
using InventoryShop.Transaction;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Services
{
    public class ShopService
    {
        #region --------- Private Variables ---------

        private ItemService itemService;
        private EventService eventService;
        private ShopView shopView;
        private TransactionBoxView buyBoxView;
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

        public ShopService(ShopView shopView, TransactionBoxView buyBoxView)
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

        public void DisplayItemInfo(string name, Sprite icon, string description, int buyCost, int quantity, float weight)
        {
            shopView.DisplayItemInfo(name, icon, description, buyCost, quantity, weight);
        }

        public void SetBuyItemData(string itemName, int itemBuyCost, int itemQuantity, float itemWeight) => buyBoxController.SetItemData(itemName, itemBuyCost, itemQuantity, itemWeight);
        public void DisableDescription() => shopController.DisableDescription();
        public void SetItemQuantity(int quantity) => shopController.SetItemQuantity(itemService.ShopSelectedIndex, quantity);
        #endregion ------------------
    }
}
