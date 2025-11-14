using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatProjectile : MonoBehaviour
{
    private Renderer rend;

    [Header("Dynamic")]
    public Rigidbody rigid;
    float timeToDestroy = 5f;

    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);    // deletes the projectile if it is on screen for too long
    }

    void Awake()
    {
        //bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.transform.position.x >= 13)    // deletes the projectile if it goes past the trees
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(float velocity, Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);

        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;

        rigid.AddForce(direction * velocity, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter (Collision coll)
    {

        if (coll.gameObject.CompareTag("Rat"))
        {
            Debug.Log("Cat hit Rat");
            Destroy(gameObject);
        } else if (coll.gameObject.CompareTag("Ground"))   // If the cat hits the ground, it is destroyed
        {
            Destroy(gameObject);
        }
    }
    
    public Vector3 vel
    {
        get { return rigid.velocity; }
        set { rigid.velocity = value; }
    }
} 
