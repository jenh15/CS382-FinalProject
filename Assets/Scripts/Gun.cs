using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public GameObject catPrefab;
    //public Transform MuzzleFlash;
    public Transform Spawn;
    /*  public AudioSource Shot;
     public AudioSource noAmmo;
     public Transform muzzleSpawn;
     public Animation reload; */
    public float velocity = 50;
    static public Transform PROJECTILE_ANCHOR;

    //public int overallAmmo;

    void Start()
    {
        if (PROJECTILE_ANCHOR == null)
        {
            GameObject go = new GameObject("_ProjectleAnchor");
            PROJECTILE_ANCHOR = go.transform;
        }
    }
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        } */

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject go;
        go = Instantiate<GameObject>(catPrefab, PROJECTILE_ANCHOR);
        CatProjectile p = go.GetComponent<CatProjectile>();

        Vector3 vel = Vector3.right * velocity;
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;
        p.transform.position = aimPos;
        p.vel = vel;
    }
}
