using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text scoreTextEnding;
    public Text highscoreTextEnding;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HGHSCORE: " + highscore.ToString();
        highscoreTextEnding.text = highscoreText.text;
        scoreTextEnding.text = scoreText.text;
        FindObjectOfType<EndingScreen>().DeathOfPlayer();
    }

    // Update is called once per frame
public void AddPoint()
    {
        score += 1;
        if (score == 1)
        {
            scoreText.text = score.ToString() + " POINT";
        }
        scoreText.text = score.ToString() + " POINTS";
        scoreTextEnding.text = scoreText.text;
        //FindObjectOfType<EndingScreen>().AddToScore(scoreText);
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreTextEnding.text = highscoreText.text;
            //FindObjectOfType<EndingScreen>().AddToHighscore(scoreText);
        }
    }
}
