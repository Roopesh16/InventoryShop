namespace InventoryShop.Inventory.SellBox
{
    public class SellBoxModel
    {
        #region --------- Private Variables ---------
        private SellBoxController sellBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public string itemName;
        public int itemCount;
        public int itemSellCost;
        public int itemQuantity;
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public SellBoxModel(int itemCount)
        {
            this.itemCount = itemCount;
        }

        public void SetSellBoxController(SellBoxController sellBoxController) => this.sellBoxController = sellBoxController;

        public void SetItemData(string itemName,int itemSellCost, int itemQuantity)
        {
            this.itemName = itemName;
            this.itemSellCost = itemSellCost;
            this.itemQuantity = itemQuantity;
        }
        #endregion ------------------
    }
}
