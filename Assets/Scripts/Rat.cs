using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField]
    private float health = 5f;

    private void OnCollisionEnter (Collision coll)
    {
        CatProjectile projectile = coll.gameObject.GetComponent<CatProjectile>();

        if (projectile != null)
        {
            Debug.Log("Rat hit by CatProjectile" + coll.collider.name);
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
