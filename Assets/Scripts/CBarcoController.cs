using UnityEngine;
using System.Collections;

public class CBarcoController : MonoBehaviour {

    public float mRotationSpeed = 1f;
    public string mTagPlayer1 = "Player1";
    public string mTagPlayer2 = "Player2";

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
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
        this.transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(rotation, transform.rotation.y, this.transform.rotation.z,this.transform.rotation.w), (Time.deltaTime * this.mRotationSpeed)/100);
    }

    private void CalculateRotation()
    {
        float finalRotation = 0;
        GameObject player1 = GameObject.FindGameObjectWithTag(this.mTagPlayer1);
        GameObject player2 = GameObject.FindGameObjectWithTag(this.mTagPlayer2);
        CPesoPlayer peso1 = (CPesoPlayer)player1.GetComponent<CPesoPlayer>();
        CPesoPlayer peso2 = (CPesoPlayer)player2.GetComponent<CPesoPlayer>();
        float dp1 = player1.transform.localPosition.z;
        float dp2 = player2.transform.localPosition.z;
        finalRotation = peso1.mPeso*Mathf.Abs(dp1) - peso2.mPeso*Mathf.Abs(dp2);
        this.RotateShip(finalRotation);
    }
}
