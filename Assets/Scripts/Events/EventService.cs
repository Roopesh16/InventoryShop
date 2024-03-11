using UnityEngine;

namespace InventoryShop.Services.Events
{
    public class EventService
    {
        #region --------- Public Variables ---------
        public EventController<string> onItemRemove;
        #endregion ------------------

        #region --------- Public Methods ---------
        public EventService()
        {
            onItemRemove = new EventController<string>();
        }
        #endregion ------------------

    }
}
