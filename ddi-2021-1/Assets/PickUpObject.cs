using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{
    public Item item;
    public GameObject gameObject;

    public override void Interact()
    {
        //base.Interact();
        Inventory.InventoryInstance.Add(item);
        //Destroy(this.gameObject);
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void InteractMega()
    {
        Debug.Log("asdasdad");
    }
}
