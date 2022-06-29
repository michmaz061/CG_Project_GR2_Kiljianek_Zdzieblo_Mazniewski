using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
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

    public void Finish()
    {
        finished = true;
        timerTextl.color = Color.yellow;
    }
}
