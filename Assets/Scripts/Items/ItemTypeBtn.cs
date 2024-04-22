using UnityEngine.UI;
using UnityEngine;
using InventoryShop.Managers;

public class ItemTypeBtn : MonoBehaviour
{
    #region --------- Serialized Variables ---------

    [SerializeField] private ItemType itemType;
    #endregion ------------------

    #region --------- Private Variables ---------

    private Button typeBtn;
    #endregion ------------------

    #region --------- Monobehavior Methods ---------

    private void Awake()
    {
        typeBtn = GetComponent<Button>();
        typeBtn.onClick.AddListener(DisplayTypeItems);
    }
    #endregion ------------------

    #region --------- Private Methods ---------

    private void DisplayTypeItems() => GameManager.Instance.DisplayTypeItem(itemType);
    #endregion ------------------
}
