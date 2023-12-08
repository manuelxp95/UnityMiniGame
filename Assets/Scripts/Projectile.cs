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

        // Aplicar velocidad al proyectil en la direcci�n de la rotaci�n de la nave
        projectileRigidbody.velocity = transform.up * speed;

        // Puedes destruir el proyectil cuando est� fuera de la pantalla, fuera de la escena, etc.
        if (!IsObjectVisible())
        {
            Destroy(gameObject);
        }
    }

    // M�todo llamado cuando el proyectil colisiona con otro collider
    void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar si la colisi�n es con un asteroide
        if (other.gameObject.CompareTag("Asteroid"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage); // Enviar la se�al TakeDamage al asteroide
                Destroy(gameObject); // Destruir el proyectil despu�s de causar da�o
            }
        }
    }

    // M�todo para verificar si el proyectil est� dentro de la vista
    bool IsObjectVisible()
    {
        return GetComponent<Renderer>().isVisible;
    }
}
