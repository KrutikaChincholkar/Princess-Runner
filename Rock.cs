using Unity.Cinemachine; // Ensure you have the Cinemachine package installed
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float shakeModifer = 10f;
    [SerializeField] float collisionCooldown = 1f; // Cooldown time in seconds    
    CinemachineImpulseSource cinemachineImpulseSource;

    float collisionTimer = 1f;
    void Awake()
    {
       cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(collisionTimer < collisionCooldown)return;
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f; // Reset the timer after a collision

    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifer;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f); // Limit the intensity to a maximum of 1

        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        boulderSmashAudioSource.Play();


    }
}
