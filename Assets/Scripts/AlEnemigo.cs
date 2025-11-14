using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform jugador;

    [Header("Movimiento")]
    public float velocidad = 3f;
    public float distanciaMinima = 1.5f;

    void Update()
    {
        if (jugador == null) return;

        // Calcula la distancia al jugador
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Si está fuera del rango mínimo, se mueve hacia el jugador
        if (distancia > distanciaMinima)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
}