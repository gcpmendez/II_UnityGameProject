using UnityEngine;
using System.Collections;

public class ExampleTilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public float speed = 10.0F;
    public float deviceTiltX = 0;
    public float deviceTiltY = 0;
    public float deviceTiltZ = 0;
    void Update()
    {
        // deviceTiltX = Input.acceleration.x;
        // deviceTiltY = Input.acceleration.y;
        // deviceTiltZ = Input.acceleration.z;

        Vector3 dir = Vector3.zero;
 
        dir.x = deviceTiltX;
        dir.y = deviceTiltY;
        dir.z = deviceTiltZ;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }
}
