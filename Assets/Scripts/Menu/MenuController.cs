using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Small behaviour to handle menu button callbacks.
 */
public class MenuController : MonoBehaviour
{
  /*
   * When the start button is pressed, load the Game scene.
   */
  public void OnStartClicked()
  {
        SceneManager.LoadScene("Game");
  }

  /*
   * When the back button is clicked, load the Menu scene.
   */
  public void OnBackClicked()
  {
        SceneManager.LoadScene("Menu");
  }
    /*
   * When the HowToPlay button is clicked, load the HowToPlay scene.
   */
    public void OnHowToPlayClicked()
  {
        SceneManager.LoadScene("HowToPlay");
  }
    /*
   * When the HighScores button is clicked, load the HighScores scene.
   */
    public void OnHighScoresClicked()
  {
        SceneManager.LoadScene("HighScores");
  }
    /*
   * When the HighScores button is clicked, resets the highscores entirely.
   */
    public void OnHighScoreRestClicked()
  {
        PlayerPrefs.SetInt("HighScore Index", 0);
        PlayerPrefs.SetFloat("High Score0", 0);
  }
}
