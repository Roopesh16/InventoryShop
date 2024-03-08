using UnityEngine;

namespace InventoryShop.Managers
{
    public class ShopManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
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
            ItemManager.Instance.SpawnItems(materialGridTransform,ItemType.MATERIAL);
            ItemManager.Instance.SpawnItems(weaponGridTransform,ItemType.WEAPON);
            ItemManager.Instance.SpawnItems(consumableGridTransform, ItemType.CONSUMABLE);
            ItemManager.Instance.SpawnItems(treasureGridTransform, ItemType.TREASURE);
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        #endregion ------------------
    }
}
