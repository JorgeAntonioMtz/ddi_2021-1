using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numLessThan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numArr = {8,1,2,2,3};
        int[] output = numberLessThan(numArr);
        foreach(var num in output)
        {
            Debug.Log(num);
        }
        
    }

    private int[] numberLessThan(int[] arr)
    {
        int[] temp = {0,0,0,0,0};
        int count = 0;

        for(int i=0; i<arr.Length; i++){ 
            for(int j=0; j<arr.Length; j++){
                if(i!=j){
                    if(arr[j]<arr[i]){
                        count++;
                    }
                }
            }
            temp[i]=count;
            count=0;
        }
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
