using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumDosNum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {2,7,11,15};
        int target = 9;

        int[] res = SumDos(nums, target);

        foreach(var num in res)
            Debug.Log(num);

    }

    public int[] SumDos(int[] nums, int target)
    {
        int[] res = new int[2];

        //O(n^2)
        for(int i=0; i<nums.Length; i++)
        {
            for(int j=0; j<nums.Length; j++)
            {
                if( (nums[i]+nums[j]) == target)
                {
                    res[0]=i;
                    res[1]=j;
                    return res;
                }
            }
        }
        
        return res;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
