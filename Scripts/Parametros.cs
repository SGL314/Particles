//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class Parametros : MonoBehaviour
{
    public int v = 67;
    System.Random rd = new System.Random();
    //Player pl = new Player("One");


    void Start()
    {
        int rand = rd.Next(0, 10);
        print($"{v} {rand}");
        exemp1(ref v, out rand);
        print($"{v} {rand}");
        int soma = Soma_args(1,2,3,4,5,6,7,8,9);
        print(soma );
    }



    void exemp1(ref int n, out int r)
    {
        n += 1;
        r = rd.Next(0, 10);
    }

    void Update()
    {

    }

    int Soma_args(params int[] array)
    {
        int s = 0;
        foreach (int v in array)
        {
            s += v;
        }
        return s;
    }

}
