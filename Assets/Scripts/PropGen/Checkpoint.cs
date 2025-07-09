using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
     GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    [SerializeField] float TimeToAdd = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.2f;
    const string PlayerTag = "Player";

     void Start()
    {
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PlayerTag)
        {
            gameManager = FindFirstObjectByType<GameManager>();
            gameManager.AddTime(TimeToAdd);
            obstacleSpawner.DecreaseSpawntime(-obstacleDecreaseTimeAmount);
        }
    }
}
