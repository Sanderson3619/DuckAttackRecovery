using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmovement : MonoBehaviour {

	private float speed = 2f;
	//used for altering movement speed of enemies
	public bool hit = false;
	//used for gun/enemy interaction
	public Vector2 position;
	//used so gun can track enemy


	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Vector2 angle = new Vector2 (-1, 0.5f);
		//initial movement vector
		GetComponent<Rigidbody2D> ().velocity = angle * speed;
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = GetComponent<Rigidbody2D> ().transform.position.x;
		//current x coordinate of enemy
		float yPos = GetComponent<Rigidbody2D> ().transform.position.y;
		//current y coordinate of enemy

		position = new Vector2 (xPos, yPos);
		//current x and y coordinate of enemy

		Vector2 angle = new Vector2 (0, 0);
		//angle is added on to current movement vector to change direction if leaving screen

		if (xPos <= -7.2) {
			angle = new Vector2 (1, 0);
		}
		if (xPos >= 7.2) {
			angle = new Vector2 (-1, 0);
		}
		if (yPos <= -3) {
			angle = new Vector2 (0, 0.5f);
		}

		if (yPos >= 3) {
			angle = new Vector2 (0, -0.5f);
		}

		GetComponent<Rigidbody2D> ().velocity = (GetComponent<Rigidbody2D>().velocity * (1/speed) + angle) *speed;
	}
}
