using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] public Slot[] invetoryItems ;
    [SerializeField] public UnityAction<int> onAddItem;



    public void AddToInventory(Collectable item)
    {
        for (int i = 0; i < invetoryItems.Length; i++)
        {
            if (invetoryItems[i].itemsCount <= 0)
            {
                invetoryItems[i].AddItem(item);
                Debug.Log(invetoryItems[i].itemsCount);
                onAddItem?.Invoke(i);
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

    public Collectable RemoveItem(int slot)
    {
        if(invetoryItems[slot].canRemove())return invetoryItems[slot].RemoveItem();
        return null;

    }
}
