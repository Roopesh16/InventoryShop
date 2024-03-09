using InventoryShop.Shop.BuyBox;
using InventoryShop.Shop;
using UnityEngine;
using InventoryShop.Events;

namespace InventoryShop.Managers
{
    public class ShopService : MonoBehaviour
    {
        #region --------- Private Variables ---------
        private ItemService itemService;

        private Transform shopGridTransform;
        private ShopView shopView;
        private BuyBoxView buyBoxView;
        private static ShopService instance = null;
        private BuyBoxController buyBoxController;
        private ShopController shopController;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ShopService Instance
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
        private void InitializeVariables(EventService eventService)
        {
            itemService.SpawnItems(eventService, shopGridTransform);
            shopController = new(eventService, shopView);
            buyBoxController = new(buyBoxView);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopService(Transform shopGridTransform, ShopView shopView, BuyBoxView buyBoxView)
        {
            this.shopGridTransform = shopGridTransform;
            this.shopView = shopView;
            this.buyBoxView = buyBoxView;
        }

        public void Init(EventService eventService, ItemService itemService)
        {
            this.itemService = itemService;

            InitializeVariables(eventService);
        }

        public void SetBuyItemData(int itemBuyCost, int itemQuantity) => buyBoxController.SetBuyItemData(itemBuyCost, itemQuantity);
        public void DisableDescription() => shopController.DisableDescription();
        #endregion ------------------
    }
}
