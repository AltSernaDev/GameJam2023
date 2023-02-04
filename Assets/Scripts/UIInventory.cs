using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    public GameObject[] slotUI;

    private void OnEnable()
    {
        inventoryManager.onAddItem += SetIcon;
    }

    private void OnDisable()
    {
        inventoryManager.onAddItem -= SetIcon;
    }

    private void SetIcon(int index)
    {
        slotUI[index].GetComponent<Image>().sprite = inventoryManager.invetoryItems[index].items[0].icon;
    }



}
