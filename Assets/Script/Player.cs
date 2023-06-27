using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] GameObject bom;
    [SerializeField] GameObject coinani;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] GameObject gameWinUI;
    [SerializeField] private float speed = 2f;
    private float jumpForce = 5.5f;  
    private bool isJumps = true;
    private int coin=0;  
    private bool gameover=false;
    [SerializeField] AudioSource audiobackground;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip audioCoin;
    [SerializeField] AudioClip audioGameover;
    [SerializeField] AudioClip audioJump;
    private void Start()
    {       
       
        speed = 2f;
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UIManager.Instance = FindObjectOfType<UIManager>();  
    }
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {       
        MovePlayer();
        
    }
    void MovePlayer()
    {
        // auto di chuyen
        
        transform.Translate (Vector2.right*speed*Time.deltaTime);
       

        //jump

        if (Input.GetKeyDown(KeyCode.UpArrow)&&isJumps==true)
        {
            isJumps = false;
            audiosource.clip = audioJump;
            audiosource.Play();
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            anim.Play("Jump");
            
        }
        if (isJumps == false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            return;
        }

        //slip

        if (Input.GetKeyDown(KeyCode.DownArrow)&& isJumps==true)
        {
            anim.Play("Slip");            
        }
        
        // goi mh gameover khi bien gameover =true

        if (gameover == true)
        {
            StartCoroutine(GameOverUI());
            
        }

    }

    // set hien mh gameover sau 0.8s
    IEnumerator GameOverUI()
    {
        yield return new WaitForSeconds(0.8f);
        gameoverUI.SetActive(true);
    }

    // tat audio

    void StopAudio()
    {
        audiosource.Stop();
        audiobackground.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // game over

        if (collision.gameObject.CompareTag("Computer") || collision.gameObject.CompareTag("Lava")|| collision.gameObject.CompareTag("Boom"))
        {
            audiosource.clip = audioGameover;
            audiosource.Play();
            audiobackground.Stop();
            gameover = true;
            speed = 0;
            anim.Play("Die");
            Time.timeScale = 0.5f;
        }
        
        // check dieu kien de nhay isjump=true

        if (collision.gameObject.CompareTag("Untagged"))
        {
            isJumps = true;           
        }

        // va cham coin + hieu ung 

        if (collision.gameObject.CompareTag("Coin"))
        {
            audiosource.clip = audioCoin;
            audiosource.Play();
            coin++;
            UIManager.Instance.SetCoin(coin);           
            DataManager.Coins++;
            GameObject c = Instantiate(coinani, collision.transform.position, Quaternion.identity);
            Destroy(c,1f);
            Destroy(collision.gameObject);
        }       

        // va cham boom + hieu ung

        if (collision.gameObject.CompareTag("Boom"))
        {
            GameObject b = Instantiate(bom, collision.transform.position, Quaternion.identity);
            Destroy(b,1f);
            Destroy(collision.gameObject);
        }

        // tang speed

        if (collision.gameObject.CompareTag("Speed"))
        {
            speed = speed + 0.25f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Level"))
        {
            gameWinUI.SetActive(true);
            StopAudio();
        }
    }
}
