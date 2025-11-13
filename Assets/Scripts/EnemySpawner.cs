using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Spawn enemy at the spawner's position, with default rotation
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
