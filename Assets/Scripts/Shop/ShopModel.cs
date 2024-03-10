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
        public Sprite itemIcon;
        public string itemDescription;
        public int itemBuyPrice;
        public float itemWeight;
        public ItemRarity itemRarity;
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
                    itemIcon = itemList[i].itemIcon,
                    itemDescription = itemList[i].itemDescription,
                    itemBuyPrice = itemList[i].itemBuyPrice,
                    itemWeight = itemList[i].itemWeight,
                    itemRarity = itemList[i].itemRarity,
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