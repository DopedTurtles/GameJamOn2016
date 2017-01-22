using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventsController : MonoBehaviour {

    public List<GameObject> eventos;
    public float cdEvento;
    public bool spawning = true;

    private float temporizaor;
    private bool jump;
	void Start () {
        temporizaor = 0;
	}
	
	void Update () {
        if (spawning)
        {
            if (temporizaor >= cdEvento)
                LlamarEventoRandom();
            temporizaor += Time.deltaTime;
        }
	}

    void LlamarEventoRandom()
    {
        int chosen = Random.Range(0,eventos.Count);
        if (eventos[chosen].name.Equals("gaviota") ){ eventos[chosen].GetComponent<MoveSeagull>().siteToGo = GameObject.FindWithTag("Punto_1").transform; }
        if (eventos[chosen].name.Equals("gaviota2")) { eventos[chosen].GetComponent<MoveSeagull>().siteToGo = GameObject.FindWithTag("Punto_2").transform; }
        if (eventos[chosen].name.Equals("RotorPinguin")) {

            GameObject myBrick = Instantiate(eventos[chosen]);
            myBrick.transform.parent = GameObject.FindWithTag("SpawDelPinguino").transform;
            jump = true;
        }
        if (!jump)
        {
            Instantiate(eventos[chosen]);
        }
        jump = false;
        temporizaor = 0;
    }
    

}
