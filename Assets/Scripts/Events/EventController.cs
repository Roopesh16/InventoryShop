using System;
using System.Security.Cryptography.X509Certificates;

namespace InventoryShop.Events
{
    public class EventController<T, U, V, W,X>
    {
        #region --------- Public Variables ---------
        public event Action<T, U, V, W, X> baseEvent;
        #endregion ------------------

        #region --------- Public Methods ---------
        public void InvokeEvent(T var1, U var2, V var3, W var4, X var5) => baseEvent?.Invoke(var1, var2, var3, var4, var5);
        public void AddListener(Action<T, U, V, W,X> listener) => baseEvent += listener;
        public void RemoveListener(Action<T, U, V, W,X> listener) => baseEvent -= listener;
        #endregion ------------------
    }
}
