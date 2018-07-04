using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Behaviour to handle keyboard input and also store the player's
 * current health.
 */
public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rigidbody2d;
  public int health;
  private bool canJump;
  private bool canJump2;
  private int highscore;
  private int HighScoreIndex;

  private void Start()
  {
    health = 6;
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  /*
   * Remove one health unit from player and if health becomes 0, change
   * scene to the end game scene.
   */
  public void Damage()
  {
    health -= 1;

    if(health < 1)
    {
            //searches for the GameObject "EndingScore" and creates a reference through the ScoreText GameObject
            GameObject CanvasScript = GameObject.Find("Canvas");
            //Sets HighScore as a reference to the PlayerHud script
            PlayerHud HighScore  = CanvasScript.GetComponent<PlayerHud>();
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

  /*
   * Accessor for health variable, used by the HUD to display health.
   */
  public int GetHealth()
  {
    return health;
  }

  /*
   * Poll keyboard for when the up arrow is pressed. If the player can jump
   * (is on the ground) then add force to the cached Rigidbody2D component.
   * Finally unset the canJump flag so the player has to wait to land before
   * another jump can be triggered.
   */
  private void Update()
  {
      transform.Translate(new Vector2(5f * Time.deltaTime, 0f));
        //canJump2 variable used to allow the player to jump twice if they have already jumped once
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      if (canJump2 == true)
      {
        rigidbody2d.AddForce(new Vector2(0, 325) /** Time.deltaTime*/);
        canJump2 = false;
      }
      if(canJump == true)
      {
        rigidbody2d.AddForce(new Vector2(0, 325) /** Time.deltaTime*/);
        canJump2 = true;
        canJump = false;
      }
    }

  }
  /*
   * If the player has collided with the ground, set the canJump flag so that
   * the player can trigger another jump.
   */
  private void OnCollisionEnter2D(Collision2D other)
  {
        //resets both jump boolean variables
            canJump = true;
            canJump2 = false;
  }
}
