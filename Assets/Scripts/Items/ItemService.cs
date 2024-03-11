using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Services;
using InventoryShop.Items;
using UnityEngine;
using InventoryShop.Managers;

namespace InventoryShop.Services
{
    public class ItemService
    {
        #region --------- Private Variables ---------
        private List<ItemScriptableObject> itemsList = new();
        private ItemView itemPrefab;
        private List<ItemController> shopItemSpawned = new();
        private List<ItemController> inventoryItemSpawned = new();
        private Transform shopGridTransform;
        private Transform inventoryGridTransform;

        private EventService eventService;
        private InventoryService inventoryService;
        #endregion ------------------

        #region --------- Public Variables ---------
        public int SelectedIndex { get; private set; }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemService(List<ItemScriptableObject> itemsList, ItemView itemPrefab, Transform shopGridTransform, Transform inventoryGridTransform)
        {
            this.itemsList = itemsList;
            this.itemPrefab = itemPrefab;
            this.shopGridTransform = shopGridTransform;
            this.inventoryGridTransform = inventoryGridTransform;
        }

        public void Init(EventService eventService, InventoryService inventoryService)
        {
            this.eventService = eventService;
            this.inventoryService = inventoryService;
        }

        public void SpawnShopItems()
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new(eventService, this, item, itemPrefab, shopGridTransform);
                shopItemSpawned.Add(itemController);
            }
        }

        public void AddInventoryItems(string itemName, int quantity)
        {
            if (inventoryItemSpawned.Count != 0)
            {
                foreach (ItemController item in inventoryItemSpawned)
                {
                    if (item.GetItemName() == itemName)
                    {
                        item.IncrementItemQuantity(quantity);
                    }
                }
            }
            else
            {
                foreach (ItemScriptableObject item in itemsList)
                {
                    if (itemName == item.itemName)
                    {
                        ItemController itemController = new(eventService, this, item, itemPrefab, inventoryGridTransform, quantity);

                        if (inventoryItemSpawned.Count == 0)
                            inventoryService.DisableEmptyBox();
                            
                        inventoryItemSpawned.Add(itemController);
                        UIManager.Instance.SetNotificationText(itemName + " ADDED!");
                    }
                }
            }
        }

        public void UnselectRestItems(ItemController selectedItem)
        {
            foreach (ItemController item in shopItemSpawned)
            {
                if (item != selectedItem)
                {
                    item.IsSelected = false;
                }
            }
        }

        public void UpdateSelectedItem(int quantity)
        {
            for (int i = 0; i < shopItemSpawned.Count; i++)
            {
                if (shopItemSpawned[i].IsSelected)
                {
                    SelectedIndex = i;
                    shopItemSpawned[i].DecrementItemQuantity(quantity);
                }
            }
        }

        public void DisplayType(ItemType itemType)
        {
            foreach (ItemController item in shopItemSpawned)
            {
                if (item.GetItemType() != itemType)
                {
                    item.DisableItemView();
                }
                else
                {
                    item.EnableItemView();
                }
            }
        }
        #endregion ------------------
    }

}
