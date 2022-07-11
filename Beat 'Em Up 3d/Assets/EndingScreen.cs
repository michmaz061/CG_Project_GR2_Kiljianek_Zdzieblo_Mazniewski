using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// A script used to manage ending screen.
/// </summary>
public class EndingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool EndingCondition = false;



    public GameObject endingScreenUI;

    public static EndingScreen instance;

    public HealthScript health;

    public Timer timing;

    public bool playerAlive = true;

    public Text scoreText;
    public Text highscoreText;

    /// <summary>
    /// Checks whether player choose to play again and loads the scene from beggining.
    /// </summary>
    public void PlayAgain()
    {
        endingScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("TimeTrialV");
    }

    /// <summary>
    /// If player died this method is used and invokes screen after a few seconds.
    /// </summary>
    public void DeathOfPlayer()
    {
        Invoke("InvokeScreen",5);
    }

    /// <summary>
    /// If the time ends this method is used and invokes screen immediately.
    /// </summary>
    public void TimeOut()
    {
        InvokeScreen();
    }

    /// <summary>
    /// This method is used when player pauses the game.
    /// </summary>
    void Pause()
    {
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }

    /// <summary>
    /// It stops time and shows ending screen.
    /// </summary>
    void InvokeScreen()
    {
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Method used to load menu if player chooses to.
    /// </summary>
    public void LoadMenu()
    {
        Debug.Log("Loading menu... ");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Method used to quit game if player chooses to.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game... ");
        Application.Quit();
    }
}
