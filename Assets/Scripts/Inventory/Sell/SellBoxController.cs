using InventoryShop.Services;
using InventoryShop.Transaction;

namespace InventoryShop.Inventory.SellBox
{
    public class SellBoxController : TransactionBoxController
    {
        #region --------- Private Variables ---------

        private InventoryService inventoryService;
        #endregion ------------------

        #region --------- Public Methods ---------

        public SellBoxController(TransactionBoxView transactionBoxView, InventoryService inventoryService, ItemService itemService)
            : base(transactionBoxView, itemService)
        {
            this.inventoryService = inventoryService;

            transactionBoxModel.SetController(this);
            transactionBoxView.SetController(this);
        }

        public override void ResetItemCounter(bool hasSold)
        {
            if (hasSold)
            {
                transactionBoxModel.itemQuantity -= transactionBoxModel.itemCount;
                if (transactionBoxModel.itemQuantity <= 0)
                {
                    transactionBoxModel.itemQuantity = 0;
                    inventoryService.DisableDescription();
                    transactionBoxView.TogglePositiveBtn(false);
                    transactionBoxView.ToggleNegativeBtn(false);
                    itemService.RemoveInventoryItem(transactionBoxModel.itemName);
                }
                inventoryService.SetItemQuantity(transactionBoxModel.itemQuantity);
                itemService.AddShopItems(transactionBoxModel.itemName, transactionBoxModel.itemCount);
            }

           base.ResetItemCounter(hasSold);
        }
        #endregion ------------------
    }
}

