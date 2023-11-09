using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Bullet : BulletMain
{
    public float time_flying = 0f;
    public float time_max_flying = 25f;
    private float vida = 10f;
    public float inercia = 0f;
    //time_max_flying *= 
    //public float dano = 3.333334333333333334f;
    private float dano = 10f;
    [SerializeField]
    private float self_damage = 2f;
    Rigidbody rb;
    //public bool 

    //public Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();

        if (this.name == "BulletC")
        {
            Destroy(gameObject,time_max_flying);
        }
    }

    void Update()
    {
        if (this.name == "BulletC")
        {
            transform.Translate(0, ((Velocidade + inercia)* Time.deltaTime), 0);

            time_flying += Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (time_flying > 0.05f)
        {
            //print("Collision on");
            Enemy1 enemy = collision.gameObject.GetComponent<Enemy1>();
            if (enemy != null)
            {
                if (enemy.execute_functions)
                {
                    enemy.vida -= dano;
                    //if (enemy.vida <= 0) {
                    //    Destroy(enemy);
                    //    Destroy(enemy.gameObject); 
                    //}
                }
            }
            vida -= self_damage;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //}
}

