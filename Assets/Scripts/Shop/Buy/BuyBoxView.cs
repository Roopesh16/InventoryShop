using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Shop.BuyBox
{
    public class BuyBoxView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private BuyBoxController buyBoxController;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetBuyBoxView() => gameObject.SetActive(false);

        public void SetBuyBoxController(BuyBoxController buyBoxController) => this.buyBoxController = buyBoxController;
        #endregion ------------------
    }
}
