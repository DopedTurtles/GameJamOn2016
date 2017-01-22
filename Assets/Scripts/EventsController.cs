using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventsController : MonoBehaviour {

    public List<GameObject> eventos;
    public float cdEvento;

    private float temporizaor;
	void Start () {
        temporizaor = 0;
	}
	
	void Update () {
        if(temporizaor>=cdEvento)
            LlamarEventoRandom();
        temporizaor += Time.deltaTime;
	}

    void LlamarEventoRandom()
    {
        int chosen = Random.Range(0,eventos.Count);
        Instantiate(eventos[chosen]);
        temporizaor = 0;
    }


}
