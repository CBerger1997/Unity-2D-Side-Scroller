using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	

    void Start()
    {
        //plays the audio clip within the AudioSource components
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
	// Update is called once per frame
	void Update ()
    {
        //moves the object attachted to this script in the positive x direction
        transform.Translate(new Vector2(5f * Time.deltaTime, 0f));
    }
}
