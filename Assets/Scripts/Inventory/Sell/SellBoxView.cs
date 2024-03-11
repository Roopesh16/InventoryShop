using InventoryShop.Managers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace InventoryShop.Inventory.SellBox
{
    public class SellBoxView : MonoBehaviour, ICountBtnClick, IItemTransfer
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private Button negativeBtn;
        [SerializeField] private Button positiveBtn;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private TextMeshProUGUI itemSellText;
        #endregion ------------------

        #region --------- Private Variables ---------
        private SellBoxController buyBoxController;
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
        public void SetSellBoxView(int itemCount)
        {
            gameObject.SetActive(false);
            countText.text = itemCount.ToString();
            UpdateSellCounter(itemCount, itemCount);
            DisableNegativeBtn();
        }
        public void SetSellBoxController(SellBoxController buyBoxController) => this.buyBoxController = buyBoxController;

        public void OnNegativeBtnClick() => buyBoxController.DecrementItemCount();

        public void OnPositiveBtnClick() => buyBoxController.IncrementItemCount();

        public void UpdateSellCounter(int itemCount, int itemSellCost)
        {
            this.itemCount = itemCount;
            totalCost = itemCount * itemSellCost;
            countText.text = itemCount.ToString();
            itemSellText.text = totalCost.ToString();
        }

        public void OnYesClick()
        {
            if(GameManager.Instance.ValidateSellTransaction(itemCount, totalCost))
                buyBoxController.ResetItemCounter(true);
        }

        public void OnNoClick()
        {
            gameObject.SetActive(false);
            buyBoxController.ResetItemCounter(false);
        }

        public void EnableNegativeBtn() => negativeBtn.interactable = true;

        public void EnablePositiveBtn() => positiveBtn.interactable = true;

        public void DisablePositiveBtn() => positiveBtn.interactable = false;

        public void DisableNegativeBtn() => negativeBtn.interactable = false;

        public void EnableSellBox() => gameObject.SetActive(true);

        #endregion ------------------
    }
}
