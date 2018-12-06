using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour {

    // Chicken speed 
    private float chickenSpeed = 3f;
    // Position of the chicken
    public Vector2 position;


	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(8, 8, true);
        Vector2 angle = new Vector2(-1, 0.5f);
        // Chicken movement 
        GetComponent<Rigidbody2D>().velocity = angle * chickenSpeed;

    }
	
	// Update is called once per frame
	public void chickenBehavior () {
        // Chicken x-coordinate
        float xPosition = GetComponent<Rigidbody2D>().transform.position.x;
        // Chicken y-coordinate
        float yPosition = GetComponent<Rigidbody2D>().transform.position.y;
        // Chicken x- and y-coordinate
        position = new Vector2(xPosition, yPosition);
        // Angle is added on to current movement vector to change direction if leaving screen
        Vector2 angle = new Vector2(0, 0);

        if (xPosition <= -7.2)
        {
            angle = new Vector2(1, 0);
        }
        if (xPosition >= 7.2)
        {
            angle = new Vector2(-1, 0);
        }
        if (yPosition <= -3)
        {
            angle = new Vector2(0, 0.5f);
        }

        if (yPosition >= 3)
        {
            angle = new Vector2(0, -0.5f);
        }

        // The chicken movement from where it spawns
        GetComponent<Rigidbody2D>().velocity = (GetComponent<Rigidbody2D>().velocity * (1 / chickenSpeed) + angle) * chickenSpeed;

    }
}
