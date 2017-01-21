using UnityEngine;
using System.Collections;

public class MovePenguen : MonoBehaviour
{
    public float RSpeed = 25;
    public float speed = 0.01f;
    private float pesoOriginal;
    GameObject ship;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Barco");
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
        if (other.tag == "Barco")
        {
            RSpeed = 0;
            StartCoroutine("Desplazar");
           // StartCoroutine("Levantar");
        }

    }
  
    IEnumerator Desplazar()
    {
        for (int f = 0; f < 20; f++)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10f);
            yield return null;
        }
        StartCoroutine("Levantar");
    }
    IEnumerator Levantar()
    {
        for (int f = 0; f < 50; f++)
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * 120, Space.World);
            yield return null;
        }
        this.GetComponent<CPesoPlayer>().mPeso = pesoOriginal;
    }
}
