using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotinas : MonoBehaviour
{
    IEnumerator rotina()
    {
        print("Iniciando");
        yield return new WaitForSeconds(2);
        print("Returning");
        yield return null;
    }

    private void Start()
    {
        StartCoroutine(rotina());
    }
}
