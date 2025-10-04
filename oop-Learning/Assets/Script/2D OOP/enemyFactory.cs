using UnityEngine;

public class enemyFactory
{

    private GameObject enemyprefabs;
    private Transform player;
    

    public enemyFactory(GameObject enemyprefabs, Transform player)
    {
        this.enemyprefabs = enemyprefabs;
        this.player = player;
    }

    public GameObject CreateEnemy(Vector3 spawnPos)
    {
        GameObject enemy = GameObject.Instantiate(enemyprefabs, spawnPos, Quaternion.identity);
        enemy enemyScript = enemyprefabs.GetComponent<enemy>();
        enemyScript.target = player;
        return enemy;
    }
}
