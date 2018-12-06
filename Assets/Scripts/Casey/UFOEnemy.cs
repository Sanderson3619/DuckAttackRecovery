/*Sprites attached to these gameobjects from clker.com, a website that allows users to download
 * png images for free. However, it is my responsibility as the downloader to consistently check if 
 * the terms of use change, otherwise I would need to stop using their images or properly credit the author.
 * Failure to do this could result in a copyright violation.
 * 
 * Also, the laser sound effects were downloaded from a youtube video and converted to an mp3 file.
 * The author was not credited. In the description, it did not say that his sound effect was free to use, but also did 
 * not specifiy how to credit him. If the original author chose to do so, and this game was sold for a profit, 
 * he/she could choose to file a copyright claim against this game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Normal UFO Enemy. Is spawned in by the UFOManager and moves around the screen until shot.
public class UFOEnemy : MonoBehaviour {

	public bool isDead = false;
	protected float speed = 2f;
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
		PlaySound ();
	}

	// Update is called once per frame
	void Update () {
		move ();
	}

public void move(){
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


	void onDestroy(){
		GameObject.Find("UFOManager").GetComponent<UFOManagement> ().currEnemies--;
	}

	private void PlaySound(){
		GetComponent<AudioSource> ().Play (0);
	}


}
