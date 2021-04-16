using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public Interactable interactableObject;
    private VirtualButtonBehaviour virtualButton;
    //AudioSource m_MyAudioSource;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        interactableObject.Interact();
        //m_MyAudioSource.Play();
        Debug.Log("Se presionó");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Se levantó");
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        virtualButton = GetComponent<VirtualButtonBehaviour>();
    }

    void Start()
    {
        if (virtualButton != null)
        {
            virtualButton.RegisterEventHandler(this);
        }
    }
}
