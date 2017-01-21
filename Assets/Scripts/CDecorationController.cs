using UnityEngine;
using System.Collections;

public class CDecorationController : MonoBehaviour {

    private float mVelocidad = 1f;
    public float mAltura = 0f;
    private float mMaxDisplacement = 100f;
    private Vector3 mFirstPosition;
	// Use this for initialization
	void Start () {
        mFirstPosition = this.transform.position;
        this.transform.Translate(Vector3.up * mAltura);
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(this.mFirstPosition, transform.position) > mMaxDisplacement*10)
            GameObject.Destroy(this.gameObject);
        this.transform.Translate(Vector3.forward * mVelocidad);
	}

    public void SetVelocidad(float velocidad)
    {
        this.mVelocidad = velocidad;
    }

    public void SetMaxDisplacement(float maxDis)
    {
        this.mMaxDisplacement = maxDis;
    }
}
