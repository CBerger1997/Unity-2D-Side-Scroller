using UnityEngine;
using System.Collections;

public class HighScoreReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("HighScore Index", 0);
        PlayerPrefs.SetFloat("High Score0", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
