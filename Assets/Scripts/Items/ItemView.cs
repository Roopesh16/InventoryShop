using UnityEngine.UI;
using UnityEngine;
using TMPro;

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

        #region --------- Monobehavior Methods ---------

        private void Awake()
        {
            itemImage = GetComponent<Image>();
            itemButton = GetComponent<Button>();
            quantityText = GetComponentInChildren<TextMeshProUGUI>();

            itemButton.onClick.AddListener(SendItemData);
        }
        #endregion ------------------


        #region --------- Public Methods ---------
        
        public void SetItemView(Sprite itemIcon, int itemQuantity)
        {
            if (itemImage != null)
                itemImage.sprite = itemIcon;
            else
            {
                itemImage = GetComponent<Image>();
                itemImage.sprite = itemIcon;
            }

            if (quantityText != null)
                quantityText.text = "x" + itemQuantity.ToString();
            else
            {
                quantityText = GetComponentInChildren<TextMeshProUGUI>();
                quantityText.text = "x" + itemQuantity.ToString();
            }
        }

        public void SetItemController(ItemController itemController) => this.itemController = itemController;

        public void SendItemData() => itemController.SendItemData();

        public void DisableItemBtn() => itemButton.interactable = false;

        public void UpdateItemQuantity(int itemQuantity) => quantityText.text = "x" + itemQuantity.ToString();

        #endregion ------------------
    }
}
