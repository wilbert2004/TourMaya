using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float lookSpeed = 5f;

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Coloca al enemigo sobre el NavMesh automáticamente
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRange)
        {
            // Ataque
            agent.isStopped = true;
            transform.LookAt(player);
            if (animator) animator.SetTrigger("Attack");
        }
        else if (distance <= chaseRange)
        {
            // Perseguir
            agent.isStopped = false;
            agent.SetDestination(player.position);
            if (animator) animator.SetBool("isRunning", true);
        }
        else
        {
            // Idle
            agent.isStopped = true;
            if (animator) animator.SetBool("isRunning", false);
        }
    }
}
