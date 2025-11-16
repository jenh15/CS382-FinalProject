using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static private Main S;

    public GameManager gameManager;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        S.gameManager.gameOverUI.SetActive(false);
        S.gameManager.gameOver = false;
    }

    void Awake()
    {
        S = this;
    }
}
