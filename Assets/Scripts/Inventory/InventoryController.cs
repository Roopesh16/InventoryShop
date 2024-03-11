using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Services;
using UnityEngine;

namespace InventoryShop.Inventory
{
    public class InventoryController
    {
        #region --------- Private Variables ---------
        private InventoryView inventoryView;
        private InventoryModel inventoryModel;
        private List<ItemScriptableObject> inventoryItems = new();
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public InventoryController(EventService eventService, InventoryService inventoryService, InventoryView inventoryView)
        {
            inventoryModel = new(this);
            this.inventoryView = inventoryView;
            this.inventoryView.SetupShopView(eventService, inventoryService);
            this.inventoryView.SetInventoryController(this);
        }

        public void DisableDescription() => inventoryView.DisableDescription();
        public void DisableEmptyBox() => inventoryView.ToggleEmptyBox(false);

        public void SetItemQuantity(int index, int quantity) => inventoryModel.SetItemQuantity(index, quantity);
        #endregion ------------------
    }
}
