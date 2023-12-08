using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour, IDamageable
{
    public float size;
    public int score;
    public int health;
    public float speed;
    public int damage = 30;

    private EventManager eventManager;
    private Vector3 directionToPlayer;
    AudioManager audioManager;


    private void Start()
    {
        eventManager = GameManager.Instance.GetComponent<EventManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


        directionToPlayer = (PlayerController.Instance.transform.position - transform.position).normalized;
    }

    void Update()
    {

        transform.Translate(directionToPlayer * speed * Time.deltaTime);
    }

    public void Initialize(float asteroidSpeed, float asteroidSize)
    {
        speed = asteroidSpeed / (asteroidSize * (.85f));
        size = asteroidSize;


        transform.localScale = new Vector3(asteroidSize, asteroidSize, asteroidSize);
        health = Mathf.RoundToInt(asteroidSize) * 2;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(eventManager);
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.destroyAst);

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (size >= 2f)
            {
                eventManager.TriggerEvent("BigAsteroidDestroyed");
            }
            else
            {
                eventManager.TriggerEvent("AsteroidDestroyed");
            }

            Destroy(gameObject);

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);

                audioManager.PlaySFX(audioManager.destroyAst);

                Destroy(gameObject);
            }
        }
    }
}