using UnityEngine;

public class Zombie : MonoBehaviour
{
    GameObject personaje;
    Rigidbody rb;

    public float velocidad = 3f;

    void Start()
    {
        personaje = GameObject.Find("Ch15_nonPBR"); // Nombre exacto del objeto jugador
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (personaje != null)
        {
            // Mira hacia el personaje (sin rotar en el eje Y si quieres)
            Vector3 direccion = (personaje.transform.position - transform.position).normalized;
            direccion.y = 0; // para que no se incline hacia arriba o abajo
            transform.LookAt(personaje.transform.position);

            // Movimiento hacia adelante
            rb.linearVelocity = direccion * velocidad;
        }
    }
}
