using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Behemoth : MonoBehaviour
{   
    public Transform player;
    public GameObject com;
    public Vector3[] location;
    private int i = 0;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // x < 0 chua giao nhau, x>0 qua giao nhau
        
        var x = player.position.x-transform.position.x;

        // khoang cach de robot chay ve player
        if (Vector2.Distance(player.position, transform.position) < 22f)
        {           
            // toc do di chuyen cua robot

            transform.Translate(Vector2.right * Time.deltaTime);

            // x > 9 robot nhay den vi tri moi
            if (x>9f)
            {                
                i++;
                transform.position = location[i];               
            }
        }
    }   
}
