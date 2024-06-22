using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // El jugador
    public float transitionSpeed = 2.0f; // Velocidad de la transición
    public float closeUpSize = 5.0f; // Tamaño de la cámara al acercarse
    private bool transitioning = true;

    private Vector3 mapViewPosition;
    private float mapViewSize;

    void Start()
    {
        // Configurar la cámara para mostrar el mapa completo
        mapViewPosition = new Vector3(0,-20, 0); // Ajusta esto según tu mapa
        mapViewSize = 50f; // Ajusta esto según tu mapa

        transform.position = mapViewPosition;
        Camera.main.orthographicSize = mapViewSize;
        StartCoroutine(WaitAndStartTransition());
    }

    void Update()
    {
        if (transitioning)
        {
            // Transición de la cámara al jugador
            transform.position = Vector3.Lerp(transform.position, player.position + new Vector3(0, 0, -10), Time.deltaTime * transitionSpeed);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, closeUpSize, Time.deltaTime * transitionSpeed);

            // Comprueba si la cámara ha terminado de acercarse
            if (Vector3.Distance(transform.position, player.position + new Vector3(0, 10, -10)) < 0.1f && Mathf.Abs(Camera.main.orthographicSize - closeUpSize) < 0.1f)
            {
                transitioning = false;
            }
        }
        else
        {
            // Seguir al jugador
            transform.position = player.position + new Vector3(0, 10, -10);
        }
    }
    IEnumerator WaitAndStartTransition()
    {
        // Esperar 60 segundos
        yield return new WaitForSeconds(60);

        // Iniciar la transición
        transitioning = true;
    }
}
