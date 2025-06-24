using UnityEngine;

public class DestroyVolume : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
