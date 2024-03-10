using System;
using System.Collections;
using System.Collections.Generic;
using InventoryShop.ScriptableObjects;
using UnityEngine;

namespace InventoryShop.Shop
{
    public class ItemData
    {
        public string itemName;
        public ItemType itemType;
        public int itemBuyPrice;
        public int itemQuantity;
    }

    public class ShopModel
    {
        #region --------- Private Variables ---------
        #endregion ------------------

        #region --------- Public Variables ---------
        public List<ItemData> itemDataList = new();
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopModel(List<ItemScriptableObject> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                ItemData itemData = new()
                {
                    itemName = itemList[i].itemName,
                    itemType = itemList[i].itemType,
                    itemBuyPrice = itemList[i].itemBuyPrice,
                    itemQuantity = itemList[i].itemQuantity
                };

                itemDataList.Add(itemData);
            }
        }

        public ItemData GetItemData(int index)
        {
            return itemDataList[index];
        }
        #endregion ------------------
    }
}