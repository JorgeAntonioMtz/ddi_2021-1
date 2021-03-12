using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject panel;
    void Start()
    {
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //toggle
            panel.SetActive(!panel.activeSelf);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        Item[] equipItems = _inventory.GetAllItemsByType(ItemType.Equip);
        Item[] usableItems = _inventory.GetAllItemsByType(ItemType.Usable);
        //Item[] medicineItems = _inventory.GetAllItemsByType(ItemType.Medicine);

        if (equipItems.Length > 0)
            slots[0].SetItem(equipItems[0], equipItems.Length);
        if (usableItems.Length > 0)
            slots[1].SetItem(usableItems[0], usableItems.Length);
        /*if (medicineItems.Length > 0)
            slots[2].SetItem(medicineItems[0], medicineItems.Length);*/
        Debug.Log("Cambió inventario");
        // for (int i = 0; i < slots.Length; i++)
        // {
            // if (i < _inventory.items.Count)
            // {
            //     slots[i].SetItem(_inventory.items[i]);
            // }
            // else
            // {
            //     slots[i].Clear();
            // }
        // }
    }
}
