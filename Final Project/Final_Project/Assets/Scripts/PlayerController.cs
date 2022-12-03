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
    
    public int score;

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
    void Start() //Define animation, Jump Variables. 
    {
        m_Anim = GetComponent<Animator>();
        if (m_Anim != null)
        {
            m_Anim.SetBool("Ground", true);

        }
        
        upForce = 10.0f;
        timer = 0.85f;
        time = 0.0f;
        Highscoredisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Create a PlayerPref to save data onto text
    }

    // Update is called once per frame
    void Update() //When the space key is pressed, Object will jump with timer. 
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

        if (score > PlayerPrefs.GetInt("HighScore", 0)) //When the score is higher than the Highscore text, Set as Highscore
        {
            PlayerPrefs.SetInt("HighScore", score);
            Highscoredisplay.text = "" +score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)// When Playeer touches ground, play running animation
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_Anim.SetBool("Ground", true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameOver")//When Object collides with tag, it will call upon Gameover, Destroy Object, Play Animation, and sound.
        {
            DeathSoundEffect.Play();
            m_Anim.SetBool("GameOver", true);
            Destroy(gameObject, 4f);
            GameStateManager.GameOver();
        }

        if (collision.gameObject.tag == "Score")//When Object collides with tag, it will call sound and add to score.
        {
            RewardSoundEffect.Play();
            score += 100;
            scoreDisplay.text = "" + score;
            
            
        }

        if (collision.gameObject.tag == "Enemy")//When Object collides with tag, it will call sound and add to score. 
        {
            EnemenySoundEffect.Play();
            score += 100;
            scoreDisplay.text = "" + score;
        }
    }


}
