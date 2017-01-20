using UnityEngine;
using System.Collections;

public class PlayerController_2 : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Move>().movePlayer(false, speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Move>().movePlayer(true, speed);
        }
    }
}
