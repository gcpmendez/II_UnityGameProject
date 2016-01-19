using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    
    public TextMesh textObject;

    void OnLevelWasLoaded()
    {

        textObject = GameObject.Find("Win").GetComponent<TextMesh>();
        textObject.text = "";
    }

    int interval = 1;
    float nextTime = 0;

    // Update is called once per frame
    void Update()
    {
        /*
        http://answers.unity3d.com/questions/122349/how-to-run-update-every-second.html
        */
        if (Time.time >= nextTime)
        {
            CheckLossCondition();
            //do something here every interval seconds

            nextTime += interval;

        }

    }

    int maxFall = 200;

    void CheckLossCondition()
    {
        float levelHeight = GameObject.Find("CardboardMain").transform.lossyScale.y;
        float ballHeight = GameObject.Find("Canica").transform.lossyScale.y;
        if ((levelHeight - ballHeight) > maxFall)
        {
            AnimationLose();
            SceneManager.LoadScene(Application.loadedLevelName);    // Reload scene.
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal")
        {
            Debug.Log("La canica ha tocado la meta.");
            AnimationWin();
            SetNextLevel();
        }
    }

    void AnimationWin()
    {
        textObject.text = "Win!";
        
    }

    void AnimationLose()
    {
        textObject.text = "Lose!";
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
