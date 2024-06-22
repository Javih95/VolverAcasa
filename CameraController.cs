using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // El jugador
    public float transitionSpeed = 2.0f; // Velocidad de la transici�n
    public float closeUpSize = 5.0f; // Tama�o de la c�mara al acercarse
    private bool transitioning = true;

    private Vector3 mapViewPosition;
    private float mapViewSize;

    void Start()
    {
        // Configurar la c�mara para mostrar el mapa completo
        mapViewPosition = new Vector3(0,-20, 0); // Ajusta esto seg�n tu mapa
        mapViewSize = 50f; // Ajusta esto seg�n tu mapa

        transform.position = mapViewPosition;
        Camera.main.orthographicSize = mapViewSize;
        StartCoroutine(WaitAndStartTransition());
    }

    void Update()
    {
        if (transitioning)
        {
            // Transici�n de la c�mara al jugador
            transform.position = Vector3.Lerp(transform.position, player.position + new Vector3(0, 0, -10), Time.deltaTime * transitionSpeed);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, closeUpSize, Time.deltaTime * transitionSpeed);

            // Comprueba si la c�mara ha terminado de acercarse
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

        // Iniciar la transici�n
        transitioning = true;
    }
}
