using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;    
    [SerializeField] SpriteRenderer plrenderer;
    [SerializeField] Transform pointbullet;
    //[SerializeField] GameObject bullet;    
    private float speed = 2f;
    private float jumpForce = 4.5f;  
    private bool isJumps = true;
    int combo = 0;
    bool movecam = false;
    float h;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1f;       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //h = Input.GetAxis("Horizontal");      // chay cho android
        rb.gravityScale = 0.7f;
    }    
    private void Update()
    {       
        MovePlayer();
        //AnimationPlayer();
        
    }
    void MovePlayer()
    {
        h = Input.GetAxis("Horizontal");        // chay cho computer
        float tam = Screen.width/2f;     //chieu dai man hinh /2        
        Vector2 c = Camera.main.WorldToScreenPoint(transform.position);     // chuyen doi vi tri the gioi cua player theo vi tri tren man hinh
        if( movecam == false)
        {
            if (c.x >= tam)
            {
                Camera.main.transform.position = new Vector3(transform.position.x, 0f, -10f);
            }
        }
        if(movecam == true)
        {
            if (c.x >= 1900)
            {
                Vector2 pomax = Camera.main.ScreenToWorldPoint(new Vector2(1900f, 0f));
                transform.position = new Vector2(pomax.x, transform.position.y);
            }
        }
        if (c.x <= 50)
        {
            Vector2 po = Camera.main.ScreenToWorldPoint(new Vector2(50f,0f));       // chuyen doi vi tri theo man hinh ve vi tri the gioi
            transform.position = new Vector2(po.x, transform.position.y);
        }       
        Vector2 move = new Vector2 (h, 0);       
        //transform.Translate(move * speed * Time.deltaTime);
        anim.SetFloat("Speed",Mathf.Abs(h));

        if (h < 0)
        {
            h = -1f;
            //plrenderer.flipX = true;
            transform.eulerAngles = new Vector2(0f, 180f);

        }
        if (h > 0)
        {
            h = 1f;
            transform.eulerAngles = new Vector2(0f, 0f);
            //plrenderer.flipX = false;
        }
        Vector2 pos = transform.position;
        pos.x += h * Time.deltaTime * speed;
        transform.position = pos;
        //jump
        if (isJumps)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && isJumps == true))
            {
                //isJumps = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("Jump", true);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("SK");
            }
        }
        if (isJumps == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Bullet();
            }
        }
        if(transform.position.y< -5f)
        {
            UIManager.Instance.TakeDamage();
        }
    }
    public void Jump()
    {
        if (isJumps)
        {
            //isJumps = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("Jump", true);
        }
    }
    public void Attack()
    {
        if (isJumps)
        {
            anim.SetTrigger("SK");
        }
        else
        {
            Bullet();
        }
    }
    public void StopMove()
    {
        h = 0;
    }
    public void MoveLeft()
    {
        transform.eulerAngles = new Vector2(0f, 180f);
        h = -1f;
        
    }
    public void MoveRight()
    {
        transform.eulerAngles = new Vector2(0f, 0f);
        h = 1f;        
    }
    public void SetMoveCam()
    {
        movecam = true;
    }
    public bool MoveCam()
    {
        return movecam;
    }
    public void OffSpeed()
    {
        speed = 0f;
    }
    public void OnSpeed()
    {
        speed = 2f;
    }
    void AnimationPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            combo++;
            anim.SetInteger("Combo", 1);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATK1"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
            {
                if (combo > 1)
                {
                    anim.SetInteger("Combo", 2);
                }
                else
                {
                    ResetCombo();
                }
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATK2"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
            {
                if(combo >2)
                {
                    anim.SetInteger("Combo", 3);
                }
                else
                {
                    ResetCombo();
                }
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATK3"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
            {
                ResetCombo();
            }
        }
    }
    void Bullet()
    {
        //GameObject bulet = Instantiate(bullet, pointbullet.position, Quaternion.identity);
        //Rigidbody2D bl = bulet.GetComponent<Rigidbody2D>();
        //bl.velocity = pointbullet.right * 20f;
        GameObject blpt = ObjectPool.instance.GetPhitieu();
        blpt.SetActive(true);
        blpt.transform.position = pointbullet.position;
        blpt.transform.rotation = Quaternion.identity;
        Rigidbody2D rbblpt = blpt.GetComponent<Rigidbody2D>();
        rbblpt.velocity = pointbullet.right * 15f;
    }
    void ResetCombo()
    {
        combo = 0;
        anim.SetInteger("Combo",0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check dieu kien de nhay isjump=true
        if (collision.gameObject.CompareTag("Untagged"))
        {
            anim.SetBool("Jump", false);
            isJumps = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Lava"))
        {
            UIManager.Instance.TakeDamage();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            isJumps = false;
        }
        
    }
    public void ResetPosition()
    {
        transform.position = new Vector2(transform.position.x - 4f,Camera.main.transform.position.y + 5f);        
    }
    public void SetColorRed()
    {
        plrenderer.color = Color.red;
    }
    public void SetColorWhite()
    {
        plrenderer.color= Color.white;
    }
}