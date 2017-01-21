using UnityEngine;
using System.Collections;

public class CSharkController : MonoBehaviour { 
    public float sharkVelocidad=10f;
    public float umbral=1f;
    public float offsetY=10f;
    public float offsetZ=10f;
    Vector3 target;
	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, 1);
        if (rand == 0)
        {
            Debug.Log("Random 0");
            target = GameObject.FindGameObjectWithTag("backBoat").GetComponent<Transform>().position;
            this.transform.position = new Vector3(target.x,target.y-offsetY, target.z - offsetZ);
        }
            
        else
        {
            Debug.Log("Random 1");
            target = GameObject.FindGameObjectWithTag("frontBoat").GetComponent<Transform>().position;
            this.transform.position = new Vector3(target.x, target.y - offsetY, target.z + offsetZ);
        }
            
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(Vector3.Distance(transform.position, target)>umbral)
        {
            Vector3.Lerp(transform.position, target, sharkVelocidad * Time.fixedDeltaTime);
        }
        else
        {
            //Llegado al punto y mordido el barco
            GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(this.GetComponent<CPesoPlayer>().mPeso);
        }
    }
}
