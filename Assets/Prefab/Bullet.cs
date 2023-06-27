using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Computer"))
            return;
        if (collision.gameObject.CompareTag("Untagged")) { Destroy(gameObject); }
    }
}
