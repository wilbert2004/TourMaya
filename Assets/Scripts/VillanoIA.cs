using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class VillanoIA : MonoBehaviour
{
    public Transform objetivo; // el jugador o lo que persigue
    public float rango = 10f;  // distancia para empezar a perseguir
    public float velocidad = 3f;

    private NavMeshAgent agente;
    private Animator anim;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agente.speed = velocidad;
    }

    void Update()
    {
        if (objetivo == null) return;

        float distancia = Vector3.Distance(transform.position, objetivo.position);

        if (distancia <= rango)
        {
            agente.SetDestination(objetivo.position);
        }
        else
        {
            agente.ResetPath(); // se queda quieto si está lejos
        }

        // Actualiza animación según velocidad real
        float speedPercent = agente.velocity.magnitude / agente.speed;
        anim.SetFloat("Speed", speedPercent);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
