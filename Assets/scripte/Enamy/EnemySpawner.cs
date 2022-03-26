using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class EnemySpawner: MonoBehaviour
{
    [SerializeField] spawnable[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float _timeBetweenRespoawnRate =10;
    [SerializeField] float initialSpawnDelay;
    [SerializeField] int totalNumberToSpawn;
    [SerializeField] int NumberToSpawnEachTime = 1;
    [SerializeField] int index;
    float spawnTimer;
    int totalNumberSpawned;

    private void OnEnable()
    {
        spawnTimer = _timeBetweenRespoawnRate - initialSpawnDelay;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (shouldSpawn())
        {
            spawn();
        if(index == totalNumberToSpawn)
        {
            Destroy(gameObject);
        }
        }
    }

    private void spawn()
    {
        spawnTimer = 0;
        var availableSpawnPoints = spawnPoints.ToList();

        for (int i = 0; i < NumberToSpawnEachTime; i++)
        {
            if (totalNumberSpawned >0 && totalNumberSpawned >= totalNumberToSpawn)
            {
                break;
            }
            spawnable prefab = chooseRandomEnemyPrefab();
            if (prefab != null)
            {
                Transform spawnPoint = chooseRandomSpawnPoint(availableSpawnPoints);

                if (availableSpawnPoints.Contains(spawnPoint))
                {
                    availableSpawnPoints.Remove(spawnPoint);

                }
                var enemy = prefab.Get<spawnable>(spawnPoint.position,spawnPoint.rotation);

                totalNumberSpawned++;
                index++;
            }

           
        }

    }

    private Transform chooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0)
        {
            return transform;
        }
        if (availableSpawnPoints.Count == 1)
        {
            return availableSpawnPoints[0];
        }
        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
        return availableSpawnPoints[index];
    }
        private spawnable chooseRandomEnemyPrefab()
    {
         if (enemyPrefabs.Length == 0)
        {
            return null;
        }
        if (enemyPrefabs.Length == 1)
        {
            return enemyPrefabs[0];
        }
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }

   

    private bool shouldSpawn()
    {
       if (totalNumberToSpawn > 0 && totalNumberSpawned >= totalNumberToSpawn)
        {
            return false;
        }
        return spawnTimer >= _timeBetweenRespoawnRate;
    }
}
