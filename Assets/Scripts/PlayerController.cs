using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, IShootable
{
    
    public Transform shotSpawn;
    public GameObject projectilePrefab;

    public float speed = 5f;
    public float rotationSpeed = 200f;
    public int health = 100;

    public static PlayerController Instance;
    private EventManager eventManager;
    private bool canMove = true;
    AudioManager audioManager;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        eventManager = GameManager.Instance.GetComponent<EventManager>();
        EventManager.Instance.Subscribe("RetryGame", ResetPlayer);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void Update()
    {
        if (canMove && !PauseMenu.isPaused)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float translation = verticalInput * speed * Time.deltaTime;
            float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;

            transform.Translate(0, translation, 0);
            transform.Rotate(0, 0, rotation);

            float currentRotation = transform.localEulerAngles.z;
            transform.localEulerAngles = new Vector3(0, 0, currentRotation);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void StopMovement()
    {
        canMove = false;
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, shotSpawn.position, transform.rotation);
        audioManager.PlaySFX(audioManager.shoot);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        canMove = false;
        
        eventManager.TriggerEvent("PlayerDie");

    }

    public void ResetPlayer()
    {
        health = 100;
        canMove = true;
    }

}
