
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject FencePrefab;
    [SerializeField] GameObject ApplePrefab;
    [SerializeField] GameObject CoinPrefab;

    [SerializeField] float appleSpawnChance = 0.05f;
    [SerializeField] float coinSpawnchance = 0.5f;
    [SerializeField] float coinSeperationLength = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    LevelGenerator LevelGenerator;
    ScoreManager ScoreManager;

    List<int> availableLanes = new List<int>{0, 1, 2};
     void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    public void Init(LevelGenerator levelGenerator,ScoreManager scoreManager)
    {
        this.LevelGenerator = levelGenerator;
        this.ScoreManager =  scoreManager;
    }

    void SpawnFences()
    {
        
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) { break; }
            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(FencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

     int SelectLane()
    {
        int RandomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[RandomLaneIndex];
        availableLanes.RemoveAt(RandomLaneIndex);
        return selectedLane;
    }

    void SpawnApple()
    {  
            if ((availableLanes.Count <= 0) || Random.value > appleSpawnChance) { return; }

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Apple newApple = Instantiate(ApplePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.GetComponent<Apple>().Init(LevelGenerator);
    }

    void SpawnCoins()
    {
        if ((availableLanes.Count <= 0) || Random.value > coinSpawnchance) { return; }

        int selectedLane = SelectLane();
        int maxCoinstoSpawn = 5;
        int coinsToSpawn = Random.Range(1, maxCoinstoSpawn-1);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPostionZ = topOfChunkZPos - (i * coinSeperationLength);
           Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPostionZ);
           Coin newCoin = Instantiate(CoinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(ScoreManager);
        
        }
    }
}
