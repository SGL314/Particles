using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    System.Random rd = new System.Random();

    float movAng, movLin;
    float minVarLin = 0.1f;
    float maxVarLin = 0.4f * 5f;
    float fragLin = 10f;
    public float temperatura = 0.1f;
    public float normalTemperatura = 25f;
    float coeTermChoqueLin = 0.1f;

    public Material material;
    public Renderer renderer;
    public Color32 normalColor;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        normalColor = renderer.material.color;
    }

    void Update()
    {
        movAng = rd.Next(0, 360001) / 1000;
        movLin = this.temperatura/ this.normalTemperatura * rd.Next(Convert.ToInt32(minVarLin * fragLin), Convert.ToInt32(maxVarLin * fragLin + 1f)) / fragLin;
        transform.Rotate(new Vector3(0, 0, movAng));
        transform.Translate(0, Time.deltaTime * movLin, 0);
        temperatura -= coeTermChoqueLin*Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // other.gameObject.GetComponent<LogicaParticula>().temperatura;
        float a = other.gameObject.GetComponent<Particula>().temperatura;
        float b = this.temperatura;
        other.gameObject.GetComponent<Particula>().temperatura = (a + b) / 2;
        this.temperatura = (a + b) / 2 + coeTermChoqueLin;
        other.gameObject.GetComponent<Particula>().temperatura = (a + b) / 2 + coeTermChoqueLin;
        // this.gameObject.renderer.Color = new Color(0,0,255);
        float colorRed = 255/100 * (this.temperatura - this.normalTemperatura);
        float colorGB = 0f;
        if (colorRed > 255)
        {
            
            colorGB = colorRed - 255;
            if (colorGB  > 255){
                colorGB = 255f;
            }
            colorRed = 255f;
        }
        //print(Convert.ToByte(colorRed));
        try {
            renderer.material.color = new Color32(Convert.ToByte(colorRed), Convert.ToByte(colorGB), Convert.ToByte(colorGB), 255);
        }
        catch{
            renderer.material.color = new Color32(0, 0, 0, 255);
        }
    }
}


