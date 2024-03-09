using UnityEngine;

namespace InventoryShop.Shop
{
    public class ShopController
    {
        #region --------- Private Variables ---------
        private ShopView shopView;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopController(ShopView shopView)
        {
            this.shopView = shopView;
            this.shopView.SetupShopView();
            this.shopView.SetShopController(this);
        }

        public void DisableDescription() => shopView.DisableDescription();
        #endregion ------------------
    }
}
