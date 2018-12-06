// Sean Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Sound_Controller : Menu_Controller {

    public AudioMixer s_AudioMixer;

    public void SetVolume (float volume)
    {
        s_AudioMixer.SetFloat("volume", volume);
    }

    public void BackButton ()
    {
        MainButton2();
    }

}
