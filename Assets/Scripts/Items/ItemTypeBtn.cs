using UnityEngine.UI;
using UnityEngine;
using InventoryShop.Managers;

public class ItemTypeBtn : MonoBehaviour
{
    #region --------- Serialized Variables ---------

    [SerializeField] private ItemType itemType;
    [SerializeField] private Button typeBtn;
    #endregion ------------------

    #region --------- Monobehavior Methods ---------

    private void Awake()
    {
        typeBtn.onClick.AddListener(DisplayTypeItems);
    }
    #endregion ------------------

    #region --------- Private Methods ---------

    private void DisplayTypeItems() => GameManager.Instance.DisplayTypeItem(itemType);
    #endregion ------------------
}
