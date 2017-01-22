using UnityEngine;
using System.Collections;

public class MovePenguen : MonoBehaviour
{
    public float RSpeed = 40;
    public float speed = 0.01f;
    private float pesoOriginal;
    private bool go = false;
    private int IdEvento;
   
    GameObject ship;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("barco");
        pesoOriginal = this.GetComponent<CPesoPlayer>().mPeso;
        this.GetComponent<CPesoPlayer>().mPeso = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Rotate(Vector3.right * Time.deltaTime * RSpeed, Space.World);
        if (go)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "PinguinStop")
        {
            RSpeed = 0;
            StartCoroutine("Desplazar");
        }
    }
  
    IEnumerator Desplazar()
    {
        for (int f = 0; f < 15; f++)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 25f);
            yield return null;
        }
        StartCoroutine("Levantar");
    }
    IEnumerator Levantar()
    {
        for (int f = 0; f < 30; f++)
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * 150, Space.World);
            yield return null;
        }
        if  (GameObject.FindGameObjectWithTag("barco").transform.position.z < transform.position.z)
            IdEvento = GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(pesoOriginal,true);
        else IdEvento = GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(pesoOriginal, false);
        Invoke("GoAway", 5);
    }
    void GoAway()
    {
      this.transform.parent.transform.parent = null;
      GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().removePeso(IdEvento);
      transform.LookAt(Camera.main.transform);
      gameObject.GetComponent<BoxCollider>().enabled = false;
      Destroy(gameObject, 20);
      go  = true;
    }
}
