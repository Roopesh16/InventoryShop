using InventoryShop.ScriptableObjects;
using InventoryShop.Services.Events;
using System.Collections.Generic;
using InventoryShop.Shop.BuyBox;
using InventoryShop.Managers;
using InventoryShop.Items;
using UnityEngine;

namespace InventoryShop.Services
{
    public class GameService : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [Header("Item Service References")]
        [SerializeField] private List<ItemScriptableObject> itemsList = new();
        [SerializeField] private List<ItemTypeBtn> itemTypeBtns = new();
        [SerializeField] private ItemView itemPrefab;

        [Header("Player Service References")]
        [SerializeField] private int currentMoney = 0;

        [Header("Shop Service References")]
        [SerializeField] private Transform shopGridTransform;
        [SerializeField] private ShopView shopView;
        [SerializeField] private BuyBoxView buyBoxView;

        [Header("Managers")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UIManager uIManager;
        #endregion ------------------

        #region --------- Private Variables ---------
        private EventService eventService;
        private ItemService itemService;
        private PlayerService playerService;
        private ShopService shopService;
        #endregion ------------------

        #region --------- Public Variables ---------
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
            itemService = new(itemsList, itemPrefab, itemTypeBtns);
            shopService = new(shopGridTransform, shopView, buyBoxView);
        }

        private void InjectDependency()
        {
            GameManager.Instance.Init(playerService, itemService);
            UIManager.Instance.Init(playerService);
            shopService.Init(eventService, itemService);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        #endregion ------------------
    }
}
