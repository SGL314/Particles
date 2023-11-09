using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{


    private GameObject Player;
    public GameObject enemyObject;
    public float velocidadeEnemy;
    public string nome;

    public EnemyMain(string Nome)
    {
        nome = Nome;
        
    }

    public void log()
    {

    }

    public void followPlayer()
    {
        log();
        

    }

    static void future()
    {
        //enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, Player.transform.position, velocidadeEnemy * Time.deltaTime);
        //print(enemyObject.transform.position);
    }


}

