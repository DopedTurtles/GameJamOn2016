using UnityEngine;
using System.Collections;

public class CSharkController : MonoBehaviour
{
    public float sharkVelocidad = 10f;
    public float umbral = 1f;
    public float offsetY = 10f;
    public float offsetZ = 10f;
    public float destroyDistance=10f;
    public Transform despawner;
    Transform target;

    private int idEvento;
    private bool stop;
    private bool waited;
    // Use this for initialization
    void Start()
    {
        int rand = Random.Range(0, 1);
        if (rand == 0)
        {
            target = GameObject.FindGameObjectWithTag("Punto_1").GetComponent<Transform>();
            this.transform.position = new Vector3(target.position.x, target.position.y - offsetY, target.position.z - offsetZ);
        }

        else
        {
            target = GameObject.FindGameObjectWithTag("Punto_2").GetComponent<Transform>();
            this.transform.position = new Vector3(target.position.x, target.position.y - offsetY, target.position.z + offsetZ);
        }
        stop = false;
        waited = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > umbral && !stop)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir * sharkVelocidad * Time.deltaTime);
            transform.LookAt(target);
        }
        else
        {
            //Llegado al punto y mordido el barco
            if (!stop)
            {
                Debug.Log("Llego");
                stop = true;
                transform.LookAt(despawner);
            }
        }
        if (stop && Vector3.Distance(transform.position, despawner.position) > umbral)
        {
            Vector3 dir = despawner.position - transform.position;
            
            transform.Translate(dir * sharkVelocidad * Time.deltaTime);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }



}
