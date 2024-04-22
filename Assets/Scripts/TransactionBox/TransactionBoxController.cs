using InventoryShop.Managers;
using InventoryShop.Services;

namespace InventoryShop.Transaction
{
    public class TransactionBoxController
    {
        protected ItemService itemService;
        protected TransactionBoxModel transactionBoxModel;
        protected TransactionBoxView transactionBoxView;
        protected const int itemCount = 0;

        public TransactionBoxController(TransactionBoxView transactionBoxView, ItemService itemService)
        {
            this.itemService = itemService;

            transactionBoxModel = new(itemCount);

            this.transactionBoxView = transactionBoxView;
            transactionBoxView.SetTransactionBoxView(itemCount);
        }

        public void IncrementItemCount()
        {
            transactionBoxModel.itemCount++;
            transactionBoxView.ToggleNegativeBtn(true);
            if (transactionBoxModel.itemCount >= transactionBoxModel.itemQuantity)
            {
                transactionBoxModel.itemCount = transactionBoxModel.itemQuantity;
                transactionBoxView.TogglePositiveBtn(false);
            }
            transactionBoxView.UpdateCounter(transactionBoxModel.itemCount, transactionBoxModel.itemCost);
        }

        public void DecrementItemCount()
        {
            transactionBoxModel.itemCount--;
            transactionBoxView.TogglePositiveBtn(true);
            if (transactionBoxModel.itemCount <= 0)
            {
                transactionBoxModel.itemCount = 0;
                transactionBoxView.ToggleNegativeBtn(false);
            }
            transactionBoxView.UpdateCounter(transactionBoxModel.itemCount, transactionBoxModel.itemCost);
        }

        public void SetItemData(string itemName, int itemCost, int itemQuantity, float itemWeight)
        {
            transactionBoxModel.SetItemData(itemName, itemCost, itemQuantity, itemWeight);
            transactionBoxView.EnableTransactionBox();
        }

        public virtual void ResetItemCounter(bool isValidTransaction)
        {
            transactionBoxModel.itemCount = 0;
            transactionBoxView.UpdateCounter(transactionBoxModel.itemCount, transactionBoxModel.itemCost);
        }

        public void ValidateTransaction()
        {
            if (GameManager.Instance.ValidateSellTransaction(transactionBoxModel.itemCount,
                                                             transactionBoxModel.itemCount * transactionBoxModel.itemCost,
                                                             transactionBoxModel.itemCount * transactionBoxModel.itemWeight))
                ResetItemCounter(true);
        }
    }
}

