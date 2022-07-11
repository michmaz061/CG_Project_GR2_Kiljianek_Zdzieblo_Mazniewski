using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple script used to manage pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public static PauseMenu instance2;

    public GameObject pauseMenuUI;

    public GameObject endingScreenUI;

    /// <summary>
    /// Checks whether player wants to pause game.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Method used to resume the game.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// Method used to pause the game.
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// Method used to load menu.
    /// </summary>
    public void LoadMenu()
    {
        Debug.Log("Loading menu... ");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Method used to quit the game.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game... ");
        Application.Quit();
    }

}
