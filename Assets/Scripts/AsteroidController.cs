using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour, IDamageable
{
    public int size;
    public int score;
    public int health;
    public float speed;

    private EventManager eventManager;
    private Vector3 directionToPlayer;

    private void Start()
    {
        eventManager = GameManager.Instance.GetComponent<EventManager>();
        // Mover hacia el jugador
        directionToPlayer = (PlayerController.Instance.transform.position - transform.position).normalized;
    }

    void Update()
    {
       
        transform.Translate(directionToPlayer * speed * Time.deltaTime);
    }

    public void Initialize(float asteroidSpeed, float asteroidSize)
    {
        speed = asteroidSpeed;

        // Escalar el asteroide según el tamaño
        transform.localScale = new Vector3(asteroidSize, asteroidSize, asteroidSize);
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            // Actualizar puntaje y sonido de destrucción
            ScoreManager.UpdateScore(score);

            // Notificar a los suscriptores que un asteroide fue destruido
            eventManager.TriggerEvent("AsteroidDestroyed");

        }
    }
}
