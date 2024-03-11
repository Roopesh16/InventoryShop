using InventoryShop.Services.Events;
using InventoryShop.Services;
using InventoryShop.Shop;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace InventoryShop.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI itemDesctiptionText;
        [SerializeField] private TextMeshProUGUI itemSellText;
        [SerializeField] private GameObject emptyTextObject;
        [SerializeField] private GameObject descriptionBox;
        [SerializeField] private Image itemImage;
        [SerializeField] private Button sellButton;
        #endregion ------------------

        #region --------- Private Variables ---------
        private EventService eventService;
        private InventoryService inventoryService;
        private InventoryController inventoryController;
        private int itemSellCost;
        private int itemQuantity;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            // sellButton.onClick.AddListener(EnableBuyBox);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        // private void EnableBuyBox() => shopService.SetBuyItemData(itemBuyCost, itemQuantity);
        private void SubscribeToEvent()
        {
            eventService.OnItemClick.AddListener(DisplayItemInfo);
            eventService.onItemAdded.AddListener(DisableEmptyBox);
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetupShopView(EventService eventService, InventoryService inventoryService)
        {
            this.eventService = eventService;
            this.inventoryService = inventoryService;

            SubscribeToEvent();
            descriptionBox.SetActive(false);
        }

        public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemSellCost, int itemQuantity)
        {
            descriptionBox.SetActive(true);
            itemNameText.text = itemName;
            itemImage.sprite = itemIcon;
            itemDesctiptionText.text = itemDescription;
            itemSellText.text = itemSellCost.ToString();

            this.itemSellCost = itemSellCost;
            this.itemQuantity = itemQuantity;
        }

        public void SetInventoryController(InventoryController inventoryController)
        {
            this.inventoryController = inventoryController;
        }

        public void DisableDescription() => descriptionBox.SetActive(false);

        public void DisableEmptyBox(bool isActive) => emptyTextObject.SetActive(isActive);
        #endregion ------------------
    }
}
