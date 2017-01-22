using UnityEngine;
using System.Collections;

public class CPesoPlayer : MonoBehaviour {

    public float mPeso = 5.0f;
    public float mPesoMin = 1.0f;
    public float mPesoMax = 10.0f;
    public bool mPesoAleatorio = false;
    public bool mGordo = false;
	// Use this for initialization
	void Start () {
        if(mPesoAleatorio)
        this.CalcularPesoInicial();
        if (mGordo)
            mPeso = mPeso * 1.4f;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void CalcularPesoInicial()
    {
        mPeso = Random.Range(mPesoMin, mPesoMax);
    }
}
