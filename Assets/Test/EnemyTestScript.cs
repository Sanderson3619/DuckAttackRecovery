using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : Duck_Movement {

	public GameObject enemy;
	public float spawnTimeTest = 5f;
	public Transform[] spawnPointstest;
	public Duck_Movement duck;
	public static int noofDucks = 0;
	public static int maxDucks = 0;
	
	void Start()
	{
		duck = GetComponent<Duck_Movement>();
		InvokeRepeating("Spawn", 0.1f, spawnTimeTest);        
	}

	// Update is called once per frame
	void Update () {

	}
	
	void Spawn()
	{	
		// duck.Initialize();
		int spawnPointIndextest = Random.Range(0, spawnPointstest.Length);
		{
			if(maxDucks < 1000)
			{
			Instantiate(enemy, spawnPointstest[spawnPointIndextest].position, spawnPointstest[spawnPointIndextest].rotation);
			noofDucks++;	
			maxDucks++;
			} 			
		}
		
	}

}
