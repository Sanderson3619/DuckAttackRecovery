using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : Duck_Movement
{
    Text instruction;
    public static int score = 0;
    public string stringToEdit = " ";
    private Duck_Movement duckScore;


    // Use this for initialization
    void Start () {
        instruction = GetComponent<Text>();
        duckScore = GetComponent<Duck_Movement>();
        if (instruction)
        {
            instruction.text = "Score: 0";
        }
        
    }

    void Update_score(bool hit)
    {
        if (hit == true)
        {
            score = score + duckScore.m_ScoreValue;
            Duck_Movement.s_IsDead = true;
        }
        
    }
    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // stop all animations
            CancelInvoke();
            InvokeRepeating("DuckHit", 0.5f, 0.1f);

        }

    }


    void DuckHit()
    {       
        m_Position = new Vector2(0, -1);
        int ips = (int)GetComponent<Rigidbody2D>().transform.position.y;

        GetComponent<Rigidbody2D>().transform.Translate(m_Position);

        if (ips <= -3)
        {
			gameObject.SetActive (false);
			CancelInvoke ();
			m_Hit = true;
        }

        Update_score(m_Hit);
    }


}