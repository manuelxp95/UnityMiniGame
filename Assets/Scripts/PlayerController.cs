using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implementaci�n de la clase que implementa la interfaz
public class PlayerController : MonoBehaviour, IDamageable, IShootable
{
    
    public Transform shotSpawn;
    public GameObject projectilePrefab;

    public float speed = 5f;
    public float rotationSpeed = 200f;
    public int health = 100;

    public static PlayerController Instance;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el desplazamiento y la rotaci�n
        float translation = verticalInput * speed * Time.deltaTime;
        float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;

        // Mover y rotar la nave
        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, rotation);

        // Limitar la velocidad de rotaci�n
        float currentRotation = transform.localEulerAngles.z;
        transform.localEulerAngles = new Vector3(0, 0, currentRotation);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, shotSpawn.position, transform.rotation);
    }

    // M�todo de la interfaz implementado
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player took {damage} damage. Remaining health: {health}");

        // L�gica adicional para el manejo de la salud, por ejemplo, verificar si el jugador ha muerto.
        if (health <= 0)
        {
            Die();
        }
    }

    // M�todo adicional de la clase
    private void Die()
    {
        Debug.Log("Player has died.");
        // L�gica adicional para el manejo de la muerte del jugador.
    }


}
