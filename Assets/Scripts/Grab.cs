using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
    private float positionShip;
    private float offSet;
    private float originalFall;
	// Use this for initialization
	void Start () {
        positionShip = transform.parent.position.z;
        offSet       = 0.5f;
        originalFall = gameObject.GetComponent<Move>().forceFall;
    }
	
	// Update is called once per frame
	void Update () {
        positionShip = transform.parent.position.z;
        grabCenterShip();
    }

    void grabCenterShip()
    {
        if(offSet + positionShip > transform.position.z && positionShip - offSet < transform.position.z) gameObject.GetComponent<Move>().forceFall = 0;
        else gameObject.GetComponent<Move>().forceFall = originalFall;
    }
}
