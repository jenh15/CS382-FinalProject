using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public Transform Spawn;
    public float velocity = 1;

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
        /* if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        } */

        //AimGun();

        if (Input.GetMouseButtonDown(0))
        {
            var position = Spawn.position;
            var rotation = Spawn.rotation;
            var projectile = Instantiate(projectilePrefab, position, rotation);

            projectile.Shoot(velocity, transform.right * -1);
        }
    }

    /* void AimGun()
    {
    
    } */
    
    
/*     void Shoot()
    {
        GameObject go;
        go = Instantiate<GameObject>(catPrefab);
        CatProjectile p = go.GetComponent<CatProjectile>();

        Vector3 vel = Vector3.right * velocity;
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Spawn.position);
        aimPos.x = 0;
        p.transform.position = aimPos;
        p.vel = vel;
        p.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (velocity, 0, 0));
    } */
}
