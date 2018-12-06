using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_MovementTest : MonoBehaviour
{
    // Two dimensional vector variable to store the position of the enemy. 
    public Vector2 position;
    // Float variable declared to chnage the direction of the ducks when they reached the boundaries. 
    private float positionX = -1;
    // Float variable declared to chnage the direction of the ducks when they reached the boundaries.
    private float positionY= 0;
    // Integer variabe declared to update the score value each time they shot by the user. 
    public int scoreValue = 0;
    // Bool variable declared to check whether the enemy is hit or not.
    public bool hit = false;
    // Static bool variable declared to check whether the duck is dead or alive. 
    public static bool isDead = false;

    // Use this for initialization
    void Start()
    {
        // Invokes DuckMovement repeatedly until the duck is dead or shot.
        InvokeRepeating("duckMovement", 0.5f, 0.3f);
    }

    // Movement of the duck is declared here.
    public void duckMovement()
    {
        // Variable declared to get the current position of the duck. 
        position = new Vector2(positionX,  positionY);

        // Integer variable declared to get the X position of the enemy. 
        int vectorX = (int)GetComponent<Rigidbody2D>().transform.position.x;
        // Integer variable declared to get the Y position of the enemy. 
        int vectorY = (int)GetComponent<Rigidbody2D>().transform.position.y;

        // Boundaries of the duck to move between the screen.
        if (vectorX <= -7.2)
        {
            positionX = 0.6F;
        }
        else if (vectorX >= 7.2)
        {
            positionX = -0.6F;
        }

        if (vectorY <= -3)
        {
            positionY = 1F;
        }
        else if (vectorY >= 3)
        {
            positionY = -1F;
        }
        // Translate, not position!! To add position to previous position.
        GetComponent<Rigidbody2D>().transform.Translate(position);
    }

    // Returns the status of the duck i.1 dead or alive.
    // public bool duckCheck()
    // {
    //     return isDead;
    // }

    // // Sets back the state of the duck to its value passed.
    // public void setDuck(bool value)
    // {
    //     isDead = value;
    // }
}

    