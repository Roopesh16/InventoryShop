using InventoryShop.ScriptableObjects;
using System.Collections.Generic;
using InventoryShop.Events;
using InventoryShop.Items;
using UnityEngine;

namespace InventoryShop.Managers
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
                    item.UnselectCurrentItem();
                }
            }
        }

        public void UpdateSelectedItem(int quantity)
        {
            foreach (ItemController item in itemSpawned)
            {
                item.DecrementItemQuantity(quantity);
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
