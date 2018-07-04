using UnityEngine;
using System.Collections;

public class ObjectRemover : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D ObjectRemove)
    {
        //checks for the parent of the gameobject collided with
        if (ObjectRemove.gameObject.transform.parent)
        {
            //deletes parent if one is found
            Destroy(ObjectRemove.gameObject.transform.parent.gameObject);
        }
        //deletes the gameobject collided with if no parent is found
        else
        {
            Destroy(ObjectRemove.gameObject);
        }
    }
}
