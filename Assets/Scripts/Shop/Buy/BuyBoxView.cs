using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxView : MonoBehaviour, ICountBtnClick
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private Button negativeBtn;
        [SerializeField] private Button positiveBtn;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private TextMeshProUGUI itemBuyText;
        #endregion ------------------

        #region --------- Private Variables ---------
        private BuyBoxController buyBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            negativeBtn.onClick.AddListener(OnNegativeBtnClick);
            positiveBtn.onClick.AddListener(OnPositiveBtnClick);
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
            DisableNegativeBtn();

        }
        public void SetBuyBoxController(BuyBoxController buyBoxController) => this.buyBoxController = buyBoxController;

        public void OnNegativeBtnClick() => buyBoxController.DecrementItemCount();

        public void OnPositiveBtnClick() => buyBoxController.IncrementItemCount();

        public void UpdateBuyCounter(int itemCount, int itemBuyCost)
        {
            countText.text = itemCount.ToString();
            itemBuyText.text = (itemCount * itemBuyCost).ToString();
        }

        public void EnableNegativeBtn()
        {
            if (negativeBtn.interactable)
                return;

            negativeBtn.interactable = true;
        }

        public void EnablePositiveBtn()
        {
            if (positiveBtn.interactable)
                return;

            positiveBtn.interactable = true;
        }

        public void DisablePositiveBtn()
        {
            if (!positiveBtn.interactable)
                return;

            positiveBtn.interactable = false;
        }

        public void DisableNegativeBtn()
        {
            if (!negativeBtn.interactable)
                return;

            negativeBtn.interactable = false;
        }
        #endregion ------------------
    }
}
