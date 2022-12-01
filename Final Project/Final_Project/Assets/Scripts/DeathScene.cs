using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.OnGameOver += Open;
        gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    public void OnDestroy()
    {
        
        GameStateManager.OnGameOver -= Open;

    }

    private void Open()
    {
        gameObject.SetActive(true);

    }

    public void Restart()
    {
       
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(0);
       
    }
}
