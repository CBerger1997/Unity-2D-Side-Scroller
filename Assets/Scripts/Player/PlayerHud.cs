using UnityEngine;
using UnityEngine.UI;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
  //public variables
  public float Score = 0;
  public Sprite[] Hearts;

    void Update()
    {
        //increases the score relevant to time
        Score += Time.deltaTime;
    }

    void OnGUI()
    {
        //searches for the GameObject "EndingScore" and creates a reference through the ScoreText GameObject
        GameObject Health = GameObject.Find("Player");
        //Sets PlayerHealth as a reference to the PlayerController script
        PlayerController PlayerHealth = Health.GetComponent<PlayerController>();
        //searches for the GameObject "Heart 3" and creates a reference through the Heart_3 GameObject
        GameObject Heart_3 = GameObject.Find("Heart 3");
        //searches for the GameObject "Heart 2" and creates a reference through the Heart_2 GameObject
        GameObject Heart_2 = GameObject.Find("Heart 2");
        //searches for the GameObject "Heart 1" and creates a reference through the Heart_1 GameObject
        GameObject Heart_1 = GameObject.Find("Heart 1");
        //searches for the GameObject "ScoreBoard" and creates a reference through the ScoreText GameObject
        GameObject ScoreText = GameObject.Find("ScoreBoard");
        //checks at what value the players health is and creates a display accordingly
        if (PlayerHealth.health == 6)
        {
            Heart_3.GetComponent<Image>().sprite = Hearts[0];
            Heart_2.GetComponent<Image>().sprite = Hearts[0];
            Heart_1.GetComponent<Image>().sprite = Hearts[0];
        }
        else if (PlayerHealth.health == 5)
        {
            Heart_3.GetComponent<Image>().sprite = Hearts[1];
            Heart_2.GetComponent<Image>().sprite = Hearts[0];
            Heart_1.GetComponent<Image>().sprite = Hearts[0];
        }
        else if (PlayerHealth.health == 4)
        {
            Heart_3.GetComponent<Image>().sprite = Hearts[2];
            Heart_2.GetComponent<Image>().sprite = Hearts[0];
            Heart_1.GetComponent<Image>().sprite = Hearts[0];
        }
        else if (PlayerHealth.health == 3)
        {
            Heart_2.GetComponent<Image>().sprite = Hearts[1];
            Heart_1.GetComponent<Image>().sprite = Hearts[0];
        }
        else if (PlayerHealth.health == 2)
        {
            Heart_2.GetComponent<Image>().sprite = Hearts[2];
            Heart_1.GetComponent<Image>().sprite = Hearts[0];
        }
        else if (PlayerHealth.health == 1)
        {
            Heart_1.GetComponent<Image>().sprite = Hearts[1];
        }
        //outputs the player's score in the text component of ScoreBoard through the ScoreText reference
        ScoreText.GetComponent<Text>().text = "Score: " + (int)(Score * 100);
    }
}
