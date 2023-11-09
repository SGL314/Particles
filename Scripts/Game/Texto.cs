using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Player;

public class Texto : Geral
{
    public TMP_Text texto;

    public delegate void AttText();
    public event AttText OnAttText;
    public float vx=0,vy=0,vz=1f;

    private void Awake()
    {
        texto = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        switch (gameObject.name)
        {
            case "TextoPlayer":
                OnAttText += txt_velPlayer;
                vx = 420.3f;
                vy = 230f; 
                vz = 1f;
                break;
        }
        OnAttText += txt_target;
        

    }

    private void Update()
    {
        
        pla = GameObject.Find(nome_player);
        if (pla != null)
        {
            //transform.position = new Vector3(pla.transform.position.x,pla.transform.position.y, pla.transform.position.z + vz);
            if (OnAttText != null)
            {
                //print("ox");
                OnAttText();
            }
        }
        else
        {
            //print("uai");
        }
    }

    private void txt_velPlayer()
    {
        texto.text = $"Velocidade = {Velocitè:F1}";
    }

    private void txt_target()
    {
        //Delegate[] del = OnFollower.GetInvocationList();
        texto.text += $"\nTarget : {0}\nQntd : {Geral.qntd_enemys}\nTS : {TimeSep}";
    }
}
