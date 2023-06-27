using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform cm;

    // Start is called before the first frame update
    void Start()
    {
           
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 bg = new Vector3(cm.transform.position.x,2.43f,1f);
        transform.position = bg;
    }
}
