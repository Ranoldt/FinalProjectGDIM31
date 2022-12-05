using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
   

   void Start() //Sets the Volume to 1 when loaded first time.
    {
      if(PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
            load();
        }

      else
        {
            load();// calls load function in order to set to volume of player preference
        }
    }

    public void SetVolume() //Set the slider value to volume value
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }

    private void load() //Loads volume of player preference
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
        Save();
    }

    private void Save()// saves Player Preference
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
}
