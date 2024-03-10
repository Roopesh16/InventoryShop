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

        private Transform inventoryGridTransform;
        private InventoryView inventoryView;
        // private SellBoxView sellBoxView;
        // private BuyBoxController buyBoxController;
        private InventoryController inventoryController;
        #endregion ------------------

        #region --------- Private Methods ---------
        private void InitializeVariables(EventService eventService, List<ItemScriptableObject> shopItems)
        {
            itemService.SpawnItems(eventService, inventoryGridTransform);
            inventoryController = new(eventService, this, inventoryView);
            // buyBoxController = new(buyBoxView, this);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public InventoryService(Transform shopGridTransform, InventoryView inventoryView)
        {
            this.inventoryGridTransform = shopGridTransform;
            this.inventoryView = inventoryView;
            // this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService, List<ItemScriptableObject> shopItems)
        {
            this.itemService = itemService;

            InitializeVariables(eventService, shopItems);
        }

        // public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => inventoryController.DisableDescription();

        // public void SetItemQuantity(int quantity) => inventoryController.SetItemQuantity(itemService.SelectedIndex, quantity);
        #endregion ------------------
    }
}
