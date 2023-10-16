using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEN : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(SetTimeOf());
    }
    private IEnumerator SetTimeOf()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            UIManager.Instance.TakeDamage();
        }
        
    }
}
