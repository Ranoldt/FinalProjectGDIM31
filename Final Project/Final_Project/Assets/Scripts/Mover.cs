using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    private float reset;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < reset)
        {
            transform.position = startPos;
        }
    }
}
