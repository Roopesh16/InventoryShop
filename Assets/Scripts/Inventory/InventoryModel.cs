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
        #endregion ------------------

        #region --------- Public Variables ---------
        public List<ItemData> itemDataList = new();
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public InventoryModel()
        {

        }

        public void SetItemQuantity(string itemName, int quantity)
        {
            if (itemDataList.Count != 0)
            {
                foreach (ItemData item in itemDataList)
                {
                    if (item.itemName == itemName)
                    {
                        item.itemQuantity = quantity;
                    }
                }
            }
        }

        public void AddInventoryData(ItemScriptableObject item)
        {
            ItemData itemData = new()
            {
                itemName = item.itemName,
                itemType = item.itemType,
                itemRarity = item.itemRarity,
                itemQuantity = item.itemQuantity,
                itemSellPrice = item.itemSellPrice,
                itemWeight = item.itemWeight
            };

            itemDataList.Add(itemData);
        }

        public void SetItemQuantity(int index, int quantity)
        {
            itemDataList[index].itemQuantity = quantity;
        }
        #endregion ------------------
    }
}