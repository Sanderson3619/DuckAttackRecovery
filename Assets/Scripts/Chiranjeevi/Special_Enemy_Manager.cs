using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Enemy_Manager : MonoBehaviour {

// Prefab of the enemy, we use this in instantiate method to spawn the enemy.
	public GameObject m_enemy;
	// These are the points where the ducks spawn in unity engine. 
	public Transform[] m_SpecialSpawnPoints;
	public float m_SpawnTime = 8f;
	public static int s_SpecialDucks = 0;
	public Duck_Movement m_Duck;
	public EnemyManager m_CountDucks;
    public static int replay = 0;


    public static int s_SpecialDuck = 0;
	
	void Start()
	{
		m_CountDucks = GetComponent<EnemyManager>();
		InvokeRepeating("SpecialDuckspawn", m_SpawnTime, 15f);	
	}

    void replayGame()
    {
        s_SpecialDuck = 0;
        s_SpecialDucks = 0;
        m_CountDucks = GetComponent<EnemyManager>();
        //InvokeRepeating("SpecialDuckspawn", m_SpawnTime, 15f);
    }
	
	void Update()
	{
        if (replay == 1)
        {
            replayGame();
            replay = 0;
        }
    }
	// This method spawns the enemy from the spawn points declared in unity.
	void SpecialDuckspawn()
	{	
		// Uses this variable and calls the random function to spawn the enemies at random positions.
		int spawnPointIndex = Random.Range(0, m_SpecialSpawnPoints.Length);
		{
			if(s_SpecialDucks < 5)
			{
				// Instantiate the enemy with the prefab attached to it.
				Instantiate(m_enemy, m_SpecialSpawnPoints[spawnPointIndex].position, m_SpecialSpawnPoints[spawnPointIndex].rotation);
				// Increments the number of special ducks after spawned.
				s_SpecialDuck++;
				// Increments the maximum number of special ducks after spawned.		
				s_SpecialDucks++;
				Debug.Log("After Special duck - " + s_SpecialDuck);
				// m_CountDucks.setDuckCount(s_SpecialDuck);
			}	
		}		
	}
}
