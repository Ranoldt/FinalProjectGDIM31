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
    [SerializeField]
    private Text Highscoredisplay;
    
    private int score;

    public float time;
    public float timer;

    private Animator m_Anim;
    private bool m_Ground;
    private bool m_Attack;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource RewardSoundEffect;
    [SerializeField] private AudioSource EnemenySoundEffect;
    [SerializeField] private AudioSource DeathSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        if (m_Anim != null)
        {
            m_Anim.SetBool("Ground", true);

        }
        
        upForce = 10.0f;
        timer = 0.85f;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            m_Anim.SetBool("Ground", false);
            if (time >= timer)
            {
                jumpSoundEffect.Play();
                rb.velocity = transform.up * upForce;
                time = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_Anim.SetBool("Ground", true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            DeathSoundEffect.Play();
            m_Anim.SetTrigger("Die");
            Destroy(gameObject);
            GameStateManager.GameOver();
        }

        if (collision.gameObject.tag == "Score")
        {
            RewardSoundEffect.Play();
            score += 100;
            scoreDisplay.text = "" + score;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            EnemenySoundEffect.Play();
            score += 100;
            scoreDisplay.text = "" + score;
        }
    }

}
