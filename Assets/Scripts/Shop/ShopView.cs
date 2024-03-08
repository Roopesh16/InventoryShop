using System.Collections;
using System.Collections.Generic;
using InventoryShop.Events;
using InventoryShop.Shop;
using TMPro;
using Unity.VisualScripting;
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
    #endregion ------------------

    #region --------- Private Variables ---------
    private ShopController shopController;
    private int itemBuyPrice;
    private int itemQuantity;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void OnEnable()
    {
        EventManager.Instance.OnItemClick.AddListener(DisplayItemInfo);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnItemClick.RemoveListener(DisplayItemInfo);
    }
    #endregion ------------------

    #region --------- Private Methods ---------
    #endregion ------------------

    #region --------- Public Methods ---------
    public void SetupShopView() => descriptionBox.SetActive(false);

    public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemBuyPrice,int itemQuantity)
    {
        descriptionBox.SetActive(true);
        itemNameText.text = itemName;
        itemImage.sprite = itemIcon;
        itemDesctiptionText.text = itemDescription;
        itemBuyText.text = itemBuyPrice.ToString();

        this.itemBuyPrice = itemBuyPrice;
        this.itemQuantity = itemQuantity;
    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
    }
    #endregion ------------------
}
