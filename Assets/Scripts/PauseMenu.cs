using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gameIsPaused = false;

    private void Update()
    {
        if (PlayerMovement.isGameOver)
            return;
            
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Restart(int sceneID)
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(sceneID);
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
