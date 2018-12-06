// Sean Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour {
    // for dynamic binding purposes
    public virtual void MainButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
    // for static binding purposes
    public void MainButton2()
    {
        SceneManager.LoadScene("StartMenu");
    }

    // The user clicks the Start Game button
    public void StartGame ()
    {
        // Go to the main game
        SceneManager.LoadScene("GunSelection");
    }

    // The user clicks the Quit Game button
    public void QuitGame()
    {
        // Exit the built unity.exe, does not work in the Unity Engine
        Application.Quit();
    }

    // The user clicks the Help button
    public void HelpScreen()
    {
        // Go to the help screen
        SceneManager.LoadScene("HelpMenu");
    }

    // The user clicks on the Sound Settings button
    public void SoundSettings()
    {
        // Go to the sound settings screen
        SceneManager.LoadScene("SoundMenu");
    }

    // The user clicks on the Demo game button
    public void DemoMode()
    {
        // Go to the Demo Mode screen
        SceneManager.LoadScene("DemoMode");
    }

    // The user clicks on the Replay game button (on Game Over screen)
    public void ReplayGame()
    {
        // Go to the Start Menu screen 
        SceneManager.LoadScene("StartMenu");

    }


    /* The following code is for demonstrating a Prototype
     * pattern. It does not do anything meaningful in the code.
     * It outputs some logs in the debug console when the play
     * button is hit, but that is all.
     */
    private void Start()
    {
        SimpleDemonstration Demonstration1 = new SimpleDemonstration();
        SimpleDemonstration Demonstration2 = (SimpleDemonstration)Demonstration1.Clone();
        Demonstration2.Display();
        SimpleDemonstration Demonstration3 = (SimpleDemonstration)Demonstration1.Clone();
        Demonstration3.Display();
        SimpleDemonstration Demonstration4 = (SimpleDemonstration)Demonstration1.Clone();
        Demonstration4.Display();
    }

    public abstract class sa_PrototypePattern
    {
        public sa_PrototypePattern() {}
        public abstract sa_PrototypePattern Clone();
    }

    public class SimpleDemonstration : sa_PrototypePattern
    {
        public SimpleDemonstration() {}
        public override sa_PrototypePattern Clone()
            {
                return (sa_PrototypePattern)this.MemberwiseClone();
            }

        public void Display()
            {
                Debug.Log("This demonstration has worked!");
            }    
    }
}

/* EXTRA STUFF - IGNORE
 *  MenuButton Button1 = new MenuButton("Prototype Pattern");
 *  
 *  
 *  
 *  private string sa_string = "Prototype Pattern";
 *  public Buttons(string sa_string2)
 *  {
 *         this.sa_string2 = sa_string; 
 *      }
 * 
 *    public string sa_string2
 *     {
 *       get { return sa_string; }
 *       set { sa_string = value; }
 *     }
 *  
 *  
 *  
 *  public MenuButton(string sa_string) : base(sa_string)
 *     {
 *  
 *     }
 */