using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public Transform Spawn;
    public float velocity = 1;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private CatProjectile projectilePrefab;

    //public int overallAmmo;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        AimGun();

        /* if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        } */

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            var position = Spawn.position;
            var rotation = Spawn.rotation;
            var projectile = Instantiate(projectilePrefab, position, rotation);
            Vector3 shootDir = ray.direction.normalized;

            projectile.Shoot(velocity, shootDir);
        }
    }

    void AimGun()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);    // Get mouse position

        Vector3 adjustedDirection = Quaternion.Euler(0, 90, 0) * ray.direction; // Adjust the direction because I made the game have funky axises

        transform.rotation = Quaternion.LookRotation(adjustedDirection, Vector3.up);    // Rotate the gun to look towards the mouse
    }
}