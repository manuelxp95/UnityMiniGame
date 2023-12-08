using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRadius = 10f;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            // Obtener la posici�n del jugador
            Vector3 playerPosition = PlayerController.Instance.transform.position;

            // Calcular una posici�n aleatoria alrededor del jugador
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = playerPosition + new Vector3(randomDirection.x, randomDirection.y, 0f ) * spawnRadius;

            // Instanciar el asteroide en la posici�n calculada
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // Configurar tama�o y velocidad del asteroide (ajusta estos valores seg�n sea necesario)
            float asteroidSize = Random.Range(1f, 3f);
            float asteroidSpeed = Random.Range(2f, 5f);

            asteroid.transform.localScale = new Vector3(asteroidSize, asteroidSize, asteroidSize);
            asteroid.GetComponent<AsteroidController>().speed = asteroidSpeed;

            // Calcular un nuevo tiempo de espera antes de instanciar el siguiente asteroide
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}