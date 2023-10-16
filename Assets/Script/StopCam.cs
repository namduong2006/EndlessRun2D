using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, 0f, -10f);
            Player.instance.SetMoveCam();
        }
    }
}
