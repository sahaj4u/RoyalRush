 using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed= 200f;
    const string playerString = "Player";

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

     void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    protected abstract void OnPickup();

}
