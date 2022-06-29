using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public void PlayAgain()
    {
        endingScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("TimeTrialV");
    }
    public void DeathOfPlayer()
    {
        print("Death true");
        Invoke("InvokeScreen",5);
        //GameIsPaused = true;
    }

    public void TimeOut()
    {
        print("Death true");
        InvokeScreen();
        //GameIsPaused = true;
    }
    void Pause()
    {
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }

    void InvokeScreen()
    {
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu... ");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game... ");
        Application.Quit();
    }

    public void AddToScore(Text score)
    {
        scoreText = score;
        scoreText.text = score.ToString() + " POINTS";
    }

    public void AddToHighscore(Text highscore)
    {
        highscoreText = highscore;
        highscoreText.text = "HGHSCORE: " + highscore.ToString();
    }

}
