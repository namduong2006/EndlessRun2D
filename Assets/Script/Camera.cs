using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    public Transform player;
    private void Update()
    {
        Vector3 cam = new Vector3(player.transform.position.x+5f, 0f, -10f);
        //cam.x = Mathf.Clamp(cam.x,9f,116f);
        transform.position = cam;
    }
}
