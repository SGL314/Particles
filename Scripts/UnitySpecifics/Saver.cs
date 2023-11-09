using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField]
    private int cont;
    void Start()
    {
        // PlayerPrefs.HasKey("cont"); // ve se a chave existe
        // Playe`Prefs.DeleteKey("cont"); //obvious
        cont = PlayerPrefs.GetInt("cont");
        cont += 1;
        print(cont);
        PlayerPrefs.SetInt("cont",cont);
        PlayerPrefs.Save();
        // chave , variável
        // print();
    }


}
