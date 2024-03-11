using System;
using System.Collections;
using System.Collections.Generic;
using InventoryShop.ScriptableObjects;
using UnityEngine;

namespace InventoryShop.Inventory
{
    public class ItemData
    {
        public string itemName;
        public ItemType itemType;
        public ItemRarity itemRarity;
        public int itemSellPrice;
        public int itemQuantity;
        public float itemWeight;
    }

    public class InventoryModel
    {
        #region --------- Private Variables ---------
        private InventoryController inventoryController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public List<ItemData> itemDataList = new();
        #endregion ------------------

        #region --------- Private Methods ---------

        #endregion ------------------

        #region --------- Public Methods ---------
        public InventoryModel(InventoryController inventoryController)
        {
            this.inventoryController = inventoryController;
        }

        public void SetItemQuantity(int index, int quantity)
        {
            if (itemDataList.Count != 0)
            {
                itemDataList[index].itemQuantity = quantity;
            }
        }

        public void AddInventoryData(ItemScriptableObject item, int quantity)
        {
            ItemData itemData = new()
            {
                itemName = item.itemName,
                itemType = item.itemType,
                itemRarity = item.itemRarity,
                itemQuantity = quantity,
                itemSellPrice = item.itemSellPrice,
                itemWeight = item.itemWeight
            };

            itemDataList.Add(itemData);
        }
        #endregion ------------------
    }
}