using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector2 spawnValues;
    public float spawnWait;

    // The time increments we want our enemies to be spawned between
    public float spawnMostWait;
    public float spawnLeastWait;

    public int startWait;
    public bool stop;
    private int randEnemy;

    public int enemiesSpawned = 0;
    public int maxEnemies;

    void Start ()
    {
        StartCoroutine(waitSpawner());	
	}
	
	
    void Update ()
    {
        // random time between the two floats
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

        if (maxEnemies <= enemiesSpawned)
        {
            stop = true;
            }
        else
        {
            stop = false;
            Destroy(gameObject, 3f);
        }
    }

    // Co-routine
    IEnumerator waitSpawner ()
    {
        yield return new WaitForSeconds (startWait);

        while (stop) // as long as stop is true
        {
            // Picking a number between 0 and 2
            randEnemy = Random.Range(0, 2);

            // Choosing the position between the x and y coordinates
            // Vector2 spawnPosition = new Vector2 (Random.Range(-spawnValues.x, spawnValues.x), 1);

            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), -2);

            Instantiate(enemies[randEnemy], spawnPosition, gameObject.transform.rotation);

        //    Instantiate(Enemy2, new Vector2(Random.Range(-7.2f, 7.2f), Random.Range(-3f, 3f)), Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
