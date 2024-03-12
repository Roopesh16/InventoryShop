using System.Collections;
using System.Collections.Generic;
using System.Security;
using InventoryShop.Services;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private static GameManager instance = null;
        private PlayerService playerService;
        private ItemService itemService;
        private ShopService shopService;
        private InventoryService inventoryService;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static GameManager Instance { get { return instance; } }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void Init(PlayerService playerService, ItemService itemService, ShopService shopService, InventoryService inventoryService)
        {
            this.playerService = playerService;
            this.itemService = itemService;
            this.shopService = shopService;
            this.inventoryService = inventoryService;
        }

        public bool ValidateBuyTransaction(int itemCount, int itemBuyCost, float itemWeight)
        {
            if (itemCount == 0)
                return false;

            if (itemWeight + inventoryService.GetInventoryCurrentWeight() > inventoryService.GetInventoryMaxWeight())
            {
                UIManager.Instance.SetNotificationText("EXCEED WEIGHT!");
                return false;
            }

            if (playerService.GetCurrentMoney() == 0)
            {
                UIManager.Instance.SetNotificationText("NO MONEY!");
                return false;
            }

            if (itemBuyCost > playerService.GetCurrentMoney())
            {
                UIManager.Instance.SetNotificationText("EXCEED COST!");
                return false;
            }

            playerService.DeductMoney(itemBuyCost);
            UIManager.Instance.SetCurrentMoney(playerService.GetCurrentMoney());
            itemService.UpdateShopSelectedItem(itemCount);
            inventoryService.IncreaseInventoryWeight(itemWeight);

            return true;
        }

        public bool ValidateSellTransaction(int itemCount, int itemSellCost, float itemWeight)
        {
            if (itemCount == 0)
                return false;

            playerService.IncrementMoney(itemSellCost);
            UIManager.Instance.SetCurrentMoney(playerService.GetCurrentMoney());
            itemService.UpdateInventorySelectedItem(itemCount);
            inventoryService.DecreaseInventoryWeight(itemWeight);

            return true;

        }

        public void SendShopItemData(string name, Sprite icon, string description, int buyCost, int quantity, float weight)
        {
            shopService.DisplayItemInfo(name, icon, description, buyCost, quantity, weight);
        }

        public void SendInventoryItemData(string name, Sprite icon, string description, int buyCost, int quantity, float weight)
        {
            inventoryService.DisplayItemInfo(name, icon, description, buyCost, quantity, weight);
        }

        public void DisplayTypeItem(ItemType itemType) => itemService.DisplayType(itemType);
        #endregion ------------------
    }
}
