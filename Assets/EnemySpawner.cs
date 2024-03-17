using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public Transform player;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public float spawnRadius = 5f;
    public float spawnTimer;
    public List<int> spawnEnemyCount = new List<int>();

    public int currentWave = 0;
    private float spawnTime;
    private int enemiesSpawned = 0;
    private int waveEnemiesSpawned;
    public UnityEvent OnAnotherWaveStart;
    public GameObject portal;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }


    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        if (spawnTime < 0)
        {
            SpawnEnemy();
        }
    }

    

    private void SpawnEnemy()
    {
        if (currentWave >= 3)
        {
            Debug.Log("Waves finished \n" +
                "Boss Appear");

            Vector3 portalSpawnPosition = player.position + player.forward * 3;
            Instantiate(portal, portalSpawnPosition, Quaternion.identity);

            this.enabled = false;
            return;
        }

        if (waveEnemiesSpawned < spawnEnemyCount[currentWave])
        {
            Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + player.position;
            spawnPosition.y = 0f;
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPosition, Quaternion.identity);
            enemiesSpawned++;
            waveEnemiesSpawned++;
            spawnTime = spawnTimer;
        }
        else
        {
            if (enemiesSpawned <= 0)
            {
                OnAnotherWaveStart?.Invoke();
                waveEnemiesSpawned = 0;
                currentWave++;
                spawnTime = spawnTimer;
            }
        }

    }

    public void EnemyDestroyed()
    {
        enemiesSpawned--;
    }
}
