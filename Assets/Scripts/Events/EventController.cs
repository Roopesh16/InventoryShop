using System;

public class EventController<T, U, V, W>
{
    #region --------- Public Variables ---------
    public event Action<T, U, V, W> baseEvent;
    #endregion ------------------

    #region --------- Public Methods ---------
    public void InvokeEvent(T param1, U param2, V param3, W param4) => baseEvent?.Invoke(param1, param2, param3, param4);
    public void AddListener(Action<T, U, V, W> listener) => baseEvent += listener;
    public void RemoveListener(Action<T, U, V, W> listener) => baseEvent -= listener;
    #endregion ------------------
}
