using UnityEngine;
using System.Collections;

public class StartCountdown : UnityEngine.MonoBehaviour
{
    int time, a;
    float x;
    public bool count;
    public string timeDisp;

    void Start()
    {
        OnLevelWasLoaded();
    }

    void OnLevelWasLoaded()
    {
        GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = false;
        time = 3;
        count = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count)
        {
            timeDisp = time.ToString();

            TextMesh textObject = GameObject.Find("StartCounter").GetComponent<TextMesh>();
            textObject.text = timeDisp;
            x += UnityEngine.Time.deltaTime;
            a = (int)x;
            switch (a)
            {
                
                case 0: textObject.text = "3"; break;
                case 1: textObject.text = "2"; break;
                case 2: textObject.text = "1"; break;
                case 3: textObject.text = "Start!"; break;
                case 4:
                    //GameObject.Find("StartCounter").GetComponent<UnityEngine.UI.Text>().enabled = false;
                    textObject.text = "";
                    count = false;
                    GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = true;
                    GameObject.Find("Canica").transform.parent = GameObject.Find("CardboardMain").transform;
                    break;
            }
        }
    }
}