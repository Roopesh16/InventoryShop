using UnityEngine;

namespace InventoryShop.ScriptableObjects
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
}
