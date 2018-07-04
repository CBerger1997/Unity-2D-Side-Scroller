using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    //private variables
    private float highScore = 0f;
    private int HighScoreIndex = 0;
    private string ScoreText;

    // Use this for initialization
    void Start ()
    {
        //sets HighScoreIndex equal to the "HighScore Index" from PlayerPrefs
        HighScoreIndex = PlayerPrefs.GetInt("HighScore Index");
        //calls the function HighScoreSort()
        HighScoreSort();
        //checks if the HighScoreIndex is > 12, setting it to 12 if so, limiting the amount of highscores displayed
        if (HighScoreIndex > 12)
        {
            HighScoreIndex = 12;
        }

        //creates local int
        int i = 0;

        //Stores the Highscore title into the ScoreText variable
        ScoreText = "---------------------------\n";
        ScoreText += "HighScores\n";
        ScoreText += "---------------------------\n";

        //do loop to create the Text within the ScoreText variable
        do
        {
            highScore = PlayerPrefs.GetFloat("High Score" + i);

            ScoreText += (i + 1) + ") Score: " + (int)(highScore * 100);
            ScoreText += "\n";
            i++;
        } while (i < HighScoreIndex);

        //searches for the GameObject "HighScoreTxt" and creates a reference through the ScoreTxt GameObject
        GameObject ScoreTxt = GameObject.Find("HighScoreTxt");
        //outputs the Highscores to the text component of the HighScoreTxt GameObject through the created reference ScoreTxt
        ScoreTxt.GetComponent<Text>().text = ScoreText;
    }
	
    //function used to sort the highscores into order of highest value to lowest value
    void HighScoreSort()
    {
        //local floats used to sort 2 adjacent highscores by value
        float highscore1;
        float highscore2;

        //for statement used to loop until the value of "HighScore Index" is reached
        for (int a = 0; (a <= PlayerPrefs.GetInt("HighScore Index")); a++)
        {
            //for statement used to loop whilst the value of b is less than the value of "HighScore Index" - 1
            for (int b = 0; b < (PlayerPrefs.GetInt("HighScore Index") - 1); b++)
            {
                //sets highscore1 equal to the value of "High Score" in the PlayerPrefs + theIndex
                highscore1 = PlayerPrefs.GetFloat("High Score" + b);
                //sets highscore2 equal to the value of "High Score" in the PlayerPrefs + theIndex + 1 
                highscore2 = PlayerPrefs.GetFloat("High Score" + (b + 1));
                //checks whether the second score is higher than the first
                if(highscore2 > highscore1)
                {
                    //changes the first and second highscore around
                    PlayerPrefs.SetFloat("High Score" + b, highscore2);
                    PlayerPrefs.SetFloat("High Score" + (b + 1), highscore1);
                }
            }
        }
    }
}