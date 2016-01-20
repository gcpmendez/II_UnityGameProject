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
        OnLevelWasLoaded();
    }

    void OnLevelWasLoaded()
    {

        textObject = GameObject.Find("Win").GetComponent<TextMesh>();
        textObject.text = "";
    }



    float h = 0;

    bool lose = false;

    int interval = 1;
    float nextTime = 0;

    float superInterval = 0.2f;
    static float wholeLoseTime = 2.0f;
    float loseTime = wholeLoseTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        http://answers.unity3d.com/questions/122349/how-to-run-update-every-second.html
        */
        if (lose == false && Time.time >= nextTime)
        {
            levelHeight = GameObject.Find("CardboardMain").transform.position.y;
            ballHeight = GameObject.Find("Canica").transform.position.y;
            h = levelHeight - ballHeight;
            // Debug.Log(string.Format("levelHeight: {0}, ballHeight: {1}", levelHeight, ballHeight));

            CheckLossCondition();

            //do something here every interval seconds

            nextTime += interval;
        }

        if (lose == true && Time.time >= nextTime)
        {
            levelHeight = GameObject.Find("CardboardMain").transform.position.y;
            ballHeight = GameObject.Find("Canica").transform.position.y;
            h = levelHeight - ballHeight;
            // Debug.Log(string.Format("levelHeight: {0}, ballHeight: {1}", levelHeight, ballHeight));
            print(string.Format("heightDiff: {0}", h));
            
            ChangeMusic(0, wholeLoseTime, loseTime);

            loseTime -= superInterval;
            nextTime += superInterval;
            if (loseTime <= 0)
            {
                SceneManager.LoadScene(Application.loadedLevelName);    // Reload scene.
            }
        }

    }

    int maxFall = 100;
    float levelHeight = GameObject.Find("CardboardMain").transform.position.y;
    float ballHeight = GameObject.Find("Canica").transform.position.y;

    void CheckLossCondition()
    {
        if ((h) > maxFall)
        {
            AnimationLose();
            lose = true;
        }
    }

    float maxPitch = 1.00f;
    float minPitch = 0.90f;

    void ChangeMusic(float min, float max, float cur)
    {
        float newP = minPitch + maxPitch * (cur / (max - min));
        print(string.Format("New pitch: {0}", newP));
        AudioSource music = GameObject.Find("music").GetComponent<AudioSource>();
        music.pitch = newP;
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
