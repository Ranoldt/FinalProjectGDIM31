using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyattackArea = default;
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
        enemyattackArea = this.gameObject.transform.GetChild(0).gameObject;
        enemyattackArea.SetActive(false);
    }




    private void OnCollisionEnter2D(Collision2D collision) //If player runs into tag, kill player
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyattackArea.SetActive(true);
            m_AnimEnemy.SetBool("Killed", true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) //If enemy runs into tag, kill Enemy
    {
        if (collision.gameObject.tag == "Attack")
        {
            enemyattackArea.SetActive(false);
            m_AnimEnemy.SetTrigger("Dead");
            Destroy(gameObject, 0.06f);
        }
        
            

    }
}