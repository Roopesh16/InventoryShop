using UnityEngine;

namespace InventoryShop.Events
{
    public class EventService
    {
        #region --------- Private Variables ---------
        private static EventService instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventService();

                return instance;
            }
        }

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
