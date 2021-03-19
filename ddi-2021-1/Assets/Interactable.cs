using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone=false;
    //public KeyCode interactionKey = KeyCode.E;
    public string interactionButton = "Interact";

    public virtual void Update()
    {
        //if(isInsideZone && Input.GetKeyDown(interactionKey))
        if(isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton))
        {
            Interact();
        }
    }

    //Is called when the collider other enters the trigger
    //<param name ="other">The other Collider involved in this collision.</param>
     void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        //Debug.Log("Entro trigger");
        isInsideZone = true;
    }

    void OnTriggerExit(Collider other) {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        //Debug.Log("Salio trigger");
        isInsideZone = false;
    }

    public virtual void Interact()
    {
        Debug.Log("Interaccion");
    }
}
