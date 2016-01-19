using UnityEngine;
using System.Collections;

public class ExampleTilt2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public float speed = 10.0F;
    public float deviceTiltX = 0;
    public float deviceTiltY = 0;
    public float deviceTiltZ = 0;

    public bool simulateTilt = false;
    public bool keepRotating = false;

    void Update()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        if (!simulateTilt){
            rotationVector = Input.acceleration;
        } else {
            rotationVector.x = deviceTiltX;
            rotationVector.y = deviceTiltY;
            rotationVector.z = deviceTiltZ;
        }

        if (!keepRotating){
            transform.rotation = Quaternion.Euler(rotationVector);
        } else {
            if (rotationVector.sqrMagnitude > 1)
                rotationVector.Normalize();

            rotationVector *= Time.deltaTime;
        }
    }
}