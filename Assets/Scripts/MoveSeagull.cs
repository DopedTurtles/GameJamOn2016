using UnityEngine;
using System.Collections;

public class MoveSeagull : MonoBehaviour {
    public Transform siteToGo;
    private float distance ;
    public float speedSeagull = 10;
    private float pesoOriginal;
    private bool stop = false;
    // Use this for initialization
    void Start () {
        pesoOriginal = this.GetComponent<CPesoPlayer>().mPeso;
        this.GetComponent<CPesoPlayer>().mPeso = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(siteToGo.position);
        distance = Vector3.Distance(transform.position, siteToGo.position);
        if (distance >= 0.5 && !stop)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedSeagull);
        }else
        {
            this.GetComponent<CPesoPlayer>().mPeso = pesoOriginal;
            stop = true;
        }
        if (stop)
        {
            //this.transform = siteToGo.transform.parent;
        }
    }
  
}
