using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buildingPrefabs;  //A list of pillar object templates
    [SerializeField]
    private float spawnMinTime; //The minimum amount of time to wait before spawning a pillar
    [SerializeField]
    private float spawnMaxTime; //The maximum amount of time to wait before spawning a pillar

    private float nextSpawnTime; //The next time to spawn a pillar

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = 0f;
        
        //Initalize when you will spawn the first pillar here.

    }

    // Update is called once per frame
    void Update()
    {

        //Here we will want to check if it's time to spawn another pillar. 

        //To spawn a pillar:
        //Randomly select a pillar template from the list
        //Use Instantiate to create an instance of that template in the game world.
        //Select the next time to spawn a pillar

        if (Time.time >= nextSpawnTime)
        {
            GameObject.Instantiate(buildingPrefabs[Random.Range(0, 8)], transform);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }



    }
}

