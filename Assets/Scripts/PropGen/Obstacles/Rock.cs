using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource boulderSmashSFX;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 0f;

    CinemachineImpulseSource cinemachineImpulseSource;

    float collisionTimer = 0f;

     void Update()
    {
        collisionTimer += Time.deltaTime;
    }
    void Awake()
    {
         cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }
     void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) { return; }
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

     void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance;
        shakeIntensity = Mathf.Min(shakeIntensity * shakeModifier, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
             ContactPoint contactPoint = other.contacts[0];
            collisionParticleSystem.transform.position = contactPoint.point;
            collisionParticleSystem.Play();
            boulderSmashSFX.Play();
        }
    }
