using UnityEngine;
using System.Collections;

public class MoveSeagull : MonoBehaviour {
    public Transform siteToGo;
    private float distance ;
    public float speedSeagull = 10;
    private float pesoOriginal;
    private bool stop = false;
    private GameObject lockAt;
    private int evento;
    private bool go = false;
    private bool onlyOneTime;
    private bool onlyOneTime2;
    // Use this for initialization
    void Start () {
        pesoOriginal = this.GetComponent<CPesoPlayer>().mPeso;
        this.GetComponent<CPesoPlayer>().mPeso = 0;
        lockAt = GameObject.FindGameObjectWithTag("LookAt");
        onlyOneTime = false;
        onlyOneTime2 = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(go);
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
            }
            if (stop && !go)
            {
                this.transform.parent = siteToGo.transform.parent;
                if (!onlyOneTime2)
                {
                evento =  GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(pesoOriginal);
                    Debug.Log("aki");
                }
                onlyOneTime2 = true;
                transform.LookAt(lockAt.GetComponent<Transform>());
                Invoke("GoAway", 5);
                stop = false;
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
        go = true;
      
        gameObject.transform.parent = null;
        if (!onlyOneTime)
        {
            GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().removePeso(evento);
         
        }
        onlyOneTime = true;
      
     
    }
}
