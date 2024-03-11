using InventoryShop.Managers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxView : MonoBehaviour, ICountBtnClick, IItemTransfer
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private Button negativeBtn;
        [SerializeField] private Button positiveBtn;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private TextMeshProUGUI itemBuyText;
        #endregion ------------------

        #region --------- Private Variables ---------
        private BuyBoxController buyBoxController;
        private int itemCount;
        private int totalCost;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            negativeBtn.onClick.AddListener(OnNegativeBtnClick);
            positiveBtn.onClick.AddListener(OnPositiveBtnClick);
            yesButton.onClick.AddListener(OnYesClick);
            noButton.onClick.AddListener(OnNoClick);
        }
        #endregion ------------------

        #region --------- Private Methods ---------

        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetBuyBoxView(int itemCount)
        {
            gameObject.SetActive(false);
            countText.text = itemCount.ToString();
            UpdateBuyCounter(itemCount, itemCount);
            ToggleNegativeBtn(false);
        }
        public void SetBuyBoxController(BuyBoxController buyBoxController) => this.buyBoxController = buyBoxController;

        public void OnNegativeBtnClick() => buyBoxController.DecrementItemCount();

        public void OnPositiveBtnClick() => buyBoxController.IncrementItemCount();

        public void UpdateBuyCounter(int itemCount, int itemBuyCost)
        {
            this.itemCount = itemCount;
            totalCost = itemCount * itemBuyCost;
            countText.text = itemCount.ToString();
            itemBuyText.text = totalCost.ToString();
        }

        public void OnYesClick()
        {
            if (GameManager.Instance.ValidateBuyTransaction(itemCount, totalCost))
                buyBoxController.ResetItemCounter(true);

            gameObject.SetActive(false);
        }

        public void OnNoClick()
        {
            gameObject.SetActive(false);
            buyBoxController.ResetItemCounter(false);
        }

        public void ToggleNegativeBtn(bool isActive) => negativeBtn.interactable = isActive;

        public void TogglePositiveBtn(bool isActive) => positiveBtn.interactable = isActive;

        public void EnableBuyBox() => gameObject.SetActive(true);

        #endregion ------------------
    }
}
