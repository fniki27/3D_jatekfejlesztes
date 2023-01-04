using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject mainMenu;

    public void Easy()
    {
        PlayerMovement.increaseSpeed = 0.1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Medium()
    {
        PlayerMovement.increaseSpeed = 0.2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hard()
    {
        PlayerMovement.increaseSpeed = 0.3f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play()
    {
        difficultyMenu.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }

}