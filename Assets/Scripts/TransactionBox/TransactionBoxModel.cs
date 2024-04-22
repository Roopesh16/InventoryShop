namespace InventoryShop.Transaction
{
    public class TransactionBoxModel
    {
        #region --------- Private Variables ---------

        private TransactionBoxController transactionBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------

        public string itemName;
        public int itemCount;
        public int itemCost;
        public int itemQuantity;
        public float itemWeight;
        #endregion ------------------

        #region --------- Public Methods ---------

        public TransactionBoxModel(int itemCount) => this.itemCount = itemCount;

        public void SetController(TransactionBoxController transactionBoxController) => this.transactionBoxController = transactionBoxController;

        public void SetItemData(string itemName, int itemCost, int itemQuantity, float itemWeight)
        {
            this.itemName = itemName;
            this.itemCost = itemCost;
            this.itemQuantity = itemQuantity;
            this.itemWeight = itemWeight;
        }
        #endregion ------------------
    }
}
