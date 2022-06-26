using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool EndingCondition = false;



    public GameObject endingScreenUI;

    public static EndingScreen instance;

    public HealthScript health;

    public Timer timing;

    public bool playerAlive = true;

    // Update is called once per frame
    void Update()
    {
        if (playerAlive == true)
        {
            DeathOfPlayer();
        }
        /*if (health.playerAlive == false)
        {
            GameObject.Find("Player").SendMessage("Finish");
            EndingCondition = true;
        }
        if (EndingCondition)
               Pause();*/
    }

    public void PlayAgain()
    {
        endingScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("TimeTrialIV");
    }
    public void DeathOfPlayer()
    {
        print("Death true");
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }
    void Pause()
    {
        endingScreenUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
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

}
