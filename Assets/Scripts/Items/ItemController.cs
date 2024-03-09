using InventoryShop.Events;
using InventoryShop.Managers;
using InventoryShop.ScriptableObjects;
using UnityEngine;

namespace InventoryShop.Items
{
    public class ItemController
    {
        #region --------- Private Variables ---------
        private ItemModel itemModel;
        private ItemView itemView;
        private bool isSelected = false;
        #endregion ------------------

        #region --------- Public Variables ---------

        #endregion ------------------

        #region --------- Private Methods ---------
        private void DecrementItemQuantity(int quantity)
        {
            itemModel.itemQuantity -= quantity;

            if (itemModel.itemQuantity <= 0)
                itemView.DisableItemView();

            itemView.UpdateItemQuantity(itemModel.itemQuantity);
        }
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

        public void SendItemData()
        {
            EventManager.Instance.OnItemClick.InvokeEvent(itemModel.itemName, itemModel.itemIcon,
                                                        itemModel.itemDescription, itemModel.itemBuyPrice, itemModel.itemQuantity);
        }

        public void SelectCurrentItem()
        {
            isSelected = true;
            ItemManager.Instance.UnselectRestItems(this);
        }

        public void UnselectCurrentItem() => isSelected = false;
        #endregion ------------------
    }

}
