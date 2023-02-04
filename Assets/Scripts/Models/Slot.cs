using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]private Sprite itemIcon;
    [SerializeField]public List<Collectable> items;
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

    public TypeItem CheckTypeItem()
    {
        return items[0].thisItem;

    }



    public void AddItem(Collectable item)
    {
        items.Add(item);
        itemsCount = items.Count;
        Debug.Log(itemsCount);
    }

    public Collectable RemoveItem()
    {
        var colleted = items[0];
        items.Remove(items[0]);
        itemsCount = items.Count;
        return colleted;
    }



}
