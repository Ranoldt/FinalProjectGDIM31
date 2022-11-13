using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    //This method gets called when the object is first created. It will get called even if the object is disabled.
    public void Awake()
    {
        //This object is subcribing to that Action in the Game State Manager. We will talk about this more indepth later in the Quarter and in GDIM 32
        GameStateManager.OnGameOver += Open;

        //Make sure this object is not visible when the game starts
        gameObject.SetActive(false);
    }

    //This method gets called when this object is destroyed.
    public void OnDestroy()
    {
        //Because the Game State Manager is going to persist across scene loads & reloads, we need to make sure that when this object goes away it unsubscribes from the action first.
        GameStateManager.OnGameOver -= Open;
   
    }

   //A method to Open the menu - We have this setup with the Action subscription to get called everytime the Game State Manager says the game is over.
    private void Open()
    {
        gameObject.SetActive(true); 
        //Show the menu
        //Do any other menu opening code.
       
    }

    //A method that we want to hook up to when the restart button gets pressed
    public void Restart()
    {
        //Add code here to restart the game
        SceneManager.LoadScene(0);
      
    }

    public static void Quit()
    {
        //quit the application
        Application.Quit();
    }
}
