using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Enemy1 : MonoBehaviour, Interf1
{
    // Start is called before the first frame update
    //EnemyMain inimigo = new EnemyMain("Adstra");
    public delegate void EnemyDeath();
    private GameObject pla;
    public static event EnemyDeath OnEnemyDied;
    public float vida = 10f;
    private static float velL = 2f;
    public bool execute_functions = true;
    public static float VelL
    {
        get { return velL; }
    }

    private Vector3 prop;
    System.Random rd = new System.Random();
    int count_mult = 0;
    [SerializeField]
    private float sec_mult = 5f;
    bool stop = false;

    private delegate void NormalFunctions();
    private static event NormalFunctions OnNormalFunctions;
    


    IEnumerator Multiply()
    {
        
        yield return new WaitForSeconds(sec_mult);

        if (vida > 0)
        {
            int dirx, diry;
            float vx=0, vy=0, px=0, py=0;
            int[] vars = new int[2] { -1, 1 };

            px = transform.position.x;
            py = transform.position.y;

            if (rd.Next(0, 2) == 0)
            {
                dirx = vars[rd.Next(0, 2)];
                vx = this.prop.x * dirx;
                px += vx;
            }
            else
            {
                diry = vars[rd.Next(0, 2)];
                vy = this.prop.y * diry;
                py += vy;
            }

            sec_mult -= (sec_mult > 2.5f) ? 0.25f : 0;
            execute_functions = true;
            gameObject.name = Geral.nome_enemy_normal;
            bool v1 = this.stop;
            this.stop = false;


            Instantiate(gameObject, new Vector3(px, py, transform.position.z), transform.rotation);

            this.stop = v1;
            count_mult += 1;
            if (count_mult == 2)
            {
                //print(Geral.velocit_enemy1);
                Destruir();
            }


            StartCoroutine(Multiply());
        }
    }

    private void Awake()
    {
        print($"new enemy1 {gameObject.name}");
        if (gameObject.name != Geral.nome_enemy_reserved)
        {
            prop = GetComponent<Renderer>().bounds.size;
            //StartCoroutine(Multiply());
            //OnNormalFunctions += Perseg;
            OnNormalFunctions += LogVida;
            OnNormalFunctions += LinearVariation;
        }
        else
        {
            execute_functions = false;
        }
        AleatrDirection();
    }

    void Update()
    {
        if (OnNormalFunctions != null && stop == false)
        {
            OnNormalFunctions();
        }
    }

    private void LinearVariation()
    {
        transform.Translate(0,velL*Geral.TimeSep,0);
    }

    private void LogVida()
    {
        if (vida <= 0)
        {
            if (OnEnemyDied != null) //  para ver se o delegate tem função
            {
                OnEnemyDied();
            }
            Destruir();

        }
    }

    private void Perseg()
    {
        pla = Geral.player_G_O;
        if (pla != null)
        {
            double ang_set = Relativo_Angular(pla.gameObject, this.gameObject);
            GoRelAng(ang_set);
        }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
        Destroy(this);
        OnNormalFunctions -= Perseg;
        OnNormalFunctions -= LogVida;
        OnNormalFunctions -= LinearVariation;
        this.stop = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && execute_functions)
        {
            Destroy(player.gameObject);
        }
    }

    private void AleatrDirection()
    {
        float ang = rd.Next(0, 361000)/1000;
        transform.Rotate(0, 0, ang);
    }

    public void GoRelAng(double angulo_para_ir)
    {
        double vx, vy, vz=0;
        float nx=0,ny=0,nz=0;
        vx = Math.Cos(angulo_para_ir*Math.PI/180) * Geral.velocit_enemy1;
        vy = Math.Sin(angulo_para_ir*Math.PI/180) * Geral.velocit_enemy1;
        vz = 0;

        if (Geral.TimeSep != float.NaN)
        {
            nx = (float)vx * Geral.TimeSep;
            ny = (float)vy * Geral.TimeSep;
            nz = (float)vz;
            gameObject.transform.Translate(nx, ny, nz);
        }
        //try
        //{
        //    //print($"{nx} {ny} {Geral.TimeSep}");
            
        //}
        //catch { }

    }

    static internal double Relativo_Angular(GameObject player, GameObject me)
    {
        double ax, ay, bx, by;
        ax = player.transform.position.x; ay = player.transform.position.y;
        bx = me.transform.position.x; by = me.transform.position.y;
        double ang = Calc_Ang(ax, ay, bx, by);
        return ang;
    }

    static internal double Calc_Ang(double ax, double ay, double bx, double by)
    {
        double dx = ax - bx;
        double dy = ay - by;
        //double nx=0,ny =0;
        double soma = 180;
        if (dx >= 0)
        {
            soma += 180;
        }
        double ang = (Math.Atan(dy / dx) * 180 / Math.PI + soma) % 360;
        //Console.WriteLine($"{dx} {dy}");
        return ang;

    }

    
}

