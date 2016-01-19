using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class finish : MonoBehaviour
{

    /* void OnCollisionEnter(Collision colision)
     {
         if (colision.relativeVelocity.magnitude >= 0)
         {

             Debug.Log("la esfera a tocado algo.");

         }
     } */
    public TextMesh textObject;

    void Start()
    {

        textObject = GameObject.Find("Win").GetComponent<TextMesh>();
        textObject.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("la esfera ha tocado al Cube.");
            SetCountText();
        }
    }

    void SetCountText()
    {

        textObject.text = "Win!";
    }
}
