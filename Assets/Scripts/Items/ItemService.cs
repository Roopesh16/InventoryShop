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
        private List<ItemTypeBtn> itemTypeBtns = new();
        private List<ItemController> itemSpawned = new();
        #endregion ------------------

        #region --------- Public Variables ---------
        public int SelectedIndex { get; private set; }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemService(List<ItemScriptableObject> itemsList, ItemView itemPrefab, List<ItemTypeBtn> itemTypeBtns)
        {
            this.itemsList = itemsList;
            this.itemPrefab = itemPrefab;
            this.itemTypeBtns = itemTypeBtns;
        }

        public void Init()
        {
            foreach (ItemTypeBtn itemTypeBtn in itemTypeBtns)
            {
                itemTypeBtn.Init(this);
            }
        }

        public void SpawnItems(EventService eventService, Transform parentTransform)
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new(eventService, this, item, itemPrefab, parentTransform);
                itemSpawned.Add(itemController);
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
