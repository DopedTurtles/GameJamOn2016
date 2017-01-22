using UnityEngine;
using System.Collections;

public class CCameraController : MonoBehaviour
{

    private Transform barco;
    public float umbral = 2f;
    public float velocidadDeSeguimiento = 1f;
    public float camaraOffsetY = 5f;
    // Use this for initialization
    void Start()
    {
        barco = GameObject.FindGameObjectWithTag("barco").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(barco.position.y - transform.position.y) > umbral)
        {
            //transform.Translate(new Vector3(0, (barco.position.y - transform.position.y) * velocidadDeSeguimiento * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, barco.position.y + camaraOffsetY, barco.position.z);
        }
    }
}
