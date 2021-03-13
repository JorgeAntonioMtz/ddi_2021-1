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
        /*Item[] equipItems = _inventory.GetAllItemsByType(ItemType.Equip);
        Item[] weaponItems = _inventory.GetAllItemsByType(ItemType.Weapon);
        Item[] consumableItems = _inventory.GetAllItemsByType(ItemType.Consumable);
        

        if (equipItems.Length > 0)
            slots[0].SetItem(equipItems[0], equipItems.Length);
        if (weaponItems.Length > 0)
            slots[1].SetItem(weaponItems[0], weaponItems.Length);
        if (consumableItems.Length > 0)
            slots[2].SetItem(consumableItems[0], consumableItems.Length);*/
        
        //Debug.Log("Cambió inventario");
         for (int i = 0; i < slots.Length; i++)
         {
             if (i < _inventory.items.Count)
             {
                 slots[i].SetItem(_inventory.items[i], 1);
             }
             else
             {
                 slots[i].Clear();
             }
         }
    }
}
