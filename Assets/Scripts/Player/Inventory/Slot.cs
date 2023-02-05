using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class Slot : MonoBehaviour
{
    [SerializeField]private Sprite itemIcon;
    [SerializeField]public List<Seeds> items;
    [SerializeField]public int itemsCount;
    [SerializeField]public int maxStorage;



    public bool CanEnqueue()
    {
        if (items.Count < maxStorage) return true;
        return false;
    }

    public bool canRemove()
    {
        if (items.Count > 0) return true;
        return false;
    }





    public void AddItem(Seeds item)
    {
        items.Add(item);
        itemsCount = items.Count;
        InventoryManager.onItemCounted();
    }

    public Seeds RemoveItem()
    {
        var colleted = items[0];
        items.Remove(items[0]);
        itemsCount = items.Count;
        InventoryManager.onItemCounted();
        return colleted;
    }



}
