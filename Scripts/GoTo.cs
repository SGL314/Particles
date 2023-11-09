using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    void Start()
    {   
        p_i:
        int s = Random.Range(0, 101);
        while (s < 100)
        {
            
            goto p_i;
        }
        print(s);
    }

    void Update()
    {
        
    }
}
