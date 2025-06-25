using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
     GameManager gameManager;
    [SerializeField] float TimeToAdd = 5f;
    const string PlayerTag = "Player";

    private void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PlayerTag)
        {
            gameManager = FindFirstObjectByType<GameManager>();
            gameManager.AddTime(TimeToAdd);
        }
    }
}
