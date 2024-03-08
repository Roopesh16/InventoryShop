using UnityEngine;

namespace InventoryShop.Items
{
    public class ItemModel
    {
        #region --------- Private Variables ---------
        private ItemController itemController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public ItemType itemType;
        public Sprite itemIcon;
        public string itemDescription;
        public int itemBuyPrice;
        public int itemSellPrice;
        public float itemWeight;
        public ItemRarity itemRarity;
        public int itemQuantity;
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ItemModel(ItemType itemType, Sprite itemIcon, string itemDescription, int itemBuyPrice,
                        int itemSellPrice, float itemWeight, ItemRarity itemRarity, int itemQuantity)
        {
            this.itemType = itemType;
            this.itemIcon = itemIcon;
            this.itemDescription = itemDescription;
            this.itemBuyPrice = itemBuyPrice;
            this.itemSellPrice = itemSellPrice;
            this.itemWeight = itemWeight;
            this.itemQuantity = itemQuantity;
        }

        public void SetItemController(ItemController itemController) => this.itemController = itemController;
        #endregion ------------------
    }

}
