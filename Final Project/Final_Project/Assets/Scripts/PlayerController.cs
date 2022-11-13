using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float upForce;
    [SerializeField]
    private Text scoreDisplay;

    private int score;

    public float time;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        upForce =10.0f;
        timer = 0.7f;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (time >= timer)
            {
                rb.velocity = transform.up * upForce;
                time = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "GameOver")
        {
            GameStateManager.GameOver();
            Destroy(gameObject);
        }

       if(collision.gameObject.tag == "Score")
        {
            score += 100;
            scoreDisplay.text = "" + score;
        }    
       
    }
}
