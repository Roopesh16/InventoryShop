using InventoryShop.Services.Events;
using InventoryShop.Services;
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
        public ShopController(EventService eventService, ShopService shopService, ShopView shopView)
        {
            this.shopView = shopView;
            this.shopView.SetupShopView(eventService,shopService);
            this.shopView.SetShopController(this);
        }

        public void DisableDescription() => shopView.DisableDescription();
        #endregion ------------------
    }
}
