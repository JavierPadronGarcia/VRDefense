using UnityEngine;
using UnityEngine.AI;

public class SpaceshipMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position;
        agent.SetDestination(targetPosition);
    }
}
