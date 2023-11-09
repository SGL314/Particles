using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Script_de_Teste : MonoBehaviour
{
    //Cell cl1 = new Cell();
   
    void Start()
    {
        //print(cl1.velocidade);
    }

    // Update is called once per frame
    public int ind1 = 0;
    
    public float tempo = 0,ping;
    void Update()
    {
        //tempo = tempo + Time.deltaTime;
        //ping = Time.deltaTime;
        //print(tempo);
        //print(ping);
    }

    static void sl(double time)
    {
        Thread.Sleep(Convert.ToInt32(time*1000));
    }

    static void lear_lists()
    {
        /* 
        
        Declaração:
        List<{tipo}> {nome} = new List<{tipo}>():
        Métodos: 
        Add : adiciona
        Remove : remove um item
        RemoveAt : remove o indice
        Clear : limpa a lista
        IndexOf : retorna indice do elemento (menor)
        lastIndexOF : ultimo indice do elemento
        Atributos:
        Count : tamanho
        */
    }

    static void learn_dictionarys()
    {
        /* 
        
        Declaração:
        Dictionary<{tipo chave},{tipo valor}> {nome} = new Dictionaryy<{tipo chave},{tipo valor}>():
        {nome}[{chave}] : acessa valor
        Métodos: 
        Add : adiciona
        Remove : remove um item
        RemoveAt : remove o indice
        Clear : limpa a lista
        IndexOf : retorna indice do elemento (menor)
        lastIndexOF : ultimo indice do elemento
        Atributos:
        Count : tamanho
        */
    }
}

