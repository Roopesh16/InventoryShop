using System.Collections;
using System.Collections.Generic;
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
    #endregion ------------------

    #region --------- Private Variables ---------
    private ShopController shopController;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    #endregion ------------------

    #region --------- Private Methods ---------
    #endregion ------------------

    #region --------- Public Methods ---------
    public void SetupShopView() => descriptionBox.SetActive(false);

    public void DisplayItemInfo(string itemName, Sprite itemIcon, string itemDescription, int itemBuyPrice)
    {
        descriptionBox.SetActive(true);
        itemNameText.text = itemName;
        itemImage.sprite = itemIcon;
        itemDesctiptionText.text = itemDescription;
        itemBuyText.text = itemBuyPrice.ToString();
    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
    }
    #endregion ------------------
}
