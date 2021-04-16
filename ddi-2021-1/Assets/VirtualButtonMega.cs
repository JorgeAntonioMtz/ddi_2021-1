using UnityEngine;
using Vuforia;

public class VirtualButtonMega : MonoBehaviour, IVirtualButtonEventHandler
{
    //public Interactable interactableObject;
    public GameObject gameobject;
    private VirtualButtonBehaviour virtualButton;
    

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //interactableObject.InteractMega();
        gameobject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Debug.Log("Megaaaaaa");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        gameobject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
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
