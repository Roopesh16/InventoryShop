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

        private SellBoxController sellBoxController;
        private int itemCount;
        private int totalCost;
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

        #region --------- Public Methods ---------
        
        public void SetSellBoxView(int itemCount)
        {
            gameObject.SetActive(false);
            countText.text = itemCount.ToString();
            UpdateSellCounter(itemCount, itemCount);
            ToggleNegativeBtn(false);
        }
        public void SetSellBoxController(SellBoxController sellBoxController) => this.sellBoxController = sellBoxController;

        public void OnNegativeBtnClick() => sellBoxController.DecrementItemCount();

        public void OnPositiveBtnClick() => sellBoxController.IncrementItemCount();

        public void UpdateSellCounter(int itemCount, int itemSellCost)
        {
            this.itemCount = itemCount;
            totalCost = itemCount * itemSellCost;
            countText.text = itemCount.ToString();
            itemSellText.text = totalCost.ToString();
        }

        public void OnYesClick()
        {
            sellBoxController.ValidateSellTransaction();
            gameObject.SetActive(false);
        }

        public void OnNoClick()
        {
            gameObject.SetActive(false);
            sellBoxController.ResetItemCounter(false);
        }

        public void ToggleNegativeBtn(bool isActive) => negativeBtn.interactable = isActive;

        public void TogglePositiveBtn(bool isActive) => positiveBtn.interactable = isActive;

        public void EnableSellBox() => gameObject.SetActive(true);

        #endregion ------------------
    }
}
