using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeUnity : MonoBehaviour
{
    

    private void Awake() //  m�todo de MonoBehaviour // antes do me�todo Start, antes do primeiro frame
    {
        Debug.Log("Awake");
    }
    void Start()

    {
        print("Start");
    }
}
