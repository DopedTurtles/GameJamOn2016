using UnityEngine;
using System.Collections;

public class CSharkController : MonoBehaviour
{
    public float sharkVelocidad = 10f;
    public float destroyDistance=200f;
    public float hitForce = 20;
    public float offsetX = 65f;
    public float umbral = 10f;
    private Transform boatTransform;
    public CBarcoController barcoController;
    int type;
    private float distanciaRecorrida;
    private bool chocado;

    // Use this for initialization
    void Start()
    {
        chocado = false;
        distanciaRecorrida = 0;
        boatTransform = GameObject.FindGameObjectWithTag("barco").GetComponent<Transform>();
        type = Random.Range(0,2);

        if (type == 0)
            transform.position = new Vector3(boatTransform.position.x - offsetX, boatTransform.position.y, -9);
        else
            transform.position = new Vector3(boatTransform.position.x - offsetX, boatTransform.position.y, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, boatTransform.position.y, transform.position.z);
        transform.Translate(new Vector3(0,0, sharkVelocidad * Time.deltaTime));

        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("barco").GetComponent<Transform>().position) < umbral && !chocado)
        {
            if (type == 0)
            {
                GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().incrementRotationSpeed(hitForce);
                //if(!GameObject.Find("Barco").GetComponent<CBarcoController>()) Debug.Log("No encuento controller2"); ;
                //barcoController.incrementRotationSpeed(hitForce);
            }
                else
                GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().incrementRotationSpeed(-hitForce);
                //barcoController.incrementRotationSpeed(-hitForce);
            chocado = true;
        }
        distanciaRecorrida += sharkVelocidad * Time.deltaTime;
        if (distanciaRecorrida >= destroyDistance)
            Destroy(this.gameObject);
}
}
