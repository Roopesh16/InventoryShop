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
    private ItemService itemService;
    #endregion ------------------

    #region --------- Monobehavior Methods ---------
    private void Awake()
    {
        typeBtn = GetComponent<Button>();

        typeBtn.onClick.AddListener(DisplayTypeItems);
    }
    #endregion ------------------

    #region --------- Private Methods ---------
    private void DisplayTypeItems() => itemService.DisplayType(itemType);
    #endregion ------------------

    #region --------- Public Methods ---------
    public void Init(ItemService itemService) => this.itemService = itemService;
    #endregion ------------------
}
