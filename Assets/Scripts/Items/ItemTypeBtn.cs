using InventoryShop.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ItemTypeBtn : MonoBehaviour
{
    #region --------- Serialized Variables ---------
    [SerializeField] private ItemType itemType;
    #endregion ------------------

    #region --------- Private Variables ---------
    private Button typeBtn;
    #endregion ------------------

    #region --------- Public Variables ---------
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void Awake()
    {
        typeBtn = GetComponent<Button>();

        typeBtn.onClick.AddListener(DisplayTypeItems);
    }
    #endregion ------------------

    #region --------- Private Methods ---------
    private void DisplayTypeItems() => ItemManager.Instance.DisplayType(itemType);
    #endregion ------------------

    #region --------- Public Methods ---------
    #endregion ------------------
}
