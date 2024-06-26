using System.Collections;
using System.Collections.Generic;
using InventoryShop.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryShop.Managers
{
    public class UIManager : GenericMonoSingleton<UIManager>
    {
        #region --------- Serialized Variables ---------

        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private TextMeshProUGUI notificationText;
        [SerializeField] private GameObject shopTitle;
        [SerializeField] private GameObject shopPanel;
        [SerializeField] private GameObject inventoryTitle;
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private float maxTime = 3f;
        #endregion ------------------

        #region --------- Private Variables ---------

        private bool isShopActive = true;
        private bool isInventoryActive = false;
        private PlayerService playerService;
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            leftButton.onClick.AddListener(ToggleLeftRight);
            rightButton.onClick.AddListener(ToggleLeftRight);
        }
        #endregion ------------------

        #region --------- Private Methods ---------

        private void ToggleLeftRight()
        {
            isShopActive = !isShopActive;
            isInventoryActive = !isInventoryActive;
            SetPanelActive();
        }

        private void SetPanelActive()
        {
            shopTitle.SetActive(isShopActive);
            shopPanel.SetActive(isShopActive);

            inventoryTitle.SetActive(isInventoryActive);
            inventoryPanel.SetActive(isInventoryActive);
        }

        private IEnumerator WaitTimer()
        {
            yield return new WaitForSeconds(maxTime);
            notificationText.gameObject.SetActive(false);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public void Init(PlayerService playerService)
        {
            this.playerService = playerService;

            SetPanelActive();
            notificationText.gameObject.SetActive(false);
            SetCurrentMoney(this.playerService.GetCurrentMoney());
        }

        public void SetNotificationText(string notification)
        {
            notificationText.gameObject.SetActive(true);
            notificationText.text = notification;
            StartCoroutine(WaitTimer());
        }

        public void SetCurrentMoney(int money) => moneyText.text = money.ToString();
        public bool GetShopActive() => isShopActive;

        #endregion ------------------
    }
}
