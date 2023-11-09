using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Geral : MonoBehaviour
{
    public static float velocitè = 2f;
    public static float Velocitè{
        get { return velocitè;}
        set { velocitè =value;}
    }

    public static int qntd_enemys = 0;
    [SerializeField]
    public static float velocit_enemy1 = 1f;
    public float giro = 30f;
    public float time_current = 0;
    public static string nome_player = "Player1", nome_textoplayer = "TextoPlayer", nome_enemy_reserved = "Enemy1R",nome_enemy_normal = "Enemy1";
    public static GameObject player_G_O, txt,pla;
    public static float TimeSep = 0.001f;
    private const float TimeNormal = 0.001f;

    // public Dictionary<string, Queue<GameObject>> DictObjects = new Dictionary<string, Queue<GameObject>>();

    void Start()
    {
        // cam = GetComponent<Camera>();
        pla = GameObject.Find(nome_player);
    }
    void Update()
    {
        time_current += Time.deltaTime;

        player_G_O = GameObject.Find(nome_player);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            
        }
        TimeSep = TimeNormal * TimeNormal / Time.deltaTime;

        //player_G_O = 
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        //}


    }
}
