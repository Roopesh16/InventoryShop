using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxController
    {
        #region --------- Private Variables ---------
        private BuyBoxModel buyBoxModel;
        private BuyBoxView buyBoxView;

        private const int itemCount = 0;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public BuyBoxController(BuyBoxView buyBoxView)
        {
            buyBoxModel = new(itemCount);
            buyBoxModel.SetBuyBoxController(this);

            this.buyBoxView = buyBoxView;
            this.buyBoxView.SetBuyBoxView();
            this.buyBoxView.SetBuyBoxController(this);
        }
        #endregion ------------------
    }
}

