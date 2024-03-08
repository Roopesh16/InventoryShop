using UnityEngine;
using InventoryShop.ScriptableObjects;

namespace InventoryShop.Items
{
    public class ItemController
    {
        #region --------- Private Variables ---------
        private ItemModel itemModel;
        private ItemView itemView;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemController(ItemScriptableObject item, ItemView itemView, Transform parentTransform)
        {
            itemModel = new(item.itemType, item.itemIcon, item.itemDescription, item.itemBuyPrice,
                            item.itemSellPrice, item.itemWeight, item.itemRarity, item.itemQuantity);
            itemView = GameObject.Instantiate(itemView, parentTransform);
        }
        #endregion ------------------
    }

}
