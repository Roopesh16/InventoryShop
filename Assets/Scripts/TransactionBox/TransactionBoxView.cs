using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryShop.Transaction
{
    public class TransactionBoxView : MonoBehaviour
    {
        [SerializeField] protected Button negativeBtn;
        [SerializeField] protected Button positiveBtn;
        [SerializeField] protected Button yesButton;
        [SerializeField] protected Button noButton;
        [SerializeField] protected TextMeshProUGUI countText;
        [SerializeField] protected TextMeshProUGUI itemTransactionText;


        protected TransactionBoxController transactionBoxController;
        protected int itemCount;
        protected int totalCost;

        private void Awake()
        {
            negativeBtn.onClick.AddListener(OnNegativeBtnClick);
            positiveBtn.onClick.AddListener(OnPositiveBtnClick);
            yesButton.onClick.AddListener(OnYesClick);
            noButton.onClick.AddListener(OnNoClick);
        }

        public void SetTransactionBoxView(int itemCount)
        {
            gameObject.SetActive(false);
            countText.text = itemCount.ToString();
            UpdateCounter(itemCount, itemCount);
            ToggleNegativeBtn(false);
        }

        public void SetController(TransactionBoxController transactionBoxController) => this.transactionBoxController = transactionBoxController;

        public void OnNegativeBtnClick() => transactionBoxController.DecrementItemCount();

        public void OnPositiveBtnClick() => transactionBoxController.IncrementItemCount();

        public void UpdateCounter(int itemCount, int itemBuyCost)
        {
            this.itemCount = itemCount;
            totalCost = itemCount * itemBuyCost;
            countText.text = itemCount.ToString();
            itemTransactionText.text = totalCost.ToString();
        }

        public void OnYesClick()
        {
            transactionBoxController.ValidateTransaction();
            gameObject.SetActive(false);
        }

        public void OnNoClick()
        {
            transactionBoxController.ResetItemCounter(false);
            gameObject.SetActive(false);
        }

        public void ToggleNegativeBtn(bool isActive) => negativeBtn.interactable = isActive;

        public void TogglePositiveBtn(bool isActive) => positiveBtn.interactable = isActive;

        public void EnableTransactionBox() => gameObject.SetActive(true);

    }
}