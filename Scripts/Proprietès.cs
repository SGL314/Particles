using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proprietès : MonoBehaviour
{
    public Prop p1 = new Prop();
    private int eks = 8;

    // Start is called before the first frame update
    void Start()
    {
        eks = p1.V;
        print(eks);
        p1.V = 9;
        eks = p1.V;
        print(eks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Prop
{
    private int v = 10;
    public int V
    {
        get { return v; }
        set { 
            if (value > v)
            {
                v = value;
            }
        }

    }
}
