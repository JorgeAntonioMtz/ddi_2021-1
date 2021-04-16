using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikachu : Interactable
{
    AudioSource m_MyAudioSource;
	bool m_Play;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
	{
		if(m_Play==false)
		{
			m_Play=true;
			m_MyAudioSource.Play();
			Debug.Log("Pikachu Cry playing");
		}
		m_Play=false;

	}
}
