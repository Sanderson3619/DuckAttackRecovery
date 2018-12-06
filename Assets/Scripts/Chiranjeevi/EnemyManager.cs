using UnityEngine;

public class EnemyManager : Duck_Movement
{

	// Prefab of the enemy, we use this in instantiate method to spawn the enemy.
	public GameObject m_Enemy;
	// These are the points where the ducks spawn in unity engine. 
	public Transform[] m_SpawnPoints;
	// This is the variable that acts as the Duck_Movement script. 
	public Duck_Movement m_Duck;
	// Variable to check the number of ducks spawned.
	public static int s_NoOfDucks = 0;
	// Variable to check the maximum number of ducks spawned.
	public static int maxDucks = 0;

    private int cheatMode = 1;

    public static int reload = 0;

    void Start()
    {
        // This calls the Duck_Movement script to the variable duck.
        m_Duck = GetComponent<Duck_Movement>();

        //Abhi's code
        cheatMode = m_Duck.m_GetGunNumber();

        // Invokes the spawn method after 0.1f second.
        Invoke("spawn", 0.1f);
        //InvokeRepeating("RedduckSpawn", 5f, 5f);
        //InvokeRepeating("GreenduckSpawn", 3f, 4f);	
    }

    void reLoadGame()
    {
        Debug.Log("Reloaded");
        Special_Enemy_Manager.replay = 1;
        // This calls the Duck_Movement script to the variable duck.
        m_Duck = GetComponent<Duck_Movement>();
        maxDucks = 0;
        s_NoOfDucks = 0;
        //Abhi's code
        cheatMode = m_Duck.m_GetGunNumber();

        // Invokes the spawn method after 0.1f second.
        Invoke("spawn", 0.1f);	
    }

    // Update is called once per frame
    void Update () {
        if(reload == 1)
        {
            reLoadGame();
            reload = 0;
        }
        // Checks if the duck is dead or alive by calling the duckCheck method in the Duck_Movement script.
        if (cheatMode != 4)
        {
            if (m_Duck.duckCheck() == true)
            {
                // Invokes the spawn method after 0.1f second.
                Invoke("spawn", 0.1f);
                // Sets backs the duck status as alive after spawning the new enemy.
                m_Duck.setDuck(false);
                s_NoOfDucks--;
            }
        }
        else //Abhi's part
        {
            InvokeRepeating("spawn", 0.1f, 1);
            if (m_Duck.duckCheck() == true)
            {
                // Invokes the spawn method after 0.1f second.
                Invoke("spawn", 0.1f);
                // Sets backs the duck status as alive after spawning the new enemy.
                m_Duck.setDuck(false);
                s_NoOfDucks--;
            }
        }
	}

    // This method spawns the enemy from the spawn points declared in unity.
    void spawn()
	{	
		// Uses this variable and calls the random function to spawn the enemies at random positions.
		int spawnPointIndex = Random.Range(0, m_SpawnPoints.Length);
        {
            // Make sure to spawn less than 10 ducks starting from 0. 
            if (cheatMode != 4)
            {
                if (maxDucks < 15 && s_NoOfDucks <= 2)
                {
                    // Instantiate the enemy with the prefab attached to it.
                    Instantiate(m_Enemy, m_SpawnPoints[spawnPointIndex].position, m_SpawnPoints[spawnPointIndex].rotation);
                    // Duck_Movement.spawnTime = 0;
                    // Increments the number of ducks after spawned.
                    s_NoOfDucks++;
                    // Increments the maximum number of ducks after spawned.
                    maxDucks++;
                }
            }
            else //Abhi's Part
            {
                if (maxDucks < 30 && s_NoOfDucks <= 2)
                {
                    // Instantiate the enemy with the prefab attached to it.
                    Instantiate(m_Enemy, m_SpawnPoints[spawnPointIndex].position, m_SpawnPoints[spawnPointIndex].rotation);
                    // Duck_Movement.spawnTime = 0;
                    // Increments the number of ducks after spawned.
                    s_NoOfDucks++;
                    // Increments the maximum number of ducks after spawned.
                    maxDucks++;
                }
            }
		}
	}
	
	public int duckCount()
	{
		return s_NoOfDucks;
	}

	public void setDuckCount(int m_ducks)
	{
		s_NoOfDucks = m_ducks;
	}

	// void nextSpawn()
	// {
	// 	Duck_Movement.spawnTime += 1;
	// 	if((Duck_Movement.spawnTime/4) >= 20f)
	// 	{
	// 		Duck_Movement.spawnTime = 0f;
	// 	}
	// 	UnityEngine.Debug.Log("Time : " + Duck_Movement.spawnTime/4);
	// }

}
