using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
  public void SetSFXVolume(float sfxVolume)
    {
        audiomixer.SetFloat("SFXVolume", sfxVolume);

    }

    public void SetMusicVolume(float musicVolume)
    {
        audiomixer.SetFloat("MusicVolume", musicVolume);

    }

    public void SetMasterVolume(float masterVolume)
    {
        audiomixer.SetFloat("MasterVolume", masterVolume);

    }
}
