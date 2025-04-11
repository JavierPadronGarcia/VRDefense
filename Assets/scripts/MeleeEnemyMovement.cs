using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private bool isAttacking = false;
    private float lastAttackTime = -Mathf.Infinity;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = Camera.main.transform;
        agent.updateRotation = false;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack();
            }
        }
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        lastAttackTime = Time.time;
        animator.SetTrigger("Attack");
    }
}
