using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static private Main S;

    public GameManager gameManager;
    public Player player;
    [SerializeField] public GameObject[] heartIcons;

    // Start is called before the first frame update
    void Start()
    {
        S.gameManager.gameOverUI.SetActive(false);
        S.gameManager.gameOver = false;

        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].SetActive(true);
        }
    }

    void Awake()
    {
        S = this;
    }
}
