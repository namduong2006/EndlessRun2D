using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject blEN1;
    [SerializeField] private GameObject blEN2;
    [SerializeField] private GameObject phitieu;
    private List<GameObject> bulletEN1 = new List<GameObject>();
    private List<GameObject> bulletEN2 = new List<GameObject>();
    private List<GameObject> bulletpt = new List<GameObject>();
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        door.SetActive(false);
        for(int i = 0; i<1; i++)
        {
            GameObject blen1 = Instantiate(blEN1);
            blen1.SetActive(false);
            bulletEN1.Add(blen1);
        }
        for(int j = 0; j<1; j++)
        {
            GameObject blen2 = Instantiate(blEN2);
            blen2.SetActive(false);
            bulletEN2.Add(blen2);
        }
        for(int p =0; p <1; p++)
        {
            GameObject pt = Instantiate(phitieu);
            pt.SetActive(false);
            bulletpt.Add(pt);
        }
    }   
    public GameObject GetPhitieu()
    {
        for(int p = 0; p< bulletpt.Count; p++)
        {
            if (!bulletpt[p].activeInHierarchy)
            {
                return bulletpt[p];
            }
        }
        GameObject newpt = Instantiate(phitieu);
        newpt.SetActive(false);
        bulletpt.Add(newpt);
        return newpt;
    }
    public void OnDoor()
    {
        door.SetActive(true);
    }
    public GameObject GetBulletEN1()
    {
        for(int i=0; i < bulletEN1.Count; i++)
        {
            if (!bulletEN1[i].activeInHierarchy)
            {
                //bulletEN1[i].SetActive(true);
                return bulletEN1[i];
            }
        }
        GameObject newblen1 = Instantiate(blEN1);
        newblen1.SetActive(false);
        bulletEN1 .Add(newblen1);
        return newblen1;
    }
    public GameObject GetBulletEN2()
    {
        for (int j = 0; j < bulletEN2.Count; j++)
        {
            if (!bulletEN2[j].activeInHierarchy)
            {
                //bulletEN1[i].SetActive(true);
                return bulletEN2[j];
            }
        }
        GameObject newblen2 = Instantiate(blEN2);
        newblen2.SetActive(false);
        bulletEN2.Add(newblen2);
        return newblen2;
    }
}
