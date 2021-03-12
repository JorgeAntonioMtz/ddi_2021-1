using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{
    public Item item;
    public override void Interact()
    {
        //base.Interact();
        Inventory.InventoryInstance.Add(item);
        Destroy(this.gameObject);
    }
}
