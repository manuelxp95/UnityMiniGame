using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencia al transform del jugador
    public float smoothTime = 0.3f;  // Controla la suavidad del seguimiento
    public Vector3 offset = new Vector3(0f, 1f, -10f);  // Offset de la posici�n de la c�mara

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n a la que la c�mara debe moverse
            Vector3 targetPosition = target.position + offset;

            // Aplica el suavizado usando SmoothDamp
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
