using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Camera : Geral
{
    // Start is called before the first frame update
    Vector3 pos_camera;
    //public GameObject pla;
    private float min_zoom = 0.5f, max_zoom = 30f;
    private float variation_zoom = 0.1f;
    //private float time_variation_zoom = 0.01f;

    //IEnumerator Czoom()
    //{

    //    yield return new WaitForSeconds(time_variation_zoom);
    //    Zoom();
    //    print("Exxec");
    //}

    public UnityEngine.Camera cam;
    void Start()
    {
        pos_camera = transform.position;
        cam = UnityEngine.Camera.main;
        cam.orthographicSize = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        pos_camera = transform.position;
        pla = GameObject.Find(nome_player);
        //print(pla);
        if (pla != null)
        {
            transform.position = pla.transform.position;
            transform.position = new Vector3(pla.transform.position.x, pla.transform.position.y, -10);
        }
            
        //print($"P : {pos_camera} + {pla.transform.position}");

        if (cam != null)
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                
                //StartCoroutine(Czoom());
                Zoom();
            }
        }
        else
        {
            throw new System.Exception("Camera não foi indexada como instância");
        }

    }

    private void Zoom()
    {

        cam.orthographicSize += -Input.mouseScrollDelta.y * variation_zoom;
        if (cam.orthographicSize < min_zoom)
            cam.orthographicSize = min_zoom;
        else if (cam.orthographicSize > max_zoom)
            cam.orthographicSize = max_zoom;

        Thread.Sleep(1);
    }



}
