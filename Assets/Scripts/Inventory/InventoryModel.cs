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
        public InventoryModel(List<ItemScriptableObject> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                ItemData itemData = new()
                {
                    itemName = itemList[i].itemName,
                    itemType = itemList[i].itemType,
                    itemRarity = itemList[i].itemRarity,
                    itemSellPrice = itemList[i].itemSellPrice,
                    itemQuantity = itemList[i].itemQuantity,
                    itemWeight = itemList[i].itemWeight
                };

                itemDataList.Add(itemData);
            }
        }

        public void SetItemQuantity(int index, int quantity)
        {
            itemDataList[index].itemQuantity = quantity;
        }
        #endregion ------------------
    }
}