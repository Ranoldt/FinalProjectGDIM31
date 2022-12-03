using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-GameStateManager.BuildingMoveSpeed * Time.deltaTime, 0f, 0f);
        //Move the bulding a little bit each frame
        
        transform.position += new Vector3(-GameStateManager.BoxMoveSpeed * Time.deltaTime, 0f, 0f);
        //move the box a little bit each frame
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
    //When bulding hits trigger, the building will depsawn
}