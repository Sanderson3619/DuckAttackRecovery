using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerTestScript : Duck_MovementTest {

	public GameObject enemy;
	public float spawnTime = 5f;
	public Transform[] spawnPoints;

	public static int noofDucks = 0;
	public static int maxDucks = 0;
	
	void Start()
	{
		InvokeRepeating("Spawn", 0.1f, spawnTime);        
	}

	// Update is called once per frame
	void Update () {

	}
	
	void Spawn()
	{	
		// duck.Initialize();
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		{
			if(maxDucks < 6)
			{
			Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			noofDucks++;	
			maxDucks++;
			} 			
		}
		
	}

}
