using InventoryShop.Inventory.SellBox;
using InventoryShop.Services.Events;
using InventoryShop.Inventory;
using UnityEngine;
using UnityEngine.UI;

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
            sellBoxController = new(sellBoxView, this, eventService);
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

        public void DisplayItemInfo(string name, Sprite icon, string description, int buyCost, int quantity)
        {
            inventoryView.DisplayItemInfo(name, icon, description, buyCost, quantity);
        }

        public void SetSellItemData(string itemName, int itemSellCost, int itemQuantity) => sellBoxController.SetSellItemData(itemName, itemSellCost, itemQuantity);
        public void DisableDescription() => inventoryController.DisableDescription();
        public void DisableEmptyBox() => inventoryController.DisableEmptyBox();
        public void SetItemQuantity(int quantity) => inventoryController.SetItemQuantity(itemService.InventorySelectedIndex, quantity);
        #endregion ------------------
    }
}
