using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemView : MonoBehaviour
{
    #region --------- Serialized Variables ---------
    #endregion ------------------

    #region --------- Private Variables ---------
    private Image itemImage;
    private Button itemButton;
    private TextMeshProUGUI quantityText;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void Awake()
    {
        itemImage = GetComponent<Image>();
        itemButton = GetComponent<Button>();
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
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
    #endregion ------------------
}
