using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Sprite emptySlot;
    [SerializeField] private InventoryManager inventoryManager;
    public GameObject[] slotUI;


    private void OnEnable()
    {
        inventoryManager.onAddItem += SetIcon;
        inventoryManager.onSlotEmpty += SetDefaultIcon;
    }

    private void OnDisable()
    {
        inventoryManager.onAddItem -= SetIcon;
        inventoryManager.onSlotEmpty -= SetDefaultIcon;
    }

    private void SetIcon(int index)
    {
        slotUI[index].GetComponent<Image>().sprite = inventoryManager.invetoryItems[index].items[0].icon;
    }

    private void SetDefaultIcon(int index)
    {
        slotUI[index].GetComponent<Image>().sprite = emptySlot;
    }

    private void SlotSlected(int index)
    {
        slotUI[index].GetComponent<Image>().color = Color.gray;
    }



}
