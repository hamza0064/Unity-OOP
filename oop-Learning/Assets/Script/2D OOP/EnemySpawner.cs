using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public int spawnCount = 5;
    public float spawnRadius = 10f;

    private enemyFactory factory;

    void Start()
    {
        // Factory initialize karo
        factory = new enemyFactory(enemyPrefab, player);
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomLocation = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));

            Vector3 spawnPos = transform.position + randomLocation;

            factory.CreateEnemy(spawnPos);
        }
    }
}
