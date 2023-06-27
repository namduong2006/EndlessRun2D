using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;
    [SerializeField] private GameObject lastObject;
    [SerializeField] private Transform pl;
    private float lastDistance = 37f;
    private float platformsize = 80f;
    // Start is called before the first frame update
    private void Awake()
    {
        Instantiate(map1, Vector3.zero, Quaternion.identity);
    }
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if ((pl.transform.position.x - lastObject.transform.position.x) > lastDistance)
        {
            AddPlastForm();
        }
    }
    void AddPlastForm()
    {
        var pos=lastObject.transform.position;
        pos.x = platformsize;
        lastObject = Instantiate(map2,pos,Quaternion.identity);       
        
    }
}
