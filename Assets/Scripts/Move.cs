using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void movePlayer(bool moveLeft, float speed)
    {
        if (moveLeft) transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        else transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
