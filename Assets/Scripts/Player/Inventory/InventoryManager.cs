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
    public UnityAction<int> onSlotEmpty;
    public UnityAction<int> onSlotSelectedChanged;
    public static UnityAction onItemCounted;

    public int SlotSlectedt
    {
        get { return slotSlectedt; }
        set
        {
            if (value < 0)
                value = invetoryItems.Length - 1;

            slotSlectedt = value % invetoryItems.Length;
            print(slotSlectedt);
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SlotSlectedt++;
            onSlotSelectedChanged?.Invoke(slotSlectedt);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SlotSlectedt--;
            onSlotSelectedChanged?.Invoke(slotSlectedt);
            
        }

    }

    public void AddToInventory(Seeds item)
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

            if (invetoryItems[i].itemsCount > 0 && item.tipo == invetoryItems[i].items[0].tipo)
            {
                if (invetoryItems[i].CanEnqueue())
                {
                    invetoryItems[i].AddItem(item);
                    return;
                }
            }
            

        }

    }

    public Seeds RemoveItem()
    {
        if (invetoryItems[SlotSlectedt].canRemove())
        {
            var temp= invetoryItems[SlotSlectedt].RemoveItem();
            if(invetoryItems[SlotSlectedt].items.Count <= 0) onSlotEmpty?.Invoke(SlotSlectedt);
            return temp;
        }
        else
        {
            return null;
        }
        
        
    }

    public int ChangeNumber(int pos)
    {
        return invetoryItems[pos].itemsCount;

    }
}
