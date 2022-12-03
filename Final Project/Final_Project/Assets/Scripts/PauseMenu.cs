using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    [SerializeField] private AudioSource PauseSoundEffect;
    // Update is called once per frame
    private void Start()
    {
        pauseMenuUI.SetActive(false); //Set Pause Menu off when intializing
    }

    void Update()
        //When ESCAPE is clicked, Pause function is called.
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            PauseSoundEffect.Play();
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume () //Set time to 1f to revwerse Pause
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() //Set time to 0f to pause
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() //Load menu for button
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() //Quit game for button
    {
        Application.Quit();
       
    }
}

