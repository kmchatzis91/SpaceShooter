using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields & Properties
    private bool IsGameOver = false;
    #endregion

    #region Methods
    private void Start()
    {

    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R)) && (IsGameOver == true))
        {
            SceneManager.LoadScene("Game");
        }

        if ((Input.GetKeyDown(KeyCode.M)) && (IsGameOver == true))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TheGameIsOver()
    {
        IsGameOver = true;
    }
    #endregion
}
