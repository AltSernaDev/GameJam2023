using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] public Slot[] invetoryItems ;



    public void AddToInventory(Collectable item)
    {
        for (int i = 0; i < invetoryItems.Length; i++)
        {
            if (invetoryItems[i].itemsCount <= 0)
            {
                invetoryItems[i].AddItem(item);
                Debug.Log(invetoryItems[i].itemsCount);
                return;
            }

            if (invetoryItems[i].itemsCount > 0 && item == invetoryItems[i].items[0])
            {
                if (invetoryItems[i].CanEnqueue())
                {
                    invetoryItems[i].AddItem(item);
                    return;
                }
            }

        }

    }
    public void RemoveItem
}
