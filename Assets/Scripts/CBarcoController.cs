using UnityEngine;
using System.Collections;

public class CBarcoController : MonoBehaviour {
    //Variable clave
    public float aceleracion = 0f;


    public float mRotationSpeed = 0f;
    
    public string mTagPlayer1 = "Player1";
    public string mTagPlayer2 = "Player2";
    public Transform boatFront;
    public Transform boatBack;


    public float y2 = 0;
    public float rotationSpeedWaves = 1f;
    public float rotationSpeedPlayer = 1f;
    //Variables para RayTrace
    public float maxDistancia;
    public float rayDuration = 3f;
    private float frontDistance;
    private float backDistance;
    public float offsetY = 0;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        RaycastHit frontHit;
        RaycastHit backHit;
        RaycastHit middleHit;

        Debug.DrawRay(boatFront.position, Vector3.down,Color.red);
        Debug.DrawRay(boatBack.position, Vector3.down, Color.red);
        if (Physics.Raycast(boatFront.position, Vector3.down, out frontHit, maxDistancia))
            frontDistance = frontHit.distance;
        else
            frontDistance = 0;

        if (Physics.Raycast(boatBack.position, Vector3.down, out backHit, maxDistancia))
            backDistance = backHit.distance;
        else
            backDistance = 0;

        if (Physics.Raycast(transform.position, Vector3.down, out middleHit, maxDistancia))
        {
            y2 = middleHit.point.y;
            offsetY = middleHit.point.y;
        }

 
    }

    void LateUpdate()
    {
        this.CalculateRotation();
    }

    /**
    * Rota el barco hasta la rotacion de mRotation
    **/
    private void RotateShip(float rotation)
    {
        this.transform.Rotate(rotation * Time.deltaTime, 0, 0);
    }

    private void CalculateRotation()
    {
        float aceleracionPlayers = 0;
        GameObject player1 = GameObject.FindGameObjectWithTag(this.mTagPlayer1);
        GameObject player2 = GameObject.FindGameObjectWithTag(this.mTagPlayer2);
        CPesoPlayer peso1 = (CPesoPlayer)player1.GetComponent<CPesoPlayer>();
        CPesoPlayer peso2 = (CPesoPlayer)player2.GetComponent<CPesoPlayer>();
        float dp1 = player1.transform.localPosition.z;
        float dp2 = player2.transform.localPosition.z;
        aceleracionPlayers = peso1.mPeso*dp1 + peso2.mPeso*dp2;
        this.CalculateRotationWave(aceleracionPlayers);
    }

    private void CalculateRotationWave(float aceleracionPlayers)
    {
        float pendiente1 = 0;
        if (backDistance>0 && frontDistance>0)
        pendiente1 = Mathf.Atan((backDistance - frontDistance) / (Mathf.Abs(boatBack.position.z - boatFront.position.z)));
        if (backDistance <= 0) { 
            pendiente1 -= 10 * frontDistance;
            }
        if (frontDistance <= 0)
        {
                pendiente1 += 10 * backDistance;
        }
        float pendiente2 = this.transform.rotation.x;

        if (backDistance < 1 && frontDistance < 1 && (mRotationSpeed > 5 || mRotationSpeed < -5))
            mRotationSpeed = mRotationSpeed * 0.5f;
        aceleracion = (-(pendiente2 - pendiente1) * rotationSpeedWaves) + (aceleracionPlayers*rotationSpeedPlayer);
        mRotationSpeed += aceleracion*Time.deltaTime;
        this.transform.position = new Vector3(transform.position.x, offsetY+0.3f, transform.position.z);
        this.RotateShip(mRotationSpeed);
    }
}
