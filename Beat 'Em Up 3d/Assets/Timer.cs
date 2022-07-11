using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script used to keep track on time and uploading it onto screen. 
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerTextl;
    private float startTime;
    private bool finished = false;
    public int timeMinute=0;
    public int timeSeconds=3;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    /// <summary>
    /// In update we check whether the game is finished to stop counting time. If not we change value and upload time onto screen. When the set time limit is hit, then the game ends automatically.
    /// </summary>
    void Update()
    {
        if (finished)
            return;

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerTextl.text = minutes + ":" + seconds;

        if (minutes == timeMinute.ToString() && seconds == timeSeconds.ToString()+",0")
        {
            FindObjectOfType<EndingScreen>().TimeOut();
        }
    }

    /// <summary>
    /// It indicates that the game is finished and changes timer text color.
    /// </summary>
    public void Finish()
    {
        finished = true;
        timerTextl.color = Color.yellow;
    }
}
