using UnityEngine;
using System.Collections;

public class MoveSeagull : MonoBehaviour {
    public Transform siteToGo;
    private float distance ;
    public float speedSeagull = 10;
    private float pesoOriginal;
    private bool stop = false;
    private GameObject lockAt;
    private int IdEvento;
    private bool go = false;
    // Use this for initialization
    void Start () {
        pesoOriginal = this.GetComponent<CPesoPlayer>().mPeso;
        this.GetComponent<CPesoPlayer>().mPeso = 0;
        lockAt = GameObject.FindGameObjectWithTag("LookAt");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!go)
        {
            transform.LookAt(siteToGo.position);
            distance = Vector3.Distance(transform.position, siteToGo.position);
            if (distance >= 0.2 && !stop && !go)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speedSeagull);
            }
            else
            {
                this.GetComponent<CPesoPlayer>().mPeso = pesoOriginal;
                stop = true;
                Invoke("GoAway", 5);
            }
            if (stop && !go)
            {
                this.transform.parent = siteToGo.transform.parent;
                IdEvento =  GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(pesoOriginal);
                transform.LookAt(lockAt.GetComponent<Transform>());
            }
        }
        if (go)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedSeagull);
            transform.Translate(Vector3.up * Time.deltaTime * speedSeagull);
            
        }
    }
    void GoAway()
    {
        GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().removePeso(IdEvento);
        go = true;
        gameObject.transform.parent = null;

    }
}
