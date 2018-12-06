using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* My attempt at static and dynamic binding. This class would create instances
 * of normal and gold ufos, using static and dynamic binding. Then, we could call
 * those classes and call thsoe functions. However, gameobjects only execute code if
 * the functions are attached to the object itself. Since these functions are being executed from a
 * created class, the gameobject does not move as intended. So, instead of creating instances of classes
 * like this, we assign prefabs the classes of UFOEnemy and GoldUFOEnemy and Instantiate the prefabs.
*/

public class GoldUFO2 : MonoBehaviour {

	GoldUFOEnemy ufo = GoldUFOEnemy.getInstance();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ufo.move ();
		ufo.teleport ();
	}
}
