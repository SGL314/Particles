using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Geral
{
    // Start is called before the first frame update
    string nome;
    public int already_comemorate = 0;
    Rigidbody rb;
    // private float[] props = new float[2] { 0.236864f, 0.2889261f };
    //[SerializeField]
    //private static bool follow_enemy = false;
    public delegate void Follower();
    public static event Follower OnFollower;
    private int ètat;

    //[SerializeField]
    //private Vector3 pos_player;
    [SerializeField]
    float time_gun_on = 0.1f;
    float time_count_gun_on = 0;
    float tempo_CFollower = 0.00001f;
    //public GameObject Playery;

    IEnumerator CAtirar()
    {
        yield return new WaitForSeconds(time_gun_on);
        Atirar();
    }

    IEnumerator List_objects()
    {
        //int qt = 0;
        yield return new WaitForSeconds(1f);
        UnityEngine.Object[] objts = GameObject.FindObjectsOfType(typeof(Enemy1));

        Geral.qntd_enemys = objts.Length -1;
        
        StartCoroutine(List_objects());
    }

    IEnumerator CFollower()
    {
        if (OnFollower != null)
        {
            OnFollower();
        }
        yield return new WaitForSeconds(tempo_CFollower);
        StartCoroutine(CFollower());
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //print($"{transform.eulerAngles.z}");
        //OnFollower += follow_mouse;
        ètat = 0;
        StartCoroutine(List_objects());
        StartCoroutine(CFollower());
    }

    private void Start()
    {

        Enemy1.OnEnemyDied += this.comemorar;

    }

    void Update()
    {


        if (already_comemorate == 1)
        {
            Enemy1.OnEnemyDied -= this.comemorar;
        }
        moviment();
        //pos_player = transform.position;
        time_count_gun_on += TimeSep;

        controller();

        GameObject bullet = GameObject.Find("BulletB");
        if (bullet != null)
        {
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            bullet.transform.rotation = transform.rotation;
        }
        // Super Calculus
        GameObject alvo = GameObject.Find(nome_enemy_normal);
        if (alvo != null)
        {
            CalcVetorial(alvo);
            //print("here");
        }

        
    }


    private void Atirar()
    {
        float vx=0, vy=0;
        //print($"rot.z = {transform.rotation.z}");
        //print((transform.rotation.z + 90));
        float raio = gameObject.transform.localScale.y + 0.1f;
        //print($"raio : {raio}"); 

        float ang = (float) ((transform.rotation.z * transform.rotation.w * 180+90)*Math.PI/180);

        if (Math.Abs(transform.rotation.z) >= Math.Pow(2, 0.5D) / 2)
        {
            ang =(float) ( (360 - ang * 180 / Math.PI)*Math.PI/180);
        }


        vx = (float) ((raio)*Math.Cos(ang));
        vy = (float) ((raio)*Math.Sin(ang));

        //print($"ang : {ang*180/Math.PI} ; {transform.rotation.z} px :{transform.position.x + vx} & py :{transform.position.y + vy}");

        Vector3 posi = new Vector3(transform.position.x + vx, transform.position.y + vy, transform.position.z);
        //inercia
        float inercia_in = 0f;
        if (Input.GetKey("w"))
        {
            inercia_in += velocitè;
        }else if (Input.GetKey("s"))
        {
            inercia_in -= velocitè;
        }
        // instanciação
        
        BulletMain.Create(posi, transform.rotation, inercia_in);

    }

    private void follow_mouse()
    {
        Vector3 posCam = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

        double ax, ay, bx, by;
        ax = posCam.x; ay = posCam.y;
        bx = transform.position.x; by = transform.position.y;
        float ang = (float) (Calc_AngRel(ax, ay, bx, by));
        transform.rotation = Quaternion.Euler(0f, 0f, ang);
    }

    private void follow_enemy()
    {
        GameObject enm = GameObject.Find("Enemy1");
        if (enm != null)
        {
            Calc_Ang(enm);

        }
    }

    private static double Calc_AngRel(double ax, double ay, double bx, double by)
    {
        double dx = ax - bx;
        double dy = ay - by;
        //double nx=0,ny =0;
        double soma = 0;
        if (dx >= 0)
        {
            soma += 180;
        }
        double ang = (Math.Atan(dy / dx) * 180 / Math.PI + soma+ 90) % 360;
        // Console.WriteLine($"{dx} {dy}");
        return ang;

    }

    private void moviment()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(0, (velocitè * Time.deltaTime), 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, (-velocitè * Time.deltaTime), 0);
        }
        /*
        if (Input.GetKey("a"))
        {
            transform.Translate((-velocitè * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate((velocitè * Time.deltaTime), 0, 0);
        }
        
        //spin
        if (Input.GetKey("e"))
        {
            transform.Rotate(0, 0, (-giro * Time.deltaTime));
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, 0, (giro * Time.deltaTime));
        }
        */

    }

    private void controller()
    {
        if (Input.GetMouseButton(0) && time_count_gun_on >= time_gun_on)
        {
            print("Disparo");
            // Invoke("Atirar", 0.25f);
            StartCoroutine(CAtirar());
            time_count_gun_on = 0;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (ètat == 0)
            {
                OnFollower -= follow_mouse;
                OnFollower += follow_enemy;
                ètat++;
            }
            else
            {
                OnFollower += follow_mouse;
                OnFollower -= follow_enemy;
                ètat--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            Geral.Velocitè += 1f;
        }else if (Input.GetKeyDown(KeyCode.G))
        {
            Geral.Velocitè -= 1f;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject NE = GameObject.Find(nome_enemy_reserved);
           
            if (NE != null)
            {
                string nomeE = NE.name;
                NE.name = nome_enemy_normal;
                NE.GetComponent<Enemy1>().execute_functions = true;

                //print($"add {NE.name} {NE.GetComponent<Enemy1>().execute_functions}<");

                Instantiate(NE, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);

                NE.GetComponent<Enemy1>().execute_functions = false;
                NE.name = nomeE;
            }
        }
    }

    private void comemorar()
    {
        print("Vitória !!!");
        already_comemorate = 1;
    }

    private int Calc_Ang(GameObject alvo)
    {
        // pre_set
        double vx, vy;
        float raio = gameObject.transform.localScale.y + 0.1f;
        //print($"raio : {raio}"); 

        float ang = (float)((transform.rotation.z * transform.rotation.w * 180 + 90) * Math.PI / 180);

        if (Math.Abs(transform.rotation.z) >= Math.Pow(2, 0.5D) / 2)
        {
            ang = (float)((360 - ang * 180 / Math.PI) * Math.PI / 180);
        }

        vx = (float)((raio) * Math.Cos(ang));
        vy = (float)((raio) * Math.Sin(ang));

        double px, py;
        px = transform.position.x + vx;
        py = transform.position.y + vy;
        // Tempo

        double m = Math.Abs(px - alvo.transform.position.x);
        double a = Math.Abs(py - alvo.transform.position.y);
        double v = Enemy1.VelL;
        double V = BulletMain.Velocidade;

        double x = v;
        double z = V;

        double epsilon = Math.Pow(z, 2) - Math.Pow(x, 2);
        double theta = -2 * m * x;
        double lambda = Math.Pow(a, 2) + Math.Pow(m, 2);

        //Console.WriteLine($"{epsilon} {theta} {lambda}");

        double delta = Math.Pow(theta, 2) + 4 * epsilon * lambda;

        if (delta < 0)
        {
            //Console.WriteLine($"Erro : delta = {delta}");
            return 1;
        }

        double t1 = (theta + Math.Pow(delta, 0.5D)) / (2 * epsilon);
        double t2 = (theta - Math.Pow(delta, 0.5D)) / (2 * epsilon);
        // Lei dos cossenos para achar alpha

        double t = (t1 > 0) ? t1 : t2;

        if (t < 0)
        {
            //Console.WriteLine($"Erro : t = {t}");
            return 1;
        }

       // Console.WriteLine("t" + t);

        double b = v * t;
        double h = V * t;
        double n = Math.Pow(lambda, 0.5D);

        //Console.WriteLine($"b : {b} h : {h} n : {n}");
        float ang_AN = (float)(Math.Acos(a / n) * 180 / Math.PI);

        float Alpha = (float)(Math.Acos((Math.Pow(b, 2) - (Math.Pow(n, 2) + Math.Pow(h, 2))) / (-2 * n * h)) * 180 / Math.PI);

        Alpha = 90 - (Alpha + ang_AN);

        // Console.WriteLine($"a : {Alpha} {ang_AN} -> {this.ecris[2]}");
        float valor_ajuste = -90f;
        
        float rot = (float)((Alpha + valor_ajuste) + (360 - transform.eulerAngles.z));
        transform.Rotate(0, 0, rot);
        

        // print($"Ângulo : {Alpha+valor_ajuste}");


        return 0;

    }

    private void Calc_AngDir(GameObject alvo)
    {
        double Vb = BulletMain.Velocidade;
        double Va = Enemy1.VelL;
        double Dx = Convert.ToDouble(alvo.transform.position.x - transform.position.x);

        float ang_disparo = (float)(Math.Atan((Va + Dx)/ Vb ) * 180 / Math.PI);

        print($"Dx : {Dx} ;;; Ang : {ang_disparo}");
    }

    static void sl(double time)
    {
        Thread.Sleep(Convert.ToInt32(time * 1000));
    }

    static void cl()
    {
        Console.Clear();
    }

    public void CalcVetorial(GameObject alvo)
    {
        //Subdefinição
        float ax, ay, bx, by;
        ax = alvo.transform.position.x;
        ay = alvo.transform.position.y;
        bx = transform.position.x;
        by = transform.position.y;
        //Definição
        double Va, Vb, th, d, e, c, alp, bet, angdif, gm, alp2, gm2, bet2;
        double v1;
        Point Pa = new Point(ax, ay);
        Point Pb = new Point(bx, by);
        //Dados
        //Va = 10;
        //Vb = 20;
        //th = 90;
        Va = Enemy1.VelL;
        Vb = BulletMain.Velocidade;
        th = (alvo.transform.rotation.z)*Math.PI/180 + 90;
        //Calculos
        d = Point.dist(Pa, Pb);
        c = Vb;
        e = Va;
        //Console.Write("h");
        angdif = Catan(Pa.x - Pb.x, Pa.y - Pb.y);
        //Console.Write("h");
        bet = MinArc(th, angdif);
        //Console.Write("h");
        alp = asen(Va / Vb * sen(bet));
        //Console.Write("h");
        gm = 90 - alp - angdif;



        bet2 = 180 - bet;
        alp2 = asen(Va / Vb * sen(bet2)) + gm + alp;

        //Correção
        gm2 = alp2;

        //Formatação
        string col = $"{gm + 180}";
        col = col.Replace(',', '.');
        string col2 = $"{gm2 + 180}";
        col2 = col2.Replace(',', '.');
        //Amostra
        //Console.WriteLine($"Ângulo Diferencial : {angdif}");
        //Console.WriteLine($"Beta 1: {bet}");
        //Console.WriteLine($"Beta 2: {bet2}");
        //Console.WriteLine($"P:Alpha 1: {alp}");
        //Console.WriteLine($"N:Alpha 2: {alp2}");
        //Console.WriteLine($"P:Gamma 1: {gm}");
        //Console.WriteLine($"N:Gamma 2: {gm2}");
        //Console.WriteLine($"P:Coloque 1: {col}°");
        //Console.WriteLine($"N:Coloque 2: {col2}°");
        // p = ((distânciaBC)/(distânciaCA))
        transform.rotation = Quaternion.Euler(0, 0, (float) (gm2- 90)); //  + (transform.rotation.z) * 180 / Math.PI
    }

    public static double MinArc(double ang1, double ang2)
    {
        double v, v1, v2;
        v1 = ang1 + ang2 + 90;
        v2 = 360 - v1;
        v = (v1 < v2) ? v1 : v2;
        return v;
    }

    public static double tan(double v)
    {
        return Math.Tan(v * Math.PI / 180);
    }

    public static double Catan(double a, double b)
    {
        if (b == 0) return 90;
        return atan(a / b);
    }

    public static double atan(double v)
    {
        return Math.Atan(v) * 180 / Math.PI;
    }

    public static double sen(double v)
    {
        return Math.Sin(v * Math.PI / 180);
    }

    public static double asen(double v)
    {
        return Math.Asin(v) * 180 / Math.PI;
    }

    public static double cos(double v)
    {
        return Math.Cos(v * Math.PI / 180);
    }

    public static double acos(double v)
    {
        return Math.Acos(v) * 180 / Math.PI;
    }


}

public class Point
{
    public double x, y;
    public Point(double px, double py)
    {
        x = px;
        y = py;
    }
    public static double dist(Point a, Point b)
    {
        double valor = (double)Math.Pow(Math.Pow((double)(a.x - b.x), 2) + Math.Pow((double)(a.y - b.y), 2), 0.5);
        return valor;
    }
}



