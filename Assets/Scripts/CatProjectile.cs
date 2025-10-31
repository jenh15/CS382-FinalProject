using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatProjectile : MonoBehaviour
{
    //private BoundsCheck bndCheck;
    private Renderer rend;
    [Header("Dynamic")]
    public Rigidbody rigid;

    void Awake()
    {
        //bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.transform.position.x >= 13)
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
