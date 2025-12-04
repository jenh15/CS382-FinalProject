using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth;
    [SerializeField] public float startingHealth = 10f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] public GameObject[] heartIcons;

    void Start()
    {
        playerHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter (Collision coll)
    {
        Rat rat = coll.gameObject.GetComponent<Rat>();

        if (rat != null)
        {
            playerHealth--;
            Destroy(rat.gameObject);
            Debug.Log("Player hit by Rat. Player Health: " + playerHealth);

            for (int i = 0; i < heartIcons.Length; i++)
            {
                heartIcons[i].SetActive(i < playerHealth);
            }
        }
    }
}
