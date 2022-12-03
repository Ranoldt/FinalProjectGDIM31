using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starmana : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;

    public void closegame() //A method to close the game with button sounds
    {
        ButtonSoundEffect.Play();
        Application.Quit();
        
    }

    public void Play() //A method to load the game with button sounds
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(1);
    }
}
