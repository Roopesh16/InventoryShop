using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryShop.Items
{
    public class ItemView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [SerializeField] private Image itemImage;
        [SerializeField] private Button itemButton;
        [SerializeField] private TextMeshProUGUI quantityText;
        #endregion ------------------

        #region --------- Private Variables ---------

        private ItemController itemController;
        #endregion ------------------

        #region --------- Monobehavior Methods ---------

        private void Awake()
        {
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
