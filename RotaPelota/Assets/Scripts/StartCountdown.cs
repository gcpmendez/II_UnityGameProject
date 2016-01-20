using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

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

    int levelNum = 999; // For displaying the level in the countdown.
    AudioSource music = GameObject.Find("music").GetComponent<AudioSource>();

    static float musicVol = 0.85f;  // Was too loud on my phone at least.

    void OnLevelWasLoaded()
    {
        GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = false;
        time = 4;
        count = true;
        var match = Regex.Match(Application.loadedLevelName, @"^([^0-9]+)([0-9]+)$");
        levelNum = int.Parse(match.Groups[2].Value);

        music = GameObject.Find("music").GetComponent<AudioSource>();
        music.Stop();
        music.volume = 0f;
        music.PlayScheduled(time);  // This gives time for the AudioSource to load properly.

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
                case 0: textObject.text = "Level " + levelNum; break;
                case 1: textObject.text = "3"; break;
                case 2: textObject.text = "2"; break;
                    // Somehow calling this here produces the best sync to "Start!" appearing on screen.
                case 3: textObject.text = "1"; break;
                case 4: textObject.text = "Start!";
                    music.Play();
                    music.volume = musicVol;
                    break;
                case 5:
                    // GameObject.Find("StartCounter").GetComponent<UnityEngine.UI.Text>().enabled = false;
                    textObject.text = "";
                    count = false;
                    GameObject.Find("Canica").GetComponent<Rigidbody>().useGravity = true;
                    GameObject.Find("Canica").transform.parent = GameObject.Find("CardboardMain").transform;

                    break;
            }
        }
    }
}