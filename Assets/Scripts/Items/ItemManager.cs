using InventoryShop.ScriptableObjects;
using System.Collections.Generic;
using InventoryShop.Items;
using UnityEngine;

namespace InventoryShop.Managers
{
    public class ItemManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private List<ItemScriptableObject> itemsList = new();
        [SerializeField] private ItemView itemPrefab;
        [SerializeField] private Transform shopGridTransform;
        #endregion ------------------

        #region --------- Private Variables ---------
        private static ItemManager instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static ItemManager Instance
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

        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        public void SpawnItems(Transform parentTransform, ItemType? itemType)
        {
            if (itemType == null)
            {
                foreach (ItemScriptableObject item in itemsList)
                {
                    ItemController itemController = new(item, itemPrefab, shopGridTransform);
                }
            }
        }
        #endregion ------------------
    }

}
