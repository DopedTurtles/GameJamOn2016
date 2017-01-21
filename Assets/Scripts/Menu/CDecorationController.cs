using UnityEngine;
using System.Collections;

public class CDecorationController : MonoBehaviour {

    private float mVelocidad = 1f;
    public float mAltura = 0f;
	// Use this for initialization
	void Start () {
        this.transform.Translate(Vector3.up * mAltura);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * mVelocidad);
	}

    public void SetVelocidad(float velocidad)
    {
        this.mVelocidad = velocidad;
    }
}
