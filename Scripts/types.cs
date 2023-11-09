using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class types : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("virtual : método de classe que pode ser mudado");
        print("override : método de classe que foi mudado");
        print("abstract : classe que não pode ser instanciada, mas pode ser herdada");
        print("sealed : classe que não pode ser herdada, mas pode ser instanciada");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
