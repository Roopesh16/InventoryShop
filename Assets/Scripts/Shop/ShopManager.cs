using InventoryShop.Shop.BuyBox;
using InventoryShop.Shop;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class ShopManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [Header("Grid Transform")]
        [SerializeField] private Transform shopGridTransform;

        [Header("Reference")]
        [SerializeField] private ShopView shopView;
        [SerializeField] private BuyBoxView buyBoxView;
        #endregion ------------------

        #region --------- Private Variables ---------
        private static ShopManager instance = null;
        private BuyBoxController buyBoxController;
        private ShopController shopController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ShopManager Instance
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
        public void Init()
        {
            ItemManager.Instance.SpawnItems(shopGridTransform);

            shopController = new(shopView);
            buyBoxController = new(buyBoxView);
        }

        public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => shopController.DisableDescription();
        #endregion ------------------
    }
}
