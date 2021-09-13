using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] Toggle toggleSound;
    [SerializeField] Toggle toggleMusic;

    private void Start()
    {
        //toggleSound.isOn = PlayerPrefs.GetInt("SoundEnabled") == 1;
        //toggleMusic.isOn = PlayerPrefs.GetInt("MusicEnabled") == 1;
        float musicVolume, soundVolume;
        mixer.audioMixer.GetFloat("MusicVolume",out musicVolume);
        toggleMusic.isOn = musicVolume == 0;
        mixer.audioMixer.GetFloat("SoundVolume",out soundVolume);
        toggleSound.isOn = soundVolume == 0;
    }

    public void ToggleMusic()
    {
        if (toggleMusic.isOn)
        {
            mixer.audioMixer.SetFloat("MusicVolume", 0);
            //PlayerPrefs.SetInt("MusicEnabled", 1);
        }
        else
        {
            mixer.audioMixer.SetFloat("MusicVolume", -80);
            //PlayerPrefs.SetInt("MusicEnabled", 0);
        }
    }
    public void ToggleSound()
    {
        if (toggleSound.isOn)
        {
            mixer.audioMixer.SetFloat("SoundVolume", 0);
            //PlayerPrefs.SetInt("SoundEnabled", 1);
        }
        else
        {
            mixer.audioMixer.SetFloat("SoundVolume", -80);
            //PlayerPrefs.SetInt("SoundEnabled", 0);
        }
        
    }
}
