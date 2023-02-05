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

    private void Start()
    {
        SlotSlected(inventoryManager.SlotSlectedt);
        slotUI[0].GetComponentInChildren<Text>().text = inventoryManager.ChangeNumber(0).ToString();

    }

    private void Update()
    {
        //UpdateStack();
    }

    private void OnEnable()
    {
        inventoryManager.onAddItem += SetIcon;
        inventoryManager.onSlotEmpty += SetDefaultIcon;
        inventoryManager.onSlotSelectedChanged += SlotSlected;
        InventoryManager.onItemCounted += UpdateStack;
    }

    private void OnDisable()
    {
        inventoryManager.onAddItem -= SetIcon;
        inventoryManager.onSlotEmpty -= SetDefaultIcon;
        inventoryManager.onSlotSelectedChanged -= SlotSlected;
        InventoryManager.onItemCounted -= UpdateStack;
        
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
        foreach (var slot in slotUI)
        {
            slot.GetComponent<Image>().color = Color.white;
        }
        slotUI[index].GetComponent<Image>().color = Color.gray;
    }

    private void UpdateStack()
    {
        for (int i = 0; i < slotUI.Length; i++)
        {
            slotUI[i].GetComponentInChildren<Text>().text = inventoryManager.ChangeNumber(i).ToString();
        }

    }



}
