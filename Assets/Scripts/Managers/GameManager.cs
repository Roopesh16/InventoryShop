using System.Collections;
using System.Collections.Generic;
using InventoryShop.Services;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private static GameManager instance = null;
        private PlayerService playerService;
        private ItemService itemService;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static GameManager Instance { get { return instance; } }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void Init(PlayerService playerService, ItemService itemService)
        {
            this.playerService = playerService;
            this.itemService = itemService;
        }

        public bool ValidateBuyTransaction(int itemCount, int itemBuyCost)
        {
            if (playerService.GetCurrentMoney() == 0)
            {
                UIManager.Instance.SetNotificationText("NO MONEY!");
                return false;
            }

            if (itemBuyCost > playerService.GetCurrentMoney())
            {
                UIManager.Instance.SetNotificationText("EXCEED COST!");
                return false;
            }

            playerService.DeductMoney(itemBuyCost);
            UIManager.Instance.SetCurrentMoney(playerService.GetCurrentMoney());
            itemService.UpdateSelectedItem(itemCount);
            return true;
        }
        #endregion ------------------
    }
}
