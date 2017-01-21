using UnityEngine;
using System.Collections;

public class MovePenguen : MonoBehaviour
{
    public float RSpeed = 25;
    public float speed = 0.01f;
    private float pesoOriginal;
    private bool go = true;
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
            transform.Translate(Vector3.up * Time.deltaTime * 20f);
            yield return null;
        }
        StartCoroutine("Levantar");
    }
    IEnumerator Levantar()
    {
        for (int f = 0; f < 40; f++)
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * 150, Space.World);
            yield return null;
        }
        IdEvento = GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().addPeso(pesoOriginal);
        Invoke("GoAway", 5);
    }
    void GoAway()
    {
      GameObject.FindGameObjectWithTag("barco").GetComponent<CBarcoController>().removePeso(IdEvento);
       go  = true;
    }
}
