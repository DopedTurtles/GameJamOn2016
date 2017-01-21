using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private float rotationShip;
    public float forceAcceleration;
    public float forceFall;
    public float limitLeft = -6f;
    public float limitRight = 6f;
    public float t = 0;
    // Use this for initialization
    void Start()
    {
        rotationShip = transform.parent.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        t = this.transform.localPosition.z;
        rotationShip = transform.parent.rotation.x;
            movePlayerInclination();
        if (this.transform.localPosition.z > limitRight)
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, limitRight);
        if (this.transform.localPosition.z < limitLeft)
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, limitLeft); ;

    }

    public void movePlayer(bool moveLeft, float speed)
    {

        if (moveLeft)
        {
            if (rotationShip > 0) speed -= forceAcceleration * rotationShip;
            else speed -= forceAcceleration * rotationShip;
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            if (rotationShip > 0) speed += forceAcceleration * rotationShip;
            else speed += forceAcceleration * rotationShip;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    public void movePlayerInclination()
    {
        if (rotationShip > 0) transform.Translate(Vector3.forward * Time.deltaTime * rotationShip * forceFall);
        else transform.Translate(Vector3.forward * Time.deltaTime * rotationShip * forceFall);
    }
}

