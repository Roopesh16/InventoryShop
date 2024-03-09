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
            ShopManager.Instance.Init();
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void ValidateBuyTransaction(int itemCount, int itemBuyCost)
        {
            if (PlayerManager.Instance.GetCurrentCost() == 0)
            {
                UIManager.Instance.SetNotificationText("NO MONEY!");
                return;
            }

            if (itemBuyCost > PlayerManager.Instance.GetCurrentCost())
            {
                UIManager.Instance.SetNotificationText("EXCEED COST!");
                return;
            }


        }
        #endregion ------------------
    }
}
