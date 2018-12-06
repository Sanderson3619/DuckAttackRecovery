using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreupdatescript : Interaction
{
    public Text timerText;
    private float currentTime = 0;
    private float step = 0.01f;
    Text timer;
    public string TimerString = " ";

    void Start()
    {
        timer = GetComponent<Text>();
        if (timer)
        {
            timer.text = "Time: 0";
          
        }
         
    }

    void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        fontStyle.fontSize = 24;

        stringToEdit = GUI.TextField(new Rect(30, 20, 200, 50), "SCORE: " + score.ToString(), fontStyle);

        // Sean - changed == to >=, from 25 to 20. New green and red ducks make == difficult to achieve.
        if (score >= 20)
        {
            StartCoroutine(ExecuteAfterTime());
        }

        if (currentTime == 0)
        {
            StartCoroutine(ExecuteTimer());
        }

        int four = 4;
        TimerString = GUI.TextField(new Rect(600, 20, 200, 50), "Timer: " + (currentTime/ four).ToString("n2"), fontStyle);
        
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);

        //Abhilash is making this change below
        Cursor.visible = true;
       
        // Added by Sean - they won, go to win screen
        SceneManager.LoadScene("Victory Menu");

    }

    IEnumerator ExecuteTimer()
    {
        while (currentTime < 120)
        {
            yield return new WaitForSeconds(step);
            currentTime += step;
            
        }
        yield return new WaitForSeconds(step);
        Cursor.visible = true;
        // Added by Sean - they lost, go to defeat
        SceneManager.LoadScene("Defeat Menu");

    }

}