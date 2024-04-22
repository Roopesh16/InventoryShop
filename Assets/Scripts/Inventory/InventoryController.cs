using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Services;

namespace InventoryShop.Inventory
{
    public class InventoryController
    {
        #region --------- Private Variables ---------

        private EventService eventService;

        private InventoryView inventoryView;
        private InventoryModel inventoryModel;
        private List<ItemScriptableObject> inventoryItems = new();
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public InventoryController(EventService eventService, InventoryService inventoryService, InventoryView inventoryView)
        {
            this.eventService = eventService;

            inventoryModel = new(this);
            this.inventoryView = inventoryView;
            this.inventoryView.SetInventoryController(this);
            this.inventoryView.SetupShopView(eventService, inventoryService);
        }

        public void DisableDescription() => inventoryView.DisableDescription();
        public void DisableEmptyBox() => inventoryView.ToggleEmptyBox(false);
        public void EnableEmptyBox() => inventoryView.ToggleEmptyBox(true);
        public void SetItemQuantity(int index, int quantity) => inventoryModel.SetItemQuantity(index, quantity);
        public void AddItemData(ItemScriptableObject item, int quantity) => inventoryModel.AddInventoryData(item, quantity);
        public void RemoveItemData(string itemName) => inventoryModel.RemoveItemData(itemName);
        public float GetMaxWeight() => inventoryModel.GetMaxWeight();
        public float GetCurrentWeight() => inventoryModel.GetCurrentWeight();

        public void IncreaseInventoryWeight(float weight)
        {
            float newWeight = inventoryModel.GetCurrentWeight() + weight;
            if (newWeight >= inventoryModel.GetMaxWeight())
                inventoryView.ToggleResourceBtn(false);
            inventoryModel.SetInventoryWeight(newWeight);
            inventoryView.UpdateWeightText();
        }

        public void DecreaseInventoryWeight(float weight)
        {
            float newWeight = inventoryModel.GetCurrentWeight() - weight;

            if(newWeight < inventoryModel.GetMaxWeight())
                inventoryView.ToggleResourceBtn(true);
                
            if (newWeight <= 0)
                newWeight = 0;

            inventoryModel.SetInventoryWeight(newWeight);
            inventoryView.UpdateWeightText();
        }
        #endregion ------------------
    }
}
