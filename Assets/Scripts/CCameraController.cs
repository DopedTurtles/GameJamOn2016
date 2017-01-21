using UnityEngine;
using System.Collections;

public class CCameraController : MonoBehaviour {

    private Transform barco;
    public float umbral;
    public float velocidadDeSeguimiento;
	// Use this for initialization
	void Start () {
        barco = GameObject.FindGameObjectWithTag("barco").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Mathf.Abs(barco.position.y-transform.position.y)>umbral)
        {
            Vector3.Slerp(transform.position, barco.position, velocidadDeSeguimiento*Time.fixedDeltaTime);
        }
	}
}
