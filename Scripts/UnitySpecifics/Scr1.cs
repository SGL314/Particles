using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Errors : MonoBehaviour
{
    


}

public class Updates : MonoBehaviour
{
    private void FixedUpdate() // constantum
    {
        Debug.Log("Ola FU " + Time.deltaTime);
    }


    void Update()
    {
        Debug.Log("Ola U " + Time.deltaTime);
    }
}

public class Scr1 : MonoBehaviour
{
    public int a, b=1, r;
    void Start()
    {
        //try
        //{
        //    r = a / b;
        //}
        //catch (UnityException err)
        //{
        //    //throw 
        //    // print($"{a} não pode ser divido por {b} : {err}")
        //}
        //finally
        //{
        //    print("hmm...");
        //}

        //if (b < 0)
        //{
        //    throw new System.Exception($"{a} não pode ser divido por {b} : {1 + 0.1f}");
        //}
    }
}
