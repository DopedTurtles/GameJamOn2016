using UnityEngine;
using System.Collections;

public class RayCastGyzmos : MonoBehaviour {

    public float radioEsfera=1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radioEsfera);
    }
}