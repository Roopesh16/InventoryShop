using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private static GameManager instance = null;
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

        private void Start()
        {
            UIManager.Instance.Init();
            ShopService.Instance.Init();
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void ValidateBuyTransaction(int itemCount, int itemBuyCost)
        {
            if (PlayerService.Instance.GetCurrentMoney() == 0)
            {
                UIManager.Instance.SetNotificationText("NO MONEY!");
                return;
            }

            if (itemBuyCost > PlayerService.Instance.GetCurrentMoney())
            {
                UIManager.Instance.SetNotificationText("EXCEED COST!");
                return;
            }

            PlayerService.Instance.DeductMoney(itemBuyCost);
            UIManager.Instance.SetCurrentMoney(PlayerService.Instance.GetCurrentMoney());
            ItemService.Instance.UpdateSelectedItem(itemCount);
        }
        #endregion ------------------
    }
}
