using UnityEngine;
using System.Collections;

public class RayCastGyzmos : MonoBehaviour {

    Ray mRay;
    public float radioEsfera=1f;
    public float maxDistancia=10f;
	// Use this for initialization
	void Start () {
        mRay = new Ray();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, maxDistancia))
        {
            
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radioEsfera);
    }
}