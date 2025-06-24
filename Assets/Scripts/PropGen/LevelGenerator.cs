using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LevelGenerator : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject CheckpointChunk;

    [Header("LevelSettings")]
    [Tooltip("Do not change chunk length value unless prefab is changed too")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] int startingChunksAmount = 10;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] int CheckpointFrequency;

    [Header("ClampSettings")]
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravity = -22f;
    [SerializeField] float maxGravity = -2f;
    [SerializeField] float minFOV = 0f;
    [SerializeField] float maxFOV = 120f;

    float CameraFOV = 60f;
    int ChunksSpawned = 0;




    List<GameObject> chunks = new List<GameObject>();

     void Start()
    {
        SpawnStartingChunks();
    }

     void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    { 
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed,maxMoveSpeed);
        moveSpeed += speedAmount;
        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravity, maxGravity);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
             cameraController.ChangeCameraFOV(speedAmount);

        }
            
        

     }
    
    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }
     void SpawnChunk()
    {
        ChunksSpawned ++;
        float spawnPositionZ = CalculateSpawnPostitionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        
        GameObject chunkToSpawn = chunkPrefabs[Random.Range(0,chunkPrefabs.Length)];
        if(ChunksSpawned % CheckpointFrequency == 0) { chunkToSpawn = CheckpointChunk; }
        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
    }
    

    float CalculateSpawnPostitionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = 0;
        }
        else
        {
            spawnPositionZ = chunks [chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();

            }     
        }

    }
}
