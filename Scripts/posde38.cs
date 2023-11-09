using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Moto
{
    public float potency;
    public string marca;

    public Moto(float potency,string marca)
    {
        this.potency = potency;
        this.marca = marca;
    }

    public void tellPot()
    {
        Debug.Log($"Potencia ({marca}): {potency}");
    }

}

public class posde38 : MonoBehaviour
{
    //Moto oneMoto = new Moto(1.5f,"Motors");

    delegate void del(); // tipo : com mesma assinatura
    del exemplodel1;
    void Start()
    {
        //print("ola");
        //oneMoto.potency = 1f;
        //oneMoto.tellPot();
        //print("ola");
        // aft
        exemplodel1 = atak1;
        exemplodel1 += def;
        exemplodel1();

        exemplodel1 = def;
        atak2(exemplodel1);
        exemplodel1 = def;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void atak1()
    {
        // 
    }
    void atak2(del metod)
    {
        // 
    }
    void def()
    {

    }
}


// Interfaces
public interface Iinterations <T,a> 
{
    // declara métodos
    void inter(float T);
    void inter2(int a);

}

public class door : MonoBehaviour, Iinterations <float,int>
{

    public void inter(float T) // obrigatorio public
    {
        // codices
    }
    public void inter2(int a)
    {
        // codices
    }
}
// Delegates
//  : referencia a um método