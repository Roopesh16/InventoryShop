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
        private const float maxWeight = 50f;
        private float currentWeight = 0f;
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

        public void RemoveItemData(string itemName)
        {
            foreach (ItemData item in itemDataList)
            {
                if (item.itemName == itemName)
                {
                    itemDataList.Remove(item);
                    return;
                }
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

        public float GetMaxWeight() => maxWeight;
        public float GetCurrentWeight() => currentWeight;
        public void SetInventoryWeight(float weight) => currentWeight = weight;
        #endregion ------------------
    }
}