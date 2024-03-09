using InventoryShop.Events;
using InventoryShop.Managers;
using InventoryShop.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private ShopController shopController;
    private int itemBuyCost;
    private int itemQuantity;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void Awake()
    {
        buyButton.onClick.AddListener(EnableBuyBox);
    }
    
    private void OnDisable()
    {
        eventService.OnItemClick.RemoveListener(DisplayItemInfo);
    }
    #endregion ------------------

    #region --------- Private Methods ---------
    private void EnableBuyBox() => ShopService.Instance.SetBuyItemData(itemBuyCost, itemQuantity);
    private void SubscribeToEvent() => eventService.OnItemClick.AddListener(DisplayItemInfo);
    #endregion ------------------

    #region --------- Public Methods ---------
    public void SetupShopView(EventService eventService)
    {
        this.eventService = eventService;
        SubscribeToEvent();
        descriptionBox.SetActive(false);
    }

    public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemBuyCost, int itemQuantity)
    {
        descriptionBox.SetActive(true);
        itemNameText.text = itemName;
        itemImage.sprite = itemIcon;
        itemDesctiptionText.text = itemDescription;
        itemBuyText.text = itemBuyCost.ToString();

        this.itemBuyCost = itemBuyCost;
        this.itemQuantity = itemQuantity;
    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
    }

    public void DisableDescription() => descriptionBox.SetActive(false);
    #endregion ------------------
}
