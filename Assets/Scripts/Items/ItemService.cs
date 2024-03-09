using InventoryShop.ScriptableObjects;
using System.Collections.Generic;
using InventoryShop.Events;
using InventoryShop.Items;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace InventoryShop.Managers
{
    public class ItemService : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private List<ItemScriptableObject> itemsList = new();
        private ItemView itemPrefab;
        private static ItemService instance = null;
        private List<ItemController> itemSpawned = new();
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ItemService Instance
        {
            get { return instance; }
        }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemService(List<ItemScriptableObject> itemsList, ItemView itemPrefab)
        {
            this.itemsList = itemsList;
            this.itemPrefab = itemPrefab;
        }

        public void SpawnItems(EventService eventService, Transform parentTransform)
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new(eventService, item, itemPrefab, parentTransform);
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
