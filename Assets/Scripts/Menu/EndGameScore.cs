using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour {
	
    //private variables
    private int EndScoreIndex;
    private float EndScore;

	// Update is called once per frame
	void Update () {
        //searches for the GameObject "EndingScore" and creates a reference through the ScoreText GameObject
        GameObject ScoreText = GameObject.Find("EndingScore");
        //sets EndScoreIndex equal to the "HighScore Index" from PlayerPrefs - 1 to get the most recent score
        EndScoreIndex = PlayerPrefs.GetInt("HighScore Index") - 1;
        //sets EndScore equal to the "High Score" from PlayerPrefs 
        EndScore = PlayerPrefs.GetFloat("High Score" + EndScoreIndex);
        //outputs the score to the text component of the EndingScore GameObject through the created reference ScoreText
        ScoreText.GetComponent<Text>().text = "Score: " + (int)(EndScore * 100);
    }
}
