using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D boxColliderComponent;

    private Animator m_AnimEnemy;
    private bool m_Ground;
    
    // Start is called before the first frame update
    void Start() //Define animation
    {
       
        m_AnimEnemy = GetComponent<Animator>();
       
        if (m_AnimEnemy != null)
        {
            m_AnimEnemy.SetBool("Killed", false);

        }
       
    }

    
  

    private void OnCollisionEnter2D(Collision2D collision) //If player runs into tag, kill player
    {
        if (collision.gameObject.tag == "Player")
        {
            
            m_AnimEnemy.SetBool("Killed", true);
            Destroy(GameObject.FindWithTag("Player"),4f);
            GameStateManager.GameOver();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) //If enemy runs into tag, kill Enemy
    {
        if (collision.gameObject.tag == "Attack")
        {
            
         
            Destroy(gameObject);
        }
        
            

    }
}