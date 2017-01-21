using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private float rotationShip;
    public float forceAcceleration;
    public float forceFall;
    // Use this for initialization
    void Start()
    {
        rotationShip = transform.parent.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        rotationShip = transform.parent.rotation.x;
        movePlayerInclination();
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

