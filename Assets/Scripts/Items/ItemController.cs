using InventoryShop.ScriptableObjects;
using UnityEngine;

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
            itemModel = new(item.itemName, item.itemType, item.itemIcon, item.itemDescription, item.itemBuyPrice,
                            item.itemSellPrice, item.itemWeight, item.itemRarity, item.itemQuantity);
            itemModel.SetItemController(this);

            this.itemView = GameObject.Instantiate<ItemView>(itemView, parentTransform);
            this.itemView.SetItemView(item.itemIcon, item.itemQuantity);
            this.itemView.SetItemController(this);
        }
        #endregion ------------------
    }

}
