using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManagement : MonoBehaviour {

	public Transform ufo;
	//include the prefab for an enmey so it can spawn them
	public Transform goldUfo;
	//include the prefab for the special enmey so it can spawn them

	private int count = 0;
	//counts frames since last reset
	private int spawnTime = 4;
	//time in seconds between each enemy spawn
	private int goldSpawnTime = 10;
	//time in seconds between each goldUFO spawn
	private int goldCount;
	//Counts frames since last reset, but for the gold enemies and not normal ones
	private int maxEnemies = 5;
	//maximum number of enemies on the screen at once
	public int currEnemies = 0;
	//Current number of enemies on screen


	public int testCaseSpawns = 1;
	//used for stress test, how many enemies spawn at beginning

	// Use this for initialization
	void Start () {

		for(int i = 0; i < testCaseSpawns; i++){
			Instantiate (ufo, new Vector2(Random.Range(-7.2f,7.2f), Random.Range(-3f, 3f)), Quaternion.identity);
			currEnemies++;
		}
	}

	// Update is called once per frame
	void Update () {
		count++;
		goldCount++;
		if(goldCount >= 60*goldSpawnTime && currEnemies < maxEnemies){
			Instantiate(goldUfo, new Vector2(Random.Range(-7.2f,7.2f), Random.Range(-3f, 3f)), Quaternion.identity);
			goldCount = 0;
		}
		if (count >= 60*spawnTime && currEnemies < maxEnemies) {
			//Instantiate two at a time to make game a little more involved
			Instantiate (ufo, new Vector2(Random.Range(-7.2f,7.2f), Random.Range(-3f, 3f)), Quaternion.identity);
			Instantiate (ufo, new Vector2(Random.Range(-7.2f,7.2f), Random.Range(-3f, 3f)), Quaternion.identity);
			count = 0;
		}

		//All UFO enemies have tag "UFO". This line sets the current amount of enemies to the current number of gameobjects with that tag
		currEnemies = GameObject.FindGameObjectsWithTag ("UFO").Length;
	}
}
