using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField]
    private float health = 5f;
    private AudioSource ratHitSound;
    private AudioSource ratDeathSound;
    public float moveSpeed = 3f;
    private Transform target;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        ratHitSound = audios[0];
        ratDeathSound = audios[1];

        // Find the player's camera (the target)
        target = Camera.main.transform;
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

    private void OnCollisionEnter (Collision coll)
    {
        if (!isAlive) return;   // Does not run the code if the rat is already dead

        CatProjectile projectile = coll.gameObject.GetComponent<CatProjectile>();

        if (projectile != null)
        {
            Debug.Log("Rat hit by CatProjectile" + coll.collider.name);
            health--;

            /* if (health > 0)
            {
                ratHitSound.Play();
            } */

            if (health <= 0)
            {
                isAlive = false;

                ratDeathSound.Play();
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);

                Destroy(gameObject, 3);
            }
        }
    }
}
