using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NumeroUnico : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {4, 1, 2, 2, 1};
        Debug.Log("Numero sin repetir: "+SingleNumber(nums).ToString());
    }

    int SingleNumber(int[] arr)
    {
        int res = arr[0];
        for (int i = 1; i < arr.Length; i++)
            res = res ^ arr[i];
     
        return res;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
