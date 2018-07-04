using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {
    //public and private variables
    public GameObject[] Object2D;
    private float Background_x;

    // Use this for initialization
    void Start()
    {
        //calls the Generate() function
        Generate();
        //sets the value of the Background_x variable to 48.98f as this values creates a constant background effect
        Background_x = 48.98f;
    }

    //function used to spawn objects based on the tag related to that object
    void Generate()
    {
        //checks object for "Ground" tag
        if (Object2D[0].tag == "Ground")
        {
            //creates object given, at the given position and rotation (none)
            Instantiate(Object2D[0], transform.position, Quaternion.identity);
            //respawns object after set time
            Invoke("Generate", 1f);
        }
        //checks object for "Obstacle" tag
        else if (Object2D[0].tag == "Obstacle")
        {
            //creates local float variables used for spawn rate of the Obstacle Object
            float MinTime = 2f;
            float MaxTime = 6f;
            //creates a vector for the next position of the object to be placed with a random range of values for the y position
            Vector2 Position = new Vector2(transform.position.x, Random.Range(1f, 5f));

            //searches for the GameObject "Canvas" and creates a reference through the Score GameObject
            GameObject Score = GameObject.Find("Canvas");
            //Sets playerScore as a reference to the PlayerHud script
            PlayerHud playerScore = Score.GetComponent<PlayerHud>();

            //if statements used to check the score value and increase the difficulty of the game the higher the score by increasing the spawn rate of the Obstacle Object
            if (playerScore.Score >= 5 && playerScore.Score < 10)
            {
                MinTime = 2f;
                MaxTime = 5f;
            }
            else if (playerScore.Score >= 10 && playerScore.Score < 15)
            {
                MinTime = 2f;
                MaxTime = 4f;
            }
            else  if (playerScore.Score >= 15 && playerScore.Score < 20)
            {
                MinTime = 2f;
                MaxTime = 3f;
            }
            else if (playerScore.Score >= 20 && playerScore.Score < 25)
            {
                MinTime = 1f;
                MaxTime = 2f;
            }
            else if (playerScore.Score >= 25 && playerScore.Score < 30)
            {
                MinTime = 0.5f;
                MaxTime = 2f;
            }
            else if (playerScore.Score >= 30)
            {
                MinTime = 0.5f;
                MaxTime = 1f;
            }

            //creates object given, at the given position and rotation (none)
            Instantiate(Object2D[0], Position, Quaternion.identity);

            //Play Laser sound effect
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            //respawns object after set time
            Invoke("Generate", Random.Range(MinTime, MaxTime));
        }
        //checks object for "Platform" tag
        else if (Object2D[0].tag == "Platform")
        {

            //creates object given, at the given position and rotation (none)
            Instantiate(Object2D[Random.Range(0,3)], transform.position, Quaternion.identity);
            //respawns object after set time
            Invoke("Generate", Random.Range(1f, 2f));
        }
        //checks object for "Background" tag
        else if (Object2D[0].tag == "Background")
        {
            //creates a vector for the next position of the object to be placed
            Vector2 Position = new Vector2(Background_x, transform.position.y);
            //creates object given, at the given position and rotation (none)
            Instantiate(Object2D[Random.Range(0,9)], Position, Quaternion.identity);
            //adds a constant value to the Background_x to make the background look continous
            Background_x += 20.99f;
            //respawns object after set time
            Invoke("Generate", 3);
        }
    }
}
