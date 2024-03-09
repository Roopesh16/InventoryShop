using UnityEngine;

namespace InventoryShop.Managers
{
    public class PlayerService : MonoBehaviour
    {
        #region --------- Private Variables ---------
        private int currentMoney = 0;
        private static PlayerService instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static PlayerService Instance
        {
            get { return instance; }
        }
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
        public PlayerService(int currentMoney)
        {
            this.currentMoney = currentMoney;
        }

        public int GetCurrentMoney() => currentMoney;
        public int DeductMoney(int buyCost) => currentMoney -= buyCost;
        #endregion ------------------
    }
}
