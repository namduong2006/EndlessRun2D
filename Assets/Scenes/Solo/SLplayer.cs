using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLplayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rbsl;
    [SerializeField] SpriteRenderer prenderer;
    private float slspeed = 4f;
    public bool jump = true;
    public float speedpl;
    public float runspeed = 1f;
    public bool boss = false;
    // Start is called before the first frame update
    void Start()
    {
        rbsl=GetComponent<Rigidbody2D>();   
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySL();       
    }
    private void PlaySL()
    {       
        // di chuyen

        var h = Input.GetAxis("Horizontal");
        
        //rbsl.velocity = move*slspeed*Time.deltaTime;

        if (boss == false)
        {
            Vector2 move = new Vector2(runspeed, 0f);
            transform.Translate(move * slspeed * Time.deltaTime);
            animator.SetBool("run", true);
        }
       
        // xoay+chay
        // 
        if (boss == true)
        {
            runspeed = 0f;
            transform.Translate(new Vector2(h, 0f) * slspeed * Time.deltaTime);
            if (h == 0)
            {
                animator.SetBool("run", false);
            }
            if (h != 0)
            {
                animator.SetBool("run", true);
                prenderer.flipX = h < 0;
            }

            

            // chem

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.Play("Chem");               
            }
            slspeed = 2f;
        }

        // nhay

        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == true)
        {
            rbsl.velocity = new Vector2(rbsl.velocity.x, 5f);
            jump = false;
            animator.Play("Jump");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            jump = true;
        }
        if (collision.gameObject.CompareTag("Boss"))
        {            
            boss = true;           
        }
    }
}
