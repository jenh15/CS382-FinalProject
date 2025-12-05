using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public bool isAlive = true;
    public bool isPlaying = false;
    public float moveSpeed = 3f;
    [SerializeField]
    private float health = 5f;
    private AudioSource ratHitSound;
    private AudioSource ratDeathSound;
    private Transform target;
    [SerializeField] private SimpleFlash flashEffect;

    void Start()
    {
        // Get AudioSources
        AudioSource[] audios = GetComponents<AudioSource>();
        ratHitSound = audios[0];
        ratDeathSound = audios[1];

        // Find the player's camera (the target)
        target = Camera.main.transform;
        flashEffect = GetComponent<SimpleFlash>();
    }

    void Update()
    {
        if (isAlive == true) {
            if (target == null) return;

            // Get direction toward the player, but ignore vertical difference
            Vector3 direction = (target.position - transform.position).normalized;
            direction.y = 0f; // Prevent up/down movement
            direction.Normalize();

            // Rotate toward player
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direction);

            // Move forward in facing direction
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (this.transform.position.x <= 0)     // Rats are deleted if they go past the camera (change later)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        if (!isAlive) return;   // Does not run the code if the rat is already dead

        CatProjectile projectile = other.gameObject.GetComponent<CatProjectile>();

        if (projectile != null)
        {
            Debug.Log("Rat hit by CatProjectile" + other.name);
            health--;   // Deplete rat health if hit
            flashEffect.Flash();

            if (health > 0 && isPlaying == false)
            {
                isPlaying = true;   // Stops sound from repeating
                ratHitSound.Play(); // Play sound if rat is hit
            } 

            isPlaying = false;

            if (health <= 0)
            {
                isAlive = false;
                GetComponent<Rigidbody>().isKinematic = true;

                ratDeathSound.Play();   // Play rat death sound
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90); // Rat turns over

                Destroy(gameObject, 3); // Delay destruction so sound can play
            }
        }
    }
}
