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


    [SerializeField] private int slotSlectedt = 0;

    public Slot[] invetoryItems;
    public UnityAction<int> onAddItem;

    public int SlotSlectedt
    {
        get { return slotSlectedt; }
        set
        {
            if (value > invetoryItems.Length)
            {
                slotSlectedt = invetoryItems.Length;
                return;

            }
            if (value < 0)
            {
                slotSlectedt = 0;
                return;

            }
            slotSlectedt = value;
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) SlotSlectedt++;
        if (Input.GetKeyDown(KeyCode.O)) SlotSlectedt--;

    }

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

    public Collectable RemoveItem()
    {
        if (invetoryItems[SlotSlectedt].canRemove())
        {
            return invetoryItems[SlotSlectedt].RemoveItem();
        }
        else
        {
            return null;
        }
    }
}
