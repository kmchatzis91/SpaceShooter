using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Fields & Properties

    #endregion

    #region Methods
    private void Start()
    {

    }

    private void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    #endregion
}
