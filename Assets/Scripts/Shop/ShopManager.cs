using UnityEngine;

namespace InventoryShop.Managers
{
    public class ShopManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [Header("Grid Transforms")]
        [SerializeField] private Transform shopGridTransform;
        [SerializeField] private Transform materialGridTransform;
        [SerializeField] private Transform weaponGridTransform;
        [SerializeField] private Transform consumableGridTransform;
        [SerializeField] private Transform treasureGridTransform;
        #endregion ------------------

        #region --------- Private Variables ---------
        private static ShopManager instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ShopManager Instance
        {
            get { return instance; }
        }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        private void Start()
        {
            ItemManager.Instance.SpawnItems(shopGridTransform);
            ItemManager.Instance.SpawnItems(materialGridTransform, ItemType.MATERIAL);
            materialGridTransform.gameObject.SetActive(false);
            ItemManager.Instance.SpawnItems(weaponGridTransform, ItemType.WEAPON);
            weaponGridTransform.gameObject.SetActive(false);
            ItemManager.Instance.SpawnItems(consumableGridTransform, ItemType.CONSUMABLE);
            consumableGridTransform.gameObject.SetActive(false);
            ItemManager.Instance.SpawnItems(treasureGridTransform, ItemType.TREASURE);
            treasureGridTransform.gameObject.SetActive(false);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        #endregion ------------------
    }
}
