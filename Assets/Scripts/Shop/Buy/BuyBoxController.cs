using InventoryShop.Services;
using InventoryShop.Transaction;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxController : TransactionBoxController
    {
        #region --------- Private Variables ---------

        private ShopService shopService;
        #endregion ------------------

        #region --------- Public Methods ---------

        public BuyBoxController(TransactionBoxView transactionBoxView, ShopService shopService, ItemService itemService) 
            : base(transactionBoxView, itemService)
        {
            this.shopService = shopService;
            this.itemService = itemService;

            transactionBoxModel.SetController(this);
            transactionBoxView.SetController(this);
        }


        public override void ResetItemCounter(bool hasBought)
        {
            if (hasBought)
            {
                transactionBoxModel.itemQuantity -= transactionBoxModel.itemCount;
                if (transactionBoxModel.itemQuantity <= 0)
                {
                    transactionBoxModel.itemQuantity = 0;
                    shopService.DisableDescription();
                    transactionBoxView.TogglePositiveBtn(false);
                    transactionBoxView.ToggleNegativeBtn(false);
                }
                shopService.SetItemQuantity(transactionBoxModel.itemQuantity);
                itemService.AddInventoryItems(transactionBoxModel.itemName, transactionBoxModel.itemCount);
            }

            base.ResetItemCounter(hasBought);
        }
        #endregion ------------------
    }
}

