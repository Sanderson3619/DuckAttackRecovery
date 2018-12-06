// Sean Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunSelection_Controller : MonoBehaviour
{
    private static int s_GunNumber;

    //Using this to get gunNumber: Added by Abhilash
    public int m_GetGunNumber()
    {
        return s_GunNumber;
    }

    // The user selects Gun #1
    public void Gun1Selected()
    {
        // Store that they chose Gun #1
        s_GunNumber = 1;
        // Go to the main game
        SceneManager.LoadScene("SceneSelection");
    }

    // The use selects Gun #2
    public void Gun2Selected()
    {
        // Store that they chose Gun #2
        s_GunNumber = 2;
        // Go to the main game
        SceneManager.LoadScene("SceneSelection");
    }

    // The user selects Gun #3
    public void Gun3Selected()
    {
        // Store that they chose Gun #3
        s_GunNumber = 3;
        // Go to the main game
        SceneManager.LoadScene("SceneSelection");
    }

    // The user selects Cheat
    public void CheaterCheaterPumpkinEater()
    {
        // Store that the user wants to be a cheater and use Gun #4
        s_GunNumber = 4;
        // Go to the main game
        SceneManager.LoadScene("SceneSelection");
    }

    public void BackButton()
    {
        // Go to the help screen
        SceneManager.LoadScene("StartMenu");
    }
}
