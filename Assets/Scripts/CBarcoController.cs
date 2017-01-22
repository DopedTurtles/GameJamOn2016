using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBarcoController : MonoBehaviour
{
    //Variable clave
    public float aceleracion = 0f;

    List<float> paraPesar;

    private float mRotationSpeed = 0f;
	private float mTotalRotation = 0f;
    
    public string mTagPlayer1 = "Player1";
    public string mTagPlayer2 = "Player2";
    public Transform boatFront;
    public Transform boatBack;
	public Transform boatCenter;


    //public float y2 = 0;
    public float rotationSpeedWaves = 1f;
    public float rotationSpeedPlayer = 1f;
	public float rotationEnemyCoefficient = 1f;
	public float rotationSpeedFriction = 1f;
    //Variables para RayTrace
    public float maxDistancia;
    public float rayDuration = 3f;
    private float frontDistance;
    private float backDistance;
    private float offsetY = 0;

	private bool mEndGame = false;
	public float mEndAnimationSpeed = 1.0f;
	public float mEndDelay = 3.0f;

    // Use this for initialization
    void Start()
    {
        paraPesar = new List<float>();
    }

	void OnDrawGizmos()
	{
		Gizmos.DrawSphere (boatFront.position, 0.1f);
		Gizmos.DrawSphere (boatBack.position, 0.1f);
		Gizmos.DrawSphere (boatCenter.position, 0.1f);
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit frontHit;
        RaycastHit backHit;
        RaycastHit middleHit;

		//Debug.DrawRay(boatFront.position, Vector3.down, Color.red);
		//Debug.DrawRay(boatBack.position, Vector3.down, Color.red);
		Debug.DrawRay(boatCenter.position, Vector3.down, Color.red);

		if (Physics.Raycast (boatFront.position, Vector3.down, out frontHit, maxDistancia)) {
			frontDistance = frontHit.distance;
			Debug.DrawRay (boatFront.position, Vector3.down * frontDistance);
		}
        else
            frontDistance = 0;

		if (Physics.Raycast (boatBack.position, Vector3.down, out backHit, maxDistancia)) {
			backDistance = backHit.distance;
			//Debug.DrawRay (boatBack.position, Vector3.down * backDistance);
		}
        else
            backDistance = 0;

		if (Physics.Raycast(boatCenter.position, Vector3.down, out middleHit, maxDistancia))
        {
            //y2 = middleHit.point.y;
            offsetY = middleHit.point.y;
        }

 
    }

    void LateUpdate()
    {
		if (!mEndGame) {
			CalculateHeight ();
			this.CalculateRotation ();
			checkRotation ();
		} else {
			EndGameAnimation ();
		}
    }

    /**
    * Rota el barco hasta la rotacion de mRotation
    **/
    private void RotateShip(float rotation)
    {
        this.transform.Rotate(rotation * Time.deltaTime, 0, 0);
		mTotalRotation += rotation * Time.deltaTime;
    }

	void CalculateHeight()
	{
		this.transform.position = new Vector3(transform.position.x, offsetY + 1.5f, transform.position.z);
	}
	void EndGameAnimation()
	{
		this.transform.position += Vector3.down * Time.deltaTime * mEndAnimationSpeed;
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
        //if (backDistance>0 && frontDistance>0)
        pendiente1 = Mathf.Atan((backDistance - frontDistance) / (Mathf.Abs(boatBack.position.z - boatFront.position.z)));
        /*if (backDistance <= 0) { 
            pendiente1 -= 10 * frontDistance;
            }
        if (frontDistance <= 0)
        {
                pendiente1 += 10 * backDistance;
        }*/
        float pendiente2 = this.transform.rotation.x;

		//Debug.Log ("Pediente 1: " + pendiente1.ToString() + "Pediente 2: " + pendiente2.ToString());

		float enemyWeight = 0f;
		for (int i = 0; i < paraPesar.Count; ++i) {
			enemyWeight += paraPesar [i];
		}
        aceleracion = (-(pendiente2 - pendiente1) * rotationSpeedWaves) // Player A
			+ aceleracionPlayers * rotationSpeedPlayer // Waves A
			+ enemyWeight * rotationEnemyCoefficient
			- mRotationSpeed * rotationSpeedFriction;										// Friction A


        mRotationSpeed += aceleracion * Time.deltaTime;
        //if (offsetY <= 0)
        //    offsetY = 0.6f;
        //this.transform.position = new Vector3(transform.position.x, offsetY+0.3f, transform.position.z);

        this.RotateShip(mRotationSpeed);
    }

	public int addPeso(float toAdd, bool toRight)
    {
		if (toRight)
        	paraPesar.Add(toAdd);
		else
			paraPesar.Add(-toAdd);
        //Debug.Log(paraPesar.Count);
        return paraPesar.Count;
    }

    public void removePeso(int idEvent)
    {
        paraPesar.RemoveAt(idEvent);
    }

	public void incrementRotationSpeed(float rotSpeed)
	{
		mRotationSpeed += rotSpeed;
	}

	void checkRotation()
	{
		if (Mathf.Abs(mTotalRotation) >= 90.0f) {
			mEndGame = true;
			StartCoroutine (EndGame());
		}
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds (mEndDelay);
		GameObject levelControllerObject = GameObject.FindGameObjectWithTag("LevelController");
		if(levelControllerObject)
		{
			CLevelController levelController = levelControllerObject.GetComponent<CLevelController>();
			if (levelController) {
				levelController.PedirGameOver ();
				Debug.Log ("LevelController Game !!!!!");
			}
		}
		
		Debug.Log ("Eng Game !!!!!");
	}
}
