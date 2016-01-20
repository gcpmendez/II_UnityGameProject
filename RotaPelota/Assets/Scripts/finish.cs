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
    bool win = false;

    float interval = 1f;
    float nextTime = 0;

    public static float superInterval = 0.2f;   // The smaller, the smoother the ChangeMusic() transition is.
    static float wholeLoseTime = 2.0f;
    float remLoseTime = wholeLoseTime;

    int maxFall = 50;
    float levelHeight = GameObject.Find("CardboardMain").transform.position.y;
    float ballHeight = GameObject.Find("Canica").transform.position.y;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        http://answers.unity3d.com/questions/122349/how-to-run-update-every-second.html
        */
        if (Time.time >= nextTime)
        {
            if (lose == false)
            {
                if (win == false)
                {
                    levelHeight = GameObject.Find("CardboardMain").transform.position.y;
                    ballHeight = GameObject.Find("Canica").transform.position.y;
                    h = levelHeight - ballHeight;
                    // Debug.Log(string.Format("levelHeight: {0}, ballHeight: {1}", levelHeight, ballHeight));

                    CheckLossCondition();
                }
                else
                {
                    remLoseTime -= interval;
                    if (remLoseTime <= 0)
                    {
                        SetNextLevel();
                    }
                }

            }
            else 
            {
                ChangeMusic();

                remLoseTime -= interval;
                if (remLoseTime <= 0)
                {
                    SceneManager.LoadScene(Application.loadedLevelName);    // Reload scene.
                }
            }

            nextTime += interval;
        }
    }

    void CheckLossCondition()
    {
        if ((h) > maxFall)
        {
            AnimationLose();
            lose = true;
            interval = superInterval;
        }
    }

    static float maxPitch = 1.00f;

    void ChangeMusic()
    {
        float newP = maxPitch * (remLoseTime / wholeLoseTime);
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
            win = true;
        }
    }

    void AnimationWin()
    {
        textObject.text = "You Won!";
        
    }

    void AnimationLose()
    {
        textObject.text = "You Lost!";
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
