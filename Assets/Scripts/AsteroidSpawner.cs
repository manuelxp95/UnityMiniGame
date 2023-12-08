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
            // Obtener la posición del jugador
            Vector3 playerPosition = PlayerController.Instance.transform.position;

            // Calcular una posición aleatoria alrededor del jugador
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = playerPosition + new Vector3(randomDirection.x, randomDirection.y, 0f ) * spawnRadius;

            // Instanciar el asteroide en la posición calculada
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // Configurar tamaño y velocidad del asteroide (ajusta estos valores según sea necesario)
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