using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform target;

    void Start()
    {
        // Find the player's camera (the target)
        target = Camera.main.transform;
    }

    void Update()
    {
        if (target == null) return;

        // Get direction toward the player, but ignore vertical difference
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0f; // Prevent up/down movement
        direction.z = 0f; // prevent side to side

        // Rotate toward player
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

        // Move forward in facing direction
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}