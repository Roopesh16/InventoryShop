using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static GenericMonoSingleton instance = null;

        public static GenericMonoSingleton Instance { get { return instance; } }

        private void Awake()
        {
            if(instance == null)
                instance = this;
            else if(instance != this)
            {
                Destroy(this);
            }
        }
    }
}

