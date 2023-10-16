using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WormEN : MonoBehaviour
{
    private Animator ani;
    private bool atk = true;
    [SerializeField] Transform pointshoot;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (atk)
        {
            float kcc = Mathf.Abs(transform.position.x - Player.instance.transform.position.x);
            if (kcc < 8f)
            {
                StartCoroutine(SetTimeShoot());
            }            
        }
        
    }
    private IEnumerator SetTimeShoot()
    {
        atk = false;
        float khc = Player.instance.transform.position.x - transform.position.x ;
        if(khc <= 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        ani.Play("WormATK");
        yield return new WaitForSeconds(5f);
        atk = true;
    }
    void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetBulletEN1();
        bullet.SetActive(true);
        bullet.transform.position = pointshoot.position;
        bullet.transform.rotation = Quaternion.identity;
        Rigidbody2D rbbl = bullet.GetComponent<Rigidbody2D>();
        //rbbl.gravityScale = 0f;
        float kc = Mathf.Abs(transform.position.x - Player.instance.transform.position.x);
        rbbl.velocity = pointshoot.right * kc ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.TakeDamage();
        }
    }
}
