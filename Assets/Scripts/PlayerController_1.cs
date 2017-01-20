using UnityEngine;
using System.Collections;

public class PlayerController_1 : MonoBehaviour {

    public float speed ;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Move>().movePlayer(false, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Move>().movePlayer(true, speed);
        }
    }
}
