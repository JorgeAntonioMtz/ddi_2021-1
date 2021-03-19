using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitosPares : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {12, 345, 2, 6, 7896};

        Debug.Log("Digitos pares: " + EvenDigits(nums).ToString());
    }

    int EvenDigits(int[] nums)
    {
        int counter=0;
        bool isEven;
        int aux;

        for(int i=0; i<nums.Length; i++)
        {
            isEven=false;
            aux=nums[i];
            while(aux > 0)
            {
                aux=aux/10;
                if(aux > 0)
                    isEven=!isEven;
            }
            if(isEven)
                counter++;
        }

        return counter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
