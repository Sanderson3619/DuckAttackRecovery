using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*A subclass of UFOEnemy. GoldUfos are smaller, and they use the same movement function from the
 * superclass. In addition to this, the Gold UFOs have a function called teleport, which allows them to
 * instantaneously move to a random position on screen, making it harder for the enemies to hit.
 * 
 * Because I did not write the interaction script, which determines how the score is updated, there was no way
 * for me to change the point values assigned to this type of UFO
*/

public class GoldUFOEnemy : UFOEnemy {

	private static GoldUFOEnemy uniqueInstance;
	//used for singleton class

	private int teleportTime = 2;
	//Time in seconds between teleport


	private int count = 0;
	//counts frames to track time


	//disables normal constructors for this class. Can only create an instance of this class through GetInstance
	private GoldUFOEnemy(){

	}


	//Singleton pattern. Only iniitalizes a new class if one has not been initialized yet
	public static GoldUFOEnemy getInstance(){
		if (uniqueInstance == null) {
			uniqueInstance = new GoldUFOEnemy ();
			return uniqueInstance;
		} else {
			return null;
		}
	}


	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Vector2 angle = new Vector2 (-1, 0.5f);
		//initial movement vector
		GetComponent<Rigidbody2D> ().velocity = angle * speed;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		teleport ();
	}
		
	//Teleports to a random location on stage
	public void teleport(){
		count++;
		if(count == 30*teleportTime){
			GetComponent<Rigidbody2D> ().MovePosition(new Vector2(Random.Range (-7.2f, 7.2f), Random.Range (-3f, 3f)));
			count = 0;
		}
		if (GetComponent<Rigidbody2D> ().transform.position.y < 3f) {
			GetComponent<AudioSource> ().Play (0);
		}
	}


		
}