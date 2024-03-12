using InventoryShop.Services.Events;
using InventoryShop.Services;
using InventoryShop.Shop;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using TMPro.SpriteAssetUtilities;

namespace InventoryShop.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI itemDesctiptionText;
        [SerializeField] private TextMeshProUGUI itemSellText;
        [SerializeField] private TextMeshProUGUI weightCountText;
        [SerializeField] private GameObject emptyTextObject;
        [SerializeField] private GameObject descriptionBox;
        [SerializeField] private Image itemImage;
        [SerializeField] private Button sellButton;
        #endregion ------------------

        #region --------- Private Variables ---------
        private EventService eventService;
        private InventoryService inventoryService;
        private InventoryController inventoryController;

        private string itemName;
        private int itemSellCost;
        private int itemQuantity;
        private float itemWeight;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            sellButton.onClick.AddListener(EnableSellBox);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        private void EnableSellBox() => inventoryService.SetSellItemData(itemName, itemSellCost, itemQuantity);
        private void SubscribeToEvent()
        {
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetupShopView(EventService eventService, InventoryService inventoryService)
        {
            this.eventService = eventService;
            this.inventoryService = inventoryService;

            // SubscribeToEvent();
            UpdateWeightText();
            descriptionBox.SetActive(false);
        }

        public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemSellCost, int itemQuantity, float itemWeight)
        {
            descriptionBox.SetActive(true);
            itemNameText.text = itemName;
            itemImage.sprite = itemIcon;
            itemDesctiptionText.text = itemDescription;
            itemSellText.text = itemSellCost.ToString();

            this.itemName = itemName;
            this.itemSellCost = itemSellCost;
            this.itemQuantity = itemQuantity;
            this.itemWeight = itemWeight;
        }

        public void SetInventoryController(InventoryController inventoryController)
        {
            this.inventoryController = inventoryController;
        }

        public void UpdateWeightText()
        {
            weightCountText.text = inventoryController.GetCurrentWeight().ToString() + "/" + inventoryController.GetMaxWeight().ToString();
        }

        public void DisableDescription() => descriptionBox.SetActive(false);
        public void ToggleEmptyBox(bool isActive) => emptyTextObject.SetActive(isActive);
        #endregion ------------------
    }
}
