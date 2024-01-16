using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Fields & Properties
    [SerializeField] private Text ScoreText;
    [SerializeField] private Sprite[] LivesSprites;
    [SerializeField] private Image LivesImage;
    [SerializeField] private Text GameOverText;
    [SerializeField] private Text RestartText;
    [SerializeField] private Text ReturnToMainMenuText;
    private GameManager GameManager;
    #endregion

    #region Methods
    private void Start()
    {
        ScoreText.text = "Score: 0";
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {

    }

    public void UpdateScore(int score)
    {
        ScoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int lives)
    {
        LivesImage.sprite = LivesSprites[lives];

        if (lives <= 0)
        {
            if (GameManager != null)
            {
                GameManager.TheGameIsOver();
            }

            GameOverText.gameObject.SetActive(true);
            RestartText.gameObject.SetActive(true);
            ReturnToMainMenuText.gameObject.SetActive(true);
            StartCoroutine(GameOverTextBlink());
        }
    }

    IEnumerator GameOverTextBlink()
    {
        while (true)
        {
            GameOverText.text = "-- GAME OVER --";
            yield return new WaitForSeconds(0.5f);
            GameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion
}
