using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour //Interactable
{

    AudioSource m_MyAudioSource;
	bool m_Play;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    /* public override void Interact()
    {
        Debug.Log("Hola");
        if(m_Play==false)
        {
            m_Play=true;
            m_MyAudioSource.Play();
        }
        m_Play=false;
    } */

}
