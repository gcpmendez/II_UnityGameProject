using UnityEngine;
using System.Collections;

public class dead : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	


    void  start()
    {
        Debug.Log(GameObject.Find("Canica").transform.position.y);
        if (GameObject.Find("Canica").transform.position.y <= 0)
        {
            print("muertee");
        }
    }

    void update()
    {

        Debug.Log(GameObject.Find("Canica").transform.position.y);
        if (GameObject.Find("Canica").transform.position.y <= 0)
        {
            print("muertee");
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    
}
