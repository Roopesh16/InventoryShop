using UnityEngine;

namespace InventoryShop.Services.Events
{
    public class EventService
    {
        #region --------- Public Variables ---------
        public EventController OnResouceClick;
        #endregion ------------------

        #region --------- Public Methods ---------
        public EventService()
        {
            OnResouceClick = new EventController();
        }
        #endregion ------------------

    }
}
