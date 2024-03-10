using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryShop.Managers
{
    public class UIManager : MonoBehaviour
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
        private static UIManager instance = null;
        private bool isShopActive = true;
        private bool isInventoryActive = false;
        private PlayerService playerService;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static UIManager Instance { get { return instance; } }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

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

        #endregion ------------------
    }
}
