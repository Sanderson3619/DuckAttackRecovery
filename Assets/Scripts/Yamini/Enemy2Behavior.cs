/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Behavior : Spawner {

    public Vector2 position;
    private float positionX;
    private float positionY;

    public float MoveSpeed = 4f;
    public float jumpSpeed = 4f;
    public Rigidbody2D jumpingEnemy;

    // Use this for initialization
    void Start () {
		Physics2D.IgnoreLayerCollision (8, 8, true);
        InvokeRepeating("Enemy2Movement", 0.5f, 0.3f);
        jumpingEnemy = GetComponent<Rigidbody2D>();
    }

    // Enemy2 Movement
    public void Enemy2Movement()
    {

        position = new Vector2(positionX, positionY);

        int vectorX = (int)GetComponent<Rigidbody2D>().transform.position.x;
        int vectorY = (int)GetComponent<Rigidbody2D>().transform.position.y;


        if (vectorX <= -7)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (vectorX >= 10) {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        
       if (vectorX <= -7.2)
        {
            positionX = 0.3F;

        }
        else if (vectorX >= 7.2)
        {
            positionX = -0.3F;
        }

        if (vectorY <= -3)
        {
            positionY = 0.3F;
        }
        else if (vectorY >= -1)
        {
            positionY = -0.2F;
        }

        GetComponent<Rigidbody2D>().transform.Translate(position);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        jumpingEnemy.AddForce(Vector3.up * jumpSpeed);
 //       jumpingEnemy.velocity(newVector3(0, 10, 0));

    }


}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour
{

    // Stores enemy's position 
    public Vector2 position;
    // Using this to change the direction manybe
    private float positionX = -1;
    private float positionY = 1;

    // Use this for initialization
    void Start()
    {

        // Invokes rabbitBehavior repeatedly until the duck is shot
        InvokeRepeating("rabbitBehavior", 0.5f, 0.3f);
    }

    // Movement of the duck is declared here.
    public void rabbitBehavior()
    {
        // Variable declared to get the current position of the duck. 
        position = new Vector2(positionX, positionY);

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
        else if (vectorY >= -2)
        {
            positionY = -0.8F;
        }

        GetComponent<Rigidbody2D>().transform.Translate(position);
    }

}

