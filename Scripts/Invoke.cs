using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Like", 3.4f);
        // invoka a fun��o Like ap�s 3.4 segundos
        // InvokeRepeating("Like", 2.5f,1.5f);
        // repete uma invoca��o


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Like()
    {
        print("Like agora");
    }
}
