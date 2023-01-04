using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public TextMeshProUGUI finalScoreText;

    private void Update()
    {
        if (PlayerMovement.isGameOver)
        {
            gameOverMenu.SetActive(true);
            finalScoreText.SetText("Final Score: " + PlayerMovement.score);
            Time.timeScale = 0f;
        }

        else
        {
            gameOverMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void Quit()
    {
       Application.Quit();
    }

    public void PlayAgain(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
