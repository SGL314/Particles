

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject[] preFabs = null;
    GameObject partM;
    string nome_part = "Particula";
    System.Random rd = new System.Random();

    private string nome_camera = "Camera";
    private float min_zoom = 0.5f, max_zoom = 100f;
    private float variation_zoom = 0.25f;
    public UnityEngine.Camera cam;

    IEnumerator Zoom()
    {
        

        cam.orthographicSize += -Input.mouseScrollDelta.y * variation_zoom;
        if (cam.orthographicSize < min_zoom)
            cam.orthographicSize = min_zoom;
        else if (cam.orthographicSize > max_zoom)
            cam.orthographicSize = max_zoom;
        yield return new WaitForSeconds(0.01f);
    }

    private void Awake()
    {
        cam = UnityEngine.Camera.main;
        cam.orthographicSize = 5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            partM = preFabs[0];
            if (partM != null)
            {
                float tempR = partM.GetComponent<Particula>().temperatura;
                partM.GetComponent<Particula>().temperatura += rd.Next(-1, 2);
                print($"TempRec : {partM.GetComponent<Particula>().temperatura}");

                Instantiate(partM, partM.transform.position, partM.transform.rotation);
                partM.GetComponent<Particula>().temperatura = tempR;
            }
        }

        controle();
    }
    private void controle()
    {
        // Camera
        float[] adjMousePos = new float[2] { 0, 0 };
        if (Input.GetMouseButton(0))
        {
            float px, py;
            Vector3 pos;
            pos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            px = pos.x;
            py = pos.y;
            adjMousePos[0] = px;
            adjMousePos[1] = py;
        }
        float rpx, rpy, rpz;
        rpx = transform.position.x + adjMousePos[0]/100;
        rpy = transform.position.y + adjMousePos[1]/100;
        rpz = transform.position.z;
        Vector3 rvet = new Vector3(rpx, rpy, rpz);
        transform.position = rvet;
        // Zoom
        if (Input.mouseScrollDelta.y != 0 )
        {
            StartCoroutine(Zoom());
        }



        
    }

}
