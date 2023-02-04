using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public InventoryManager inventory;
    public Slot test1;
    public Collectable a;
    public Collectable b;
    public Collectable retuned;


    private void Start()
    {
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(b);
        inventory.AddToInventory(b);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        inventory.AddToInventory(a);
        Invoke("TestRemove",10.0f);

        Debug.Log(inventory.invetoryItems[0]); 
        
        


    }
    void TestRemove()
    {
        retuned = inventory.RemoveItem(0);
    }
}
