using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlUI : MonoBehaviour
{
    public TMP_Text puntosText;
    public TMP_Text vidasText;
    public TMP_Text tiempoText;
    public int vidas = 0;
    public float tiempo = 0;
    public int puntos= 0;
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            vidas = GameManager.Instance.lives;
            puntos = GameManager.Instance.points;
        }
        else
        {
            vidas = 3;
            puntos = 0;
        }
        tiempo += Time.deltaTime;
        vidasText.text = "Vidas: " + vidas;
        puntosText.text = "Puntos: " + puntos;
        tiempoText.text = "Tiempo: " + tiempo;

    }
}

