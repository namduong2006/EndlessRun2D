using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : MonoBehaviour
{
    int damage = 1;
    private void Start()
    {
        //Destroy(gameObject,1f);
        
    }
    private void Update()
    {
        StartCoroutine(SetOff());
    }
    private IEnumerator SetOff()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            enemy.ResetPosition();
        }
        if(collision.TryGetComponent<Boss>(out Boss boss))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            boss.TakeDamageOfBoss(damage);
        }
        if(collision.TryGetComponent<WormEN>(out WormEN weny))
        {
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        if(collision.TryGetComponent<Monster>(out Monster mon))
        {
            gameObject.SetActive(false);
            mon.ResetPosition();
            
        }
    }

}
