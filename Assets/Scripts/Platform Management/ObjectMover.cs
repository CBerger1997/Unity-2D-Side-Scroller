using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour {


    // Update is called once per frame
    void Update()
    {
        //moves object attatched to script in the positive x direction
        transform.Translate(new Vector2(-5f * Time.deltaTime, 0f));
    }
}