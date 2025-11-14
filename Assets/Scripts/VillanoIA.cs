using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class VillanoIA : MonoBehaviour
{
    public Transform objetivo;       // jugador
    public float rango = 10f;        // distancia para perseguir
    public float rangoAtaque = 2f;   // distancia para atacar
    public float velocidad = 3f;
    public float daño = 10f;
    public float tiempoEntreAtaques = 1.5f;

    private NavMeshAgent agente;
    private Animator anim;
    private float tiempoAtaque;

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

        // Si está lejos → caminar hacia el jugador
        if (distancia <= rango && distancia > rangoAtaque)
        {
            agente.isStopped = false;
            agente.SetDestination(objetivo.position);
        }
        // Si está dentro del rango de ataque → golpear
        else if (distancia <= rangoAtaque)
        {
            agente.isStopped = true;
            Atacar();
        }
        else
        {
            agente.ResetPath();
        }

        // Animación de caminar
        float speedPercent = agente.velocity.magnitude / agente.speed;
        anim.SetFloat("Speed", speedPercent);
    }

    void Atacar()
    {
        if (tiempoAtaque <= 0)
        {
            anim.SetTrigger("Attack"); // ejecuta anim
            objetivo.GetComponent<JugadorVida>()?.TomarDaño(daño);
            tiempoAtaque = tiempoEntreAtaques;
        }

        tiempoAtaque -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;     // rango de persecución
        Gizmos.DrawWireSphere(transform.position, rango);

        Gizmos.color = Color.yellow;  // rango de ataque
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}
