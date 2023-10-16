using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestroyEN : MonoBehaviour
{
    public static CheckDestroyEN instance;
    private void Awake()
    {
        instance = this;
    }
    private bool check = false;
    public bool Check()
    {
        return check;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = true;
        }
    }
}
