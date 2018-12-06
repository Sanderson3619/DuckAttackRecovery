using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMenu : MonoBehaviour {
	
    // Calls the menuTest method when the user choose to test the menu screen.
	public void menuTest ()
    {
        // Go to the Menu test scene.
		SceneManager.LoadScene("StartMenu");
    }

    // Calls the playerTest method when the user choose to test the player.
	public void playerTest ()
    {
        // Go to the Player test scene.
        SceneManager.LoadScene("MainGamePlayerTest");
    }

    // Calls the enemyTest method when the user choose to test the enemies on the screen.
	public void enemyTest ()
    {
        // Go to the Enemy test scene.
        SceneManager.LoadScene("MainGameEnemyTest");
    }

    // Calls the scoreTest method when the user choose to test the score on the screen.
	public void scoreTest ()
    {
        // Go to the Score test scene.
        SceneManager.LoadScene("MainGamePlayerTest");
    }

    // Calls the backToMainMenu method when the user choose to go back to the main menu screen.
	public void backToMainMenu()
    {
        // Go back to the Start Menu scene.
        SceneManager.LoadScene("StartMenu");
    }
}
