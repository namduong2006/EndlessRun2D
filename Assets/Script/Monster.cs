using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool shoot = true;    
    [SerializeField] Transform pointShoot;
    void Update()
    {
        SetMonster();
        
    }
    void SetMonster()
    {
        if (shoot == true)
        {
            StartCoroutine(SetTimeShoot());
        }
        // van toc di chuyen va huy sau 5s
        transform.Translate(Vector2.left *3f * Time.deltaTime);
        Vector2 vitri = Camera.main.WorldToScreenPoint(transform.position);       
        if(vitri.x < 0)
        {
            if (CheckDestroyEN.instance.Check() == false)
            {
                ResetPosition();
            }
            else
            {
                Destroy(gameObject);
            }
        }      
    }
    public void ResetPosition()
    {
        int x = Random.Range(1, 5);
        transform.position = new Vector2(Camera.main.transform.position.x + 15f + x, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.TakeDamage();
        }
    }
    private IEnumerator SetTimeShoot()
    {
        shoot = false;
        GameObject blshoot = ObjectPool.instance.GetBulletEN1();
        blshoot.SetActive(true);
        blshoot.transform.position = pointShoot.position;
        Rigidbody2D rbbl = blshoot.GetComponent<Rigidbody2D>();
        rbbl.velocity = pointShoot.right * 5f;
        float t = Random.Range(1.5f, 3f);
        yield return new WaitForSeconds(t);
        shoot = true;
    }
}
