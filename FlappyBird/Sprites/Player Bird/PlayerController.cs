using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D bird;
    public int force;
    public float health = 3f;
    private float gold = 0f;
    private Animator anim;
    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI GoldText;
    public AudioClip[] sound;
    public string hScoreText = "High Score";
    public float score;
    public float scoreSpeed = 1f;
    public float highScore;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;
    public GameObject loosePanel;
    


    private void Awake()
    {
        instance = this;
        bird = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        healthText.text = health + "";
        GoldText.text = gold + "";
        loosePanel.SetActive(false);
    }
    void Start()
    {
        health = 3f;
        score = 0f;
        highScore = PlayerPrefs.GetInt(hScoreText, 0);
        Time.timeScale = 1;
        highScoreText.text = "Your High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "";
        GoldText.text = gold + "";
        scoreText.text = (int)score + "";
        score += Time.deltaTime * 10f * scoreSpeed;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.anyKey)
        {
            bird.velocity = transform.up * force;
        }
            
        if(health <= 0f)
        {
            Debug.Log("Dead");
            anim.SetBool("Animation", false);
            loosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddHeart()
    {
        health += 1f; 
    }
    public void AddGold()
    {
        gold += 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gold")
        {
            AddGold();
            Debug.Log("Your Gold is" + gold);
            Destroy(collision.gameObject);
            PlayCoinSound();
        }
        if (collision.gameObject.tag == "Heart")
        {
            AddHeart();
            Debug.Log("Your Lives:" + health);
            Destroy(collision.gameObject);
            PlayHeartSound();
        }
    }

    public void PlayHitSound()
    {
        AudioSource.PlayClipAtPoint(sound[0], new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
    public void PlayCoinSound()
    {
        AudioSource.PlayClipAtPoint(sound[1], new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
    public void PlayHeartSound()
    {
        AudioSource.PlayClipAtPoint(sound[2], new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
    private void OnDisable()
    {
        if(score>highScore)
        {
            PlayerPrefs.SetInt(hScoreText, (int)score);
        }
    }

}
