using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboScript : Interactable
{
    private Rigidbody rb;
    private bool isBig = false;

    void Start()
    {
        // Debug.Log("Hola crayola!");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        //base.Update();
        
    }

    public override void Interact()
    {
        Debug.Log("Interacción ...");
        if(!isBig)
            rb.transform.localScale = new Vector3(1,1,1);
        else
            rb.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
        isBig = !isBig;
    }
}