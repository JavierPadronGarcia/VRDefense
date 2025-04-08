using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadius = 30f;
    public float minDistanceFromPlayer = 15f;
    public int enemiesPerHorde = 5;
    public float hordeInterval = 10f;
    public LayerMask navMeshLayerMask;

    void Start()
    {
        player = Camera.main.transform;
        StartCoroutine(SpawnHordes());
    }

    IEnumerator SpawnHordes()
    {
        while (true)
        {
            SpawnEnemiesInHorde();
            yield return new WaitForSeconds(hordeInterval);
        }
    }

    void SpawnEnemiesInHorde()
    {
        for (int i = 0; i < enemiesPerHorde; i++)
        {
            Vector3 spawnPos;
            if (GetRandomPointOnNavMesh(out spawnPos))
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    bool GetRandomPointOnNavMesh(out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection += player.position;

            if (Vector3.Distance(randomDirection, player.position) < minDistanceFromPlayer)
                continue;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, 5f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
}
