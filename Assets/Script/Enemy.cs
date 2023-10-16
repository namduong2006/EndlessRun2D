using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{     
    void Start()
    {
        //Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
        Vector2 vt = Camera.main.WorldToScreenPoint(transform.position);
        if(transform.position.y < -4f || vt.x < 0)
        {
            if(CheckDestroyEN.instance.Check() == false)
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
        transform.position = new Vector2(Camera.main.transform.position.x + 20f + x,5f);
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            UIManager.Instance.TakeDamage();
            ResetPosition();
        }
    }
}
