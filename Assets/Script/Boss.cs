using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator ranim;
    [SerializeField] private Transform pler;
    [SerializeField] private Image hpbar;
    [SerializeField] private Transform pShoot;
    [SerializeField] private int maxhp;
    float speed = 1.5f;
    int hp;   
    private bool combo = false;
    private void Start()
    {
        hp = maxhp;
        ranim = GetComponent<Animator>();
        
    }

    private void Update()
    {       
        MoveBoss();
        
    }
    void ShootBoss2()
    {
        for (int i = -5; i< 6; i++)
        {
            int h = Random.Range(-3,3);
            GameObject shoot2 = ObjectPool.instance.GetBulletEN2();
            shoot2.SetActive(true);
            shoot2.transform.position = new Vector2(transform.position.x + i, transform.position.y + 10f + h);
            shoot2.transform.eulerAngles = new Vector3(0f, 0f, -90f);
            Rigidbody2D rbshoot2 = shoot2.GetComponent<Rigidbody2D>();
            rbshoot2.velocity = Vector2.down * 0.5f;
        }
        
    }
    void ShootBoss1()
    {
        GameObject shoot = ObjectPool.instance.GetBulletEN2();
        shoot.SetActive(true);
        shoot.transform.position = pShoot.transform.position;
        shoot.transform.rotation = pShoot.transform.rotation;
        Rigidbody2D rbshoot = shoot.GetComponent<Rigidbody2D>();
        rbshoot.gravityScale = 0f;
        rbshoot.velocity = pShoot.right * 5f;
    }
    void MoveBoss()
    {
        
        var kc = transform.position.x - pler.transform.position.x;
        if (kc > 0)
        {           
            transform.eulerAngles = new Vector2(0f,-180f);
        }
        if (kc < 0)
        {
            transform.eulerAngles = new Vector2(0f,0f);
        }
        if (Mathf.Abs(kc) < 12f && Mathf.Abs(kc) > 1f)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            ranim.SetBool("Run", true);
            
        }
        if(Mathf.Abs(kc) < 12f)
        {
            if (!combo)
            {
                StartCoroutine(RockSkill());
            }
        }
        
        if (Mathf.Abs(kc) < 0.3f)
        {
            ranim.SetBool("Run", false);
        }
        //if (Mathf.Abs(kc) < 1.5f)
        //{
        //    transform.Translate(Vector2.right * Time.deltaTime * 0f);
        //    if (!combo)
        //    {
        //        StartCoroutine(RockAtk());
        //    }
        //}
        if (ranim.GetCurrentAnimatorStateInfo(0).IsName("RockAtk"))
        {
            if (ranim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95)
            {
                speed = 0f;
            }
            else
            {
                speed = 1.5f;
            }
        }
        if (ranim.GetCurrentAnimatorStateInfo(0).IsName("RockSkill"))
        {
            if (ranim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95)
            {
                speed = 0f;
            }
            else
            {
                speed = 1.5f;
            }
        }
    }
    public void TakeDamageOfBoss(int damage)
    {
        hp -= damage;
        hpbar.fillAmount = (float)hp / maxhp;
        if (hp <= 0)
        {
            ObjectPool.instance.OnDoor();
            Destroy(gameObject);
        }
    }
    IEnumerator RockSkill()
    {
        combo = true;
        int x = Random.Range(0, 2);
        switch (x)
        {
            case 0:
                ranim.Play("RockSkill");
                break;
            case 1:
                ranim.Play("RockAtk");
                break;
        }
        
        yield return new WaitForSeconds(5f);
        combo = false;
    }

    IEnumerator RockAtk()
    {
        combo = true;
        ranim.Play("RockAtk");
        yield return new WaitForSeconds(3f);
        combo = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.TakeDamage();
        }
    }
}
