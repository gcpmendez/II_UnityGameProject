using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    
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
            Debug.Log("La canica ha tocado la meta.");
            SetCountText();
            SetNextLevel();
        }
    }

    void SetCountText()
    {
        textObject.text = "Win!";
    }

    void SetNextLevel()
    {
        string curLevel = Application.loadedLevelName;
        /*
         http://stackoverflow.com/questions/15268931/increment-a-string-with-both-letters-and-numbers
        */
        string newLevel = Regex.Replace(curLevel, "\\d+",
            m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
        SceneManager.LoadScene(newLevel);
    }

}
