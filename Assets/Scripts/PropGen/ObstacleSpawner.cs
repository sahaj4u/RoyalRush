using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float[] ObstaclesSpawnchances;
    [SerializeField] float obstaclesSpawnTime = 1f;
    [SerializeField] float MinObstacleSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    public void DecreaseSpawntime(float amount)
    {
        obstaclesSpawnTime += amount;
        if (obstaclesSpawnTime < MinObstacleSpawnTime)
        {
            obstaclesSpawnTime = MinObstacleSpawnTime;
        }
    }
   
    void Start()
    {
        StartCoroutine(SpawnObstaclesRoutine());
    }

    IEnumerator SpawnObstaclesRoutine() {
        while (true)
        {
             GameObject obstaclePrefab = FindObstacleToSpawn();
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(obstaclesSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }

    }

     GameObject FindObstacleToSpawn()
    {
        int obstacleArrayID = 0;
        bool foundObstacleToSpawn = false;
        while (!foundObstacleToSpawn) 
        {
             obstacleArrayID = Random.Range(0,obstaclePrefabs.Length);
            if(Random.value < ObstaclesSpawnchances[obstacleArrayID])
            {
                foundObstacleToSpawn = true;
            }
        }
        return obstaclePrefabs[obstacleArrayID];
    }
}
