using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starmana : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;

    public void closegame()
    {
        ButtonSoundEffect.Play();
        Application.Quit();
    }

    public void Play()
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(1);
    }
}
