using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory InventoryInstance { get { return s_InventoryInstance; } }

    public delegate void OnChange();
    public OnChange onChange;

    public int slots = 6;
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        s_InventoryInstance = this;
    }

    public Item[] GetAllItemsByType(ItemType type)
    {
        return items.Where(i => i.itemType == type).ToArray();
    }

    public void Add(Item newItem)
    {
        if(items.Count < slots)
            items.Add(newItem);
        if (onChange != null)
        {
            onChange.Invoke();
        }
        else
        {
            Debug.Log("No hay espacio en el inventario");
        }
    }

    public void Remove(Item itemToRemove)
    {
        if(items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            if (onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.Log("No existe este item");
        }
    }

}
