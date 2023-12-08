using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
            Vector3 playerPosition = PlayerController.Instance.transform.position;

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = playerPosition + new Vector3(randomDirection.x, randomDirection.y, 0f ) * spawnRadius;

            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            AsteroidController asteroidController = asteroid.GetComponent<AsteroidController>();

            float asteroidSize = Random.Range(1f, 3f);
            float asteroidSpeed = Random.Range(2f, 5f);

            asteroidController.Initialize(asteroidSpeed, asteroidSize);

            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}