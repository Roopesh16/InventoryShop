using InventoryShop.Inventory.SellBox;
using InventoryShop.Services.Events;
using InventoryShop.Inventory;
using UnityEngine;
using UnityEngine.UI;
using InventoryShop.ScriptableObjects;

namespace InventoryShop.Services
{
    public class InventoryService
    {
        #region --------- Private Variables ---------
        private ItemService itemService;
        private EventService eventService;

        private InventoryView inventoryView;
        private SellBoxView sellBoxView;
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
        public InventoryService(InventoryView inventoryView, SellBoxView sellBoxView)
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

        public void SetSellItemData(string itemName, int itemSellCost, int itemQuantity) => sellBoxController.SetSellItemData(itemName, itemSellCost, itemQuantity);
        public void DisableDescription() => inventoryController.DisableDescription();
        public void DisableEmptyBox() => inventoryController.DisableEmptyBox();
        public void EnableEmptyBox() => inventoryController.EnableEmptyBox();
        public void SetItemQuantity(int quantity) => inventoryController.SetItemQuantity(itemService.InventorySelectedIndex, quantity);
        public void AddInventoryItem(ItemScriptableObject item, int quantity) => inventoryController.AddItemData(item, quantity);
        public void RemoveInventoryItem(string itemName) => inventoryController.RemoveItemData(itemName);

        public float GetInventoryMaxWeight() => inventoryController.GetMaxWeight();
        public float GetInventoryCurrentWeight() => inventoryController.GetCurrentWeight();
        public void IncreaseInventoryWeight(float weight) => inventoryController.IncreaseInventoryWeight(weight);
        #endregion ------------------
    }
}
