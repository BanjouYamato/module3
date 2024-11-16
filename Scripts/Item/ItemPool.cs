using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    Dictionary<GameObject, List<GameObject>> itemsPool;
    ItemManager itemManager;
    private void Awake()
    {   
        itemManager = GetComponent<ItemManager>();
        itemsPool = new();
        foreach (var item in itemManager.Items)
        {
            itemsPool[item] = new();
        }
    }
    public GameObject GetItems(GameObject obt)
    {
        if (itemsPool.ContainsKey(obt))
        {
            foreach (var item in items)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                }
            }
            GameObject newItem = Instantiate(obt);
            items.Add(newItem);
            return newItem;
        }
        else
        {
            Debug.Log("Error on itemPool");
            return null;
        }
    }
}
