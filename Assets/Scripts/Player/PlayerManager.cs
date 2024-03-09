using UnityEngine;

namespace InventoryShop.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private int currentMoney = 0;
        #endregion ------------------

        #region --------- Private Variables ---------
        private static PlayerManager instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static PlayerManager Instance
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
        public int GetCurrentMoney() => currentMoney;
        public int DeductMoney(int buyCost) => currentMoney -= buyCost;
        #endregion ------------------
    }
}
