using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

   /* void OnCollisionEnter(Collision colision)
    {
        if (colision.relativeVelocity.magnitude >= 0)
        {

            Debug.Log("la esfera a tocado algo.");

        }
    } */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("la esfera ha tocado al Cube.");
        }
    }
}