using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Store : MonoBehaviour
{
    [SerializeField] ItemUI prefab;
    [SerializeField] StoreItemSO[] items = new StoreItemSO[0];
    [SerializeField] Transform parent = null;

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            var newObj = Instantiate(prefab, parent);
            newObj.SetItem(items[i]);
        }
    }

}