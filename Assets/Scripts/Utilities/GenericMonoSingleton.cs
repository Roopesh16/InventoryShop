using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryShop.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance = null;

        public static T Instance { get { return instance; } }

        private void Awake()
        {
            if(instance == null)
                instance = (T)this;
            else if(instance != this)
            {
                Destroy(this);
            }
        }
    }
}

