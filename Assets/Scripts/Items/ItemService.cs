using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Services;
using InventoryShop.Items;
using UnityEngine;

namespace InventoryShop.Services
{
    public class ItemService
    {
        #region --------- Private Variables ---------
        private List<ItemScriptableObject> itemsList = new();
        private ItemView itemPrefab;
        private List<ItemController> itemSpawned = new();
        private Transform shopGridTransform;
        private Transform inventoryGridTransform;

        private EventService eventService;
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

        public void Init(EventService eventService)
        {
            this.eventService = eventService;
        }

        public void SpawnShopItems()
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new(eventService, this, item, itemPrefab, shopGridTransform);
                itemSpawned.Add(itemController);
            }
        }

        public void SpawnInventoryItems(string itemName)
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                if (itemName == item.itemName)
                {
                    ItemController itemController = new(eventService, this, item, itemPrefab, inventoryGridTransform);
                    itemSpawned.Add(itemController);
                }
            }
        }

        public void UnselectRestItems(ItemController selectedItem)
        {
            foreach (ItemController item in itemSpawned)
            {
                if (item != selectedItem)
                {
                    item.IsSelected = false;
                }
            }
        }

        public void UpdateSelectedItem(int quantity)
        {
            for (int i = 0; i < itemSpawned.Count; i++)
            {
                if (itemSpawned[i].IsSelected)
                {
                    SelectedIndex = i;
                    itemSpawned[i].DecrementItemQuantity(quantity);
                }
            }
        }

        public void DisplayType(ItemType itemType)
        {
            foreach (ItemController item in itemSpawned)
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
