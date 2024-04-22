using InventoryShop.Inventory;
using InventoryShop.Inventory.SellBox;
using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using InventoryShop.Transaction;
using UnityEngine;

namespace InventoryShop.Services
{
    public class InventoryService
    {
        #region --------- Private Variables ---------

        private ItemService itemService;
        private EventService eventService;

        private InventoryView inventoryView;
        private TransactionBoxView sellBoxView;
        private SellBoxController sellBoxController;
        private InventoryController inventoryController;
        #endregion ------------------

        #region --------- Private Methods ---------

        private void InitializeVariables()
        {
            inventoryController = new(eventService, this, inventoryView);
            sellBoxController = new(sellBoxView, this, itemService);
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        public InventoryService(InventoryView inventoryView, TransactionBoxView sellBoxView)
        {
            this.inventoryView = inventoryView;
            this.sellBoxView = sellBoxView;
        }

        public void Init(EventService eventService, ItemService itemService)
        {
            this.itemService = itemService;
            this.eventService = eventService;

            InitializeVariables();
        }

        public void DisplayItemInfo(string name, Sprite icon, string description, int buyCost, int quantity, float weight)
        {
            inventoryView.DisplayItemInfo(name, icon, description, buyCost, quantity, weight);
        }

        public void SetSellItemData(string itemName, int itemSellCost, int itemQuantity, float itemWeight) => sellBoxController.SetItemData(itemName, itemSellCost, itemQuantity, itemWeight);
        public void DisableDescription() => inventoryController.DisableDescription();
        public void DisableEmptyBox() => inventoryController.DisableEmptyBox();
        public void EnableEmptyBox() => inventoryController.EnableEmptyBox();
        public void SetItemQuantity(int quantity) => inventoryController.SetItemQuantity(itemService.InventorySelectedIndex, quantity);
        public void AddInventoryItem(ItemScriptableObject item, int quantity) => inventoryController.AddItemData(item, quantity);
        public void RemoveInventoryItem(string itemName) => inventoryController.RemoveItemData(itemName);

        public float GetInventoryMaxWeight() => inventoryController.GetMaxWeight();
        public float GetInventoryCurrentWeight() => inventoryController.GetCurrentWeight();
        public void IncreaseInventoryWeight(float weight) => inventoryController.IncreaseInventoryWeight(weight);
        public void DecreaseInventoryWeight(float weight) => inventoryController.DecreaseInventoryWeight(weight);
        #endregion ------------------
    }
}
