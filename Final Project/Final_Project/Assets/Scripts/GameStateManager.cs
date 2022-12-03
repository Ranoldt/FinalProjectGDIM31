using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;  //GameOver action
    public static float BuildingMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the building.
    public static float BoxMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the box.

    [SerializeField]
    private GameObject GameOverScreen; //A reference to the GameObject that is the GameOver UI Screen
    [SerializeField]
    private float buildingMovespeed; //This field is exposed in the editor but private to the class, this allows us to adjust the move speed of the building in the editor

    [SerializeField]
    private float boxMovespeed;
    
    private static GameStateManager _instance; //Singleton
   



    // Start is called before the first frame update
    void Start()
    {
        //Setup for making this class a Singlton 
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }


        //Put other inialization for you game state here
        BuildingMoveSpeed = buildingMovespeed;
       

        BoxMoveSpeed = boxMovespeed;
    }


    //These two methods help up to handle the Game being over and restarting. 
    public static void GameOver()
    {
        OnGameOver?.Invoke();
        //This invokes the game over screen - here we are calling all the methods that subscribed to this action. 

    }

}