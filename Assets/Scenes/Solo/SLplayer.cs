using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLplayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rbsl;
    [SerializeField] SpriteRenderer plrenderer;
    private float slspeed = 4f;
    public bool jump = true;
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
        Vector2 move = new Vector2(h,0f);
        transform.Translate(move * slspeed * Time.deltaTime);
        //rbsl.velocity = move*slspeed*Time.deltaTime;
       
        // xoay

        if (h == 0)
        {
            animator.SetBool("run", false);
        }
        if (h != 0)
        {
            animator.SetBool("run", true);
            plrenderer.flipX =h < 0;
        }
        // nhay

        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == true)
        {
            rbsl.velocity = new Vector2(rbsl.velocity.x, 5f);
            jump = false;
            animator.Play("Jump");
        }

        // chem

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("Chem");
            slspeed = 1f;
        }
        slspeed = 4f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            jump = true;
        }
    }
}
