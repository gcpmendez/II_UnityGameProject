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
        var match = Regex.Match(curLevel, @"^([^0-9]+)([0-9]+)$");
        var num = int.Parse(match.Groups[2].Value);

        string newLevel = match.Groups[1].Value + (num + 1);

        SceneManager.LoadScene(newLevel);
    }

}
