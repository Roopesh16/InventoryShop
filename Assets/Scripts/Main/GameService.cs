using InventoryShop.Inventory;
using InventoryShop.Items;
using InventoryShop.Managers;
using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using InventoryShop.Transaction;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Services
{
    public class GameService : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [Header("Item Service References")]
        [SerializeField] private List<ItemScriptableObject> itemsList = new();
        [SerializeField] private ItemView itemPrefab;
        [SerializeField] private Transform shopGridTransform;
        [SerializeField] private Transform inventoryGridTransform;

        [Header("Player Service References")]
        [SerializeField] private int currentMoney = 0;

        [Header("Shop Service References")]
        [SerializeField] private ShopView shopView;
        [SerializeField] private TransactionBoxView buyBoxView;

        [Header("Inventory Service References")]
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private TransactionBoxView sellBoxView;

        [Header("Managers")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UIManager uIManager;
        #endregion ------------------

        #region --------- Private Variables ---------

        private EventService eventService;
        private ItemService itemService;
        private PlayerService playerService;
        private ShopService shopService;
        private InventoryService inventoryService;
        #endregion ------------------

        #region --------- Monobehavior Methods ---------

        private void Start()
        {
            CreateService();
            InjectDependency();
        }
        #endregion ------------------

        #region --------- Private Methods ---------

        private void CreateService()
        {
            eventService = new();
            playerService = new(currentMoney);
            itemService = new(itemsList, itemPrefab, shopGridTransform, inventoryGridTransform);
            shopService = new(shopView, buyBoxView);
            inventoryService = new(inventoryView, sellBoxView);
        }

        private void InjectDependency()
        {
            GameManager.Instance.Init(playerService, itemService, shopService, inventoryService);
            UIManager.Instance.Init(playerService);
            itemService.Init(eventService, inventoryService);
            shopService.Init(eventService, itemService, itemsList);
            inventoryService.Init(eventService, itemService);
            playerService.Init(eventService);
        }
        #endregion ------------------
    }
}
