using InventoryShop.Services.Events;
using InventoryShop.Services;
using InventoryShop.Shop;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopView : MonoBehaviour
{
    #region --------- Serialized Variables ---------
    [SerializeField] private GameObject descriptionBox;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemDesctiptionText;
    [SerializeField] private TextMeshProUGUI itemBuyText;
    [SerializeField] private Button buyButton;
    #endregion ------------------

    #region --------- Private Variables ---------
    private EventService eventService;
    private ShopService shopService;
    private ShopController shopController;

    private string itemName;
    private int itemBuyCost;
    private int itemQuantity;
    private float itemWeight;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void Awake()
    {
        buyButton.onClick.AddListener(EnableBuyBox);
    }
    #endregion ------------------

    #region --------- Private Methods ---------
    private void EnableBuyBox() => shopService.SetBuyItemData(itemName, itemBuyCost, itemQuantity,itemWeight);
    // private void SubscribeToEvent;
    #endregion ------------------

    #region --------- Public Methods ---------
    public void SetupShopView(EventService eventService, ShopService shopService)
    {
        this.eventService = eventService;
        this.shopService = shopService;

        // SubscribeToEvent();
        descriptionBox.SetActive(false);
    }

    public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemBuyCost, int itemQuantity, float itemWeight)
    {
        descriptionBox.SetActive(true);
        itemNameText.text = itemName;
        itemImage.sprite = itemIcon;
        itemDesctiptionText.text = itemDescription;
        itemBuyText.text = itemBuyCost.ToString();

        this.itemName = itemName;
        this.itemBuyCost = itemBuyCost;
        this.itemQuantity = itemQuantity;
        this.itemWeight = itemWeight;
    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
    }

    public void DisableDescription() => descriptionBox.SetActive(false);
    #endregion ------------------
}
