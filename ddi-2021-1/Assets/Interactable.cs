using System.Collections;
using System.Collections.Generic;
using IBM.Watsson.Examples;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    public bool gazedAt = false;

    public float gazeInteractTime = 2f;
    public float gazeTimer = 0;
    //public KeyCode interactionKey = KeyCode.E;
    public string interactionButton = "Interact";

    public string voiceCommand = "use";

    private void Start()
    {
        VoiceCommandProcessor commandProcessor = GameObject.FindObjectOfType<VoiceCommandProcessor>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
    }

    public virtual void Update()
    {
        //if(isInsideZone && Input.GetKeyDown(interactionKey))
        if(isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton))
        {
            Interact();
        }
        if (gazedAt)
        {
            if ((gazeTimer += Time.deltaTime) >= gazeInteractTime)
            {
                Interact();
                gazedAt = false;
                gazeTimer = 0f;
            }
        }
    }

    public void OnVoiceCommandRecognized(string command)
    {
        if(command.ToLower() == voiceCommand.ToLower() && gazedAt)
            Interact();
    }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        if (!gazedAt)
        {
            gazeTimer = 0f;
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        gazeTimer = 0f;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        gazeTimer = 0f;
    }

    private void OnMouseDown() {         //OnMazda
        Interact();
        Debug.Log("Interaccion OnMouseDown");
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
