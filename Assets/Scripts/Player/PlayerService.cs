using InventoryShop.Services.Events;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class PlayerService
    {
        #region --------- Private Variables ---------
        private EventService eventService;
        private int currentMoney = 0;
        private const int minMoney = 0;
        private const int maxMoney = 100;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        private void SubscribeToEvents() => eventService.OnResouceClick.AddListener(RandomizeMoney);
        private void RandomizeMoney()
        {
            currentMoney += Random.Range(minMoney, maxMoney);
            UIManager.Instance.SetCurrentMoney(currentMoney);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public PlayerService(int currentMoney)
        {
            this.currentMoney = currentMoney;
        }

        public void Init(EventService eventService)
        {
            this.eventService = eventService;

            SubscribeToEvents();
        }

        public int GetCurrentMoney() => currentMoney;
        public void DeductMoney(int buyCost) => currentMoney -= buyCost;
        public void IncrementMoney(int sellCost) => currentMoney += sellCost;
        #endregion ------------------
    }
}
