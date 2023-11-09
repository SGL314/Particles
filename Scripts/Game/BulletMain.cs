using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletMain : MonoBehaviour
{
    private static float velocidade = 10f;
    
    static public float Velocidade
    {
        get { return velocidade; }
    }
    private float angulo;

    public static void Create(Vector3 vect_pos, Quaternion rot, float inercia)
    {
        GameObject bullet = GameObject.Find("BulletB");
        bullet.GetComponent<Bullet>().inercia = inercia;
        if (bullet != null)
        {
            Instantiate(bullet, new Vector3(vect_pos.x,vect_pos.y,vect_pos.z+1) , rot).name = "BulletC";
            //GameObject nb = new GameObject();
            //Bullet nbc = nb.AddComponent<Bullet>();
            //nbc.name = "BulletC";
            //nbc.transform.position = new Vector3(vect_pos.x, vect_pos.y, vect_pos.z + 1);
            //nbc.transform.rotation = rot ;
            //print($"vel_tot : {velocidade + inercia}");


            bullet.name = "BulletB";
            bullet.GetComponent<Bullet>().inercia = 0f;
        }
    }

    private void Start()
    {
        // GameObject objt = new GameObject("BulletB");
    }

    void Update()
    {

        

    }

    private void moviment(GameObject obj)
    {
        obj.transform.Translate(0, (velocidade * Time.deltaTime), 0);
    }



}
