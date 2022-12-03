using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buildingPrefabs;  //A list of building object templates
    [SerializeField]
    private float spawnMinTime; //The minimum amount of time to wait before spawning a building
    [SerializeField]
    private float spawnMaxTime; //The maximum amount of time to wait before spawning a building

    private float nextSpawnTime; //The next time to spawn a building
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = 0f;
        
        //buildings spawn immediately so the player can jump from a starting building rather than fall. 

    }

    // Update is called once per frame
    void Update()
    {

        //Check when a building will spawn

       

        if (Time.time >= nextSpawnTime)
        {
            GameObject.Instantiate(buildingPrefabs[Random.Range(0, 9)], transform);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }



    }
}

