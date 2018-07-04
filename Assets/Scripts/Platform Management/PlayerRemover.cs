using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRemover : MonoBehaviour
{
    //private variable
    private int HighScoreIndex;

    //function called when object attatched to script hits another object
    void OnTriggerEnter2D(Collider2D PlayerRemove)
    {
        //checks object hit for the tag "Player"
        if (PlayerRemove.tag == "Player")
        {
            //searches for the GameObject "Canvas" and creates a reference through the CanvasScript GameObject
            GameObject CanvasScript = GameObject.Find("Canvas");
            //Sets HighScore as a reference to the PlayerHud script
            PlayerHud HighScore = CanvasScript.GetComponent<PlayerHud>();

            //sets HighScoreIndex equal to the "HighScore Index" variable in PlayerPrefs
            HighScoreIndex = PlayerPrefs.GetInt("HighScore Index");
            //sets the "High Score" + HighScoreIndex variable in PlayerPrefs equal to the most recent score
            PlayerPrefs.SetFloat("High Score" + HighScoreIndex, HighScore.Score);
            //increments the HighScoreIndex by 1
            HighScoreIndex++;
            //sets the "HighScoreIndex" in PlayerPrefs equal to the HighScoreIndex
            PlayerPrefs.SetInt("HighScore Index", HighScoreIndex);
            //loads the scene "EndGame"
            SceneManager.LoadScene("EndGame");
        }
    }
}
