using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {

        Rigidbody2D projectileRigidbody = this.GetComponent<Rigidbody2D>();

        // Aplicar velocidad al proyectil en la dirección de la rotación de la nave
        projectileRigidbody.velocity = transform.up * speed;

        // Puedes destruir el proyectil cuando está fuera de la pantalla, fuera de la escena, etc.
        if (!IsObjectVisible())
        {
            Destroy(gameObject);
        }
    }

    // Método llamado cuando el proyectil colisiona con otro collider
    void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar si la colisión es con un asteroide
        if (other.gameObject.CompareTag("Asteroid"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage); // Enviar la señal TakeDamage al asteroide
                Destroy(gameObject); // Destruir el proyectil después de causar daño
            }
        }
    }

    // Método para verificar si el proyectil está dentro de la vista
    bool IsObjectVisible()
    {
        return GetComponent<Renderer>().isVisible;
    }
}
