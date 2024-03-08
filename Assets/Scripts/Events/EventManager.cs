using UnityEngine;

namespace InventoryShop.Events
{
    public class EventManager
    {
        #region --------- Private Variables ---------
        private static EventManager instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventManager();

                return instance;
            }
        }

        public EventController<string, Sprite, string, int> OnItemClick;
        #endregion ------------------

        #region --------- Public Methods ---------
        public EventManager()
        {
            OnItemClick = new EventController<string, Sprite, string, int>();
        }
        #endregion ------------------

    }
}
