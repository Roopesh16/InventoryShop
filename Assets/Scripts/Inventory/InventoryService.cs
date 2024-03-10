using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Inventory;
using UnityEngine;

namespace InventoryShop.Services
{
    public class InventoryService
    {
        #region --------- Private Variables ---------
        private ItemService itemService;

        private InventoryView inventoryView;
        // private SellBoxView sellBoxView;
        // private BuyBoxController buyBoxController;
        private InventoryController inventoryController;
        #endregion ------------------

        #region --------- Private Methods ---------
        private void InitializeVariables(EventService eventService)
        {
            itemService.SpawnShopItems(eventService);
            inventoryController = new(eventService, this, inventoryView);
            // buyBoxController = new(buyBoxView, this);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public InventoryService(InventoryView inventoryView)
        {
            this.inventoryView = inventoryView;
            // this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService)
        {
            this.itemService = itemService;

            InitializeVariables(eventService);
        }

        // public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => inventoryController.DisableDescription();

        // public void SetItemQuantity(int quantity) => inventoryController.SetItemQuantity(itemService.SelectedIndex, quantity);
        #endregion ------------------
    }
}
