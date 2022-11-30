using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-GameStateManager.BuildingMoveSpeed * Time.deltaTime, 0f, 0f);
        //Move the pillar a little bit each frame
        //Debug.Log(GameStateManager.PillarMoveSpeed + " " + Time.deltaTime);

        transform.position += new Vector3(-GameStateManager.BoxMoveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

}