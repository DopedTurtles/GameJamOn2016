using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CDecorationSpawner : MonoBehaviour {

    public List<GameObject> mDecoraciones;

    public float mVelocidad = 1f;
    public float mTiempoSpawn = 1f;
    public bool mTiempoRandom = false;
    public float timer;
    public float mMaxDistance = 500f;

	// Use this for initialization
	void Start () {
        if (mTiempoRandom)
            mTiempoSpawn = Random.Range(mTiempoSpawn-5, mTiempoSpawn+5);
        timer = mTiempoSpawn;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnDecoracion();
            if (mTiempoRandom)
                mTiempoSpawn = Random.Range(mTiempoSpawn - 5, mTiempoSpawn + 5);
            timer = mTiempoSpawn;
        }
    }

    public void SpawnDecoracion()
    {
        int index = Random.Range(0, mDecoraciones.Count-1);
        GameObject ob = (GameObject)Instantiate(mDecoraciones[index],transform.position,transform.rotation);
        CDecorationController cont = (CDecorationController)ob.GetComponent<CDecorationController>();
        ob.GetComponentInChildren<Transform>().Rotate(0, Random.Range(0, 180), 0);
        cont.SetMaxDisplacement(mMaxDistance);
        cont.SetVelocidad(mVelocidad/5);
    }

}
