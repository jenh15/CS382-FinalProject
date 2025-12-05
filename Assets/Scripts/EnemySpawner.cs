using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    
    public float spawnInterval = 2f;
    public Vector3 spawnRange;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int ndx = Random.Range(0, enemyPrefab.Length);
        //GameObject go = Instantiate<GameObject>(enemyPrefab[ndx]);

        spawnRange = new Vector3 (13, -10, Random.Range(-4, 4));

        // Spawn enemy at the spawner's position, with default rotation
        Instantiate(enemyPrefab[ndx], spawnRange, Quaternion.identity);
    }
}

