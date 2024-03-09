using InventoryShop.ScriptableObjects;
using System.Collections.Generic;
using InventoryShop.Items;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class ItemManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private List<ItemScriptableObject> itemsList = new();
        [SerializeField] private ItemView itemPrefab;
        #endregion ------------------

        #region --------- Private Variables ---------
        private static ItemManager instance = null;
        private List<ItemController> itemSpawned = new();
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ItemManager Instance
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
        public void SpawnItems(Transform parentTransform)
        {
            foreach (ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new(item, itemPrefab, parentTransform);
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
