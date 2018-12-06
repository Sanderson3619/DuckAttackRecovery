// Sean Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Audio : MonoBehaviour {

	// Pauses audio when this gets loaded
	void Start () {
        Game_BGMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
	}
}
