using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using InventoryShop.Services;
using UnityEngine;

namespace InventoryShop.Items
{
    public class ItemController
    {
        #region --------- Private Variables ---------
        private EventService eventService;
        private ItemService itemService;

        private ItemModel itemModel;
        private ItemView itemView;
        #endregion ------------------

        #region --------- Public Variables ---------
        public bool IsSelected { get; set; } = false;

        #endregion ------------------

        #region --------- Private Methods ---------

        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemController(EventService eventService, ItemService itemService, ItemScriptableObject item,
                                    ItemView itemView, Transform parentTransform)
        {
            this.eventService = eventService;
            this.itemService = itemService;

            itemModel = new(item.itemName, item.itemType, item.itemIcon, item.itemDescription, item.itemBuyPrice,
                            item.itemSellPrice, item.itemWeight, item.itemRarity, item.itemQuantity);
            itemModel.SetItemController(this);

            this.itemView = GameObject.Instantiate<ItemView>(itemView, parentTransform);
            this.itemView.SetItemView(item.itemIcon, item.itemQuantity);
            this.itemView.SetItemController(this);
        }

        public ItemController(EventService eventService, ItemService itemService, ItemScriptableObject item,
                                    ItemView itemView, Transform parentTransform,int quantity)
        {
            this.eventService = eventService;
            this.itemService = itemService;

            itemModel = new(item.itemName, item.itemType, item.itemIcon, item.itemDescription, item.itemBuyPrice,
                            item.itemSellPrice, item.itemWeight, item.itemRarity, quantity);
            itemModel.SetItemController(this);

            this.itemView = GameObject.Instantiate<ItemView>(itemView, parentTransform);
            this.itemView.SetItemView(item.itemIcon, quantity);
            this.itemView.SetItemController(this);
        }

        public void SendItemData()
        {
            eventService.OnItemClick.InvokeEvent(itemModel.itemName, itemModel.itemIcon,
                                                        itemModel.itemDescription, itemModel.itemBuyPrice, itemModel.itemQuantity);
        }

        public void SelectCurrentItem()
        {
            IsSelected = true;
            itemService.UnselectRestItems(this);
        }

        public void DecrementItemQuantity(int quantity)
        {
            itemModel.itemQuantity -= quantity;

            if (itemModel.itemQuantity <= 0)
            {
                itemModel.itemQuantity = 0;
                itemView.DisableItemBtn();
            }

            itemView.UpdateItemQuantity(itemModel.itemQuantity);
        }

        public void DisableItemView() => itemView.gameObject.SetActive(false);
        public void EnableItemView() => itemView.gameObject.SetActive(true);

        public ItemType GetItemType() => itemModel.itemType;
        #endregion ------------------

    }
}
