using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

namespace InventoryShop.Items
{
    public class ItemView : MonoBehaviour, IItemClick
    {
        #region --------- Serialized Variables ---------
        #endregion ------------------

        #region --------- Private Variables ---------
        private Image itemImage;
        private Button itemButton;
        private TextMeshProUGUI quantityText;
        private ItemController itemController;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            itemImage = GetComponent<Image>();
            itemButton = GetComponent<Button>();
            quantityText = GetComponentInChildren<TextMeshProUGUI>();

            itemButton.onClick.AddListener(SendItemData);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetItemView(Sprite itemIcon, int itemQuantity)
        {
            itemImage.sprite = itemIcon;
            quantityText.text = "x" + itemQuantity;
        }

        public void SetItemController(ItemController itemController) => this.itemController = itemController;

        public void SendItemData()
        {
            itemController.SelectCurrentItem();
            itemController.SendItemData();
        }

        #endregion ------------------
    }
}
