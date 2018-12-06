// Sean Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_BGMusic : MonoBehaviour
{
        // Creating a singleton class for the background music
        private static Game_BGMusic saSingletonPattern;
        public static Game_BGMusic Instance
        {
            get { return saSingletonPattern; }
        }
        // Awake is built in to unity to initialize any variables of game states
        // before the game starts. 
        void Awake()
        {
            // Check for an existing instance
            if (saSingletonPattern != null && saSingletonPattern != this)
            {
                // If instance exists, destroy self
                Destroy(this.gameObject);
                return;
            }
            else
            {
                // If instance does not exist, store this one as an instance
                saSingletonPattern = this;
            }
            // Persist through scene changes
            DontDestroyOnLoad(this.gameObject);
        }
}