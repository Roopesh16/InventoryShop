using System;

namespace InventoryShop.Events
{
    public class EventController<T, U, V, W>
    {
        #region --------- Public Variables ---------
        public event Action<T, U, V, W> baseEvent;
        #endregion ------------------

        #region --------- Public Methods ---------
        public void InvokeEvent(T var1, U var2, V var3, W var4) => baseEvent?.Invoke(var1, var2, var3, var4);
        public void AddListener(Action<T, U, V, W> listener) => baseEvent += listener;
        public void RemoveListener(Action<T, U, V, W> listener) => baseEvent -= listener;
        #endregion ------------------
    }
}
