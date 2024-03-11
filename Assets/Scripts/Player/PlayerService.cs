using UnityEngine;

namespace InventoryShop.Managers
{
    public class PlayerService
    {
        #region --------- Private Variables ---------
        private int currentMoney = 0;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public PlayerService(int currentMoney)
        {
            this.currentMoney = currentMoney;
        }

        public int GetCurrentMoney() => currentMoney;
        public void DeductMoney(int buyCost) => currentMoney -= buyCost;
        public void IncrementMoney(int sellCost) => currentMoney += sellCost;
        #endregion ------------------
    }
}
