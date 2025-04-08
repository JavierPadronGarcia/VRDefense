using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        Vector3 targetPosition = player.position;
        agent.SetDestination(targetPosition);
    }
}
