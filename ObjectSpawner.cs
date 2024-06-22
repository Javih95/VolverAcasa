using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array de prefabs de objetos a generar
    public List<Transform> spawnPoints; // Lista de puntos de generación en el mapa

    void Start()
    {
        GenerateRandomObjects();
    }

    void GenerateRandomObjects()
    {
        // Asegurarse de que haya al menos 3 puntos de generación
        if (spawnPoints.Count < 3)
        {
            Debug.LogError("Debe haber al menos 3 puntos de generación en la lista.");
            return;
        }

        // Seleccionar aleatoriamente 3 puntos de generación sin repetir
        List<Transform> selectedPoints = new List<Transform>();
        while (selectedPoints.Count < 3)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform selectedPoint = spawnPoints[randomIndex];

            if (!selectedPoints.Contains(selectedPoint))
            {
                selectedPoints.Add(selectedPoint);
            }
        }

        // Instanciar objetos en los puntos seleccionados
        foreach (Transform point in selectedPoints)
        {
            // Seleccionar aleatoriamente un prefab de objeto
            int randomPrefabIndex = Random.Range(0, objectPrefabs.Length);
            GameObject prefab = objectPrefabs[randomPrefabIndex];

            // Instanciar el objeto en la posición del punto seleccionado
            Instantiate(prefab, point.position, point.rotation);
        }
    }
}
