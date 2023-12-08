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

        projectileRigidbody.velocity = transform.up * speed;

        if (!IsObjectVisible())
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage); 
                Destroy(gameObject); 
            }
        }
    }

    bool IsObjectVisible()
    {
        return GetComponent<Renderer>().isVisible;
    }
}
