using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D boxColliderComponent;
    private GameObject ninjaattackArea = default;
    private bool attacking = false;
    private float TimeToAttack = 0.3f;
    private float timer = 0f;

    private Animator m_AnimNinja;
    private bool m_Ground;
    private bool m_Attack;
    // Start is called before the first frame update
    void Start()
    {
        boxColliderComponent = GameObject.Find("ninjaattackArea").GetComponent<BoxCollider2D>();
        m_AnimNinja = GetComponent<Animator>();
        boxColliderComponent.enabled = false;
        if (m_AnimNinja != null)
        {
            m_AnimNinja.SetBool("Ground", true);
           
        }
        ninjaattackArea = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            attack();
            m_AnimNinja.SetBool("Attack", true);
        }
        if (attacking)
        {
            
            timer += Time.deltaTime;

            if (timer >= TimeToAttack)
            {
                m_AnimNinja.SetBool("Attack", false);
                timer = 0;
                attacking = false;
                ninjaattackArea.SetActive(attacking);
            }
        }



    }

    private void attack()
    {
        boxColliderComponent.enabled = true;
        attacking = true;
        ninjaattackArea.SetActive(attacking);
        Debug.Log("A");
    }
}
