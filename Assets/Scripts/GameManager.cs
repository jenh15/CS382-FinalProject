using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private Player player;
    public GameObject gameOverUI;
    public bool gameOver = false;

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
