using UnityEngine;

namespace InventoryShop.Services.Events
{
    public class EventService
    {
        #region --------- Public Variables ---------
        public EventController<string, Sprite, string, int, int> OnItemClick;
        #endregion ------------------

        #region --------- Public Methods ---------
        public EventService()
        {
            OnItemClick = new EventController<string, Sprite, string, int, int>();
        }
        #endregion ------------------

    }
}
