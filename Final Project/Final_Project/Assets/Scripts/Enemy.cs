using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyattackArea = default;
    private BoxCollider2D boxColliderComponent;

    private Animator m_AnimEnemy;
    private bool m_Ground;
    
    // Start is called before the first frame update
    void Start()
    {
        boxColliderComponent = GameObject.Find("enemyattackArea").GetComponent<BoxCollider2D>();
        m_AnimEnemy = GetComponent<Animator>();
        boxColliderComponent.enabled = true;
        if (m_AnimEnemy != null)
        {
            m_AnimEnemy.SetBool("Killed", false);

        }
        enemyattackArea = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            m_AnimEnemy.SetBool("Killed", true);
            Destroy(GameObject.FindWithTag("Player"));
            GameStateManager.GameOver();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            
            m_AnimEnemy.SetTrigger("Die");
            gameObject.SetActive(false);
        }
        
            

    }
}