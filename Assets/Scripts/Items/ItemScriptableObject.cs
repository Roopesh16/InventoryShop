using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace InventoryShop.Items
{
    [CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "Items/ItemScriptableObject")]
    public class ItemScriptableObject : ScriptableObject
    {
        public ItemType itemType;
        public Sprite itemIcon;
        public string itemDescription;
        public int itemBuyPrice;
        public int itemSellPrice;
        public float itemWeight;
        public ItemRarity itemRarity;
        public int itemQuantity;
    }

    [CreateAssetMenu(fileName="ItemSOList", menuName="Items/ItemSOList")]
    public class ItemSOList:ScriptableObject
    {
        public List<ItemScriptableObject> itemList = new();
    }
}
