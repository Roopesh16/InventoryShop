using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Services;
using UnityEngine;

namespace InventoryShop.Shop
{
    public class ShopController
    {
        #region --------- Private Variables ---------
        private ShopView shopView;
        private ShopModel shopModel;
        private List<ItemScriptableObject> shopItems = new();
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public ShopController(EventService eventService, ShopService shopService, ShopView shopView, List<ItemScriptableObject> shopItems)
        {
            shopModel = new(shopItems);
            this.shopView = shopView;
            this.shopView.SetupShopView(eventService, shopService);
            this.shopView.SetShopController(this);
        }

        public void DisableDescription() => shopView.DisableDescription();
        #endregion ------------------
    }
}
