using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Items
{
    public class ItemManager : MonoBehaviour
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private List<ItemScriptableObject> itemsList = new();
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
            foreach(ItemScriptableObject item in itemsList)
            {
                ItemController itemController = new (item);
            }
        }
        #endregion ------------------

        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------
        #endregion ------------------
    }

}
