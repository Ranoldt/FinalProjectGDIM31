using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;
    // Start is called before the first frame update
    void Start() //This object is subcribing to that Action in the Game State Manager
    {
        GameStateManager.OnGameOver += Open;
        gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    public void OnDestroy() //The function is called when the object is destroyed
    {
        
        GameStateManager.OnGameOver -= Open;

    }

    private void Open() //A way to turn on the overlay
    {
        gameObject.SetActive(true);

    }

    public void Restart() //Loads Game
    {
       
        SceneManager.LoadScene(1);
    }

    public void Back() //Loads Menu Scene with sound
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(0);
       
    }
}
