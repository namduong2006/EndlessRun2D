using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockBoss : MonoBehaviour
{
    [SerializeField] private Animator ranim;
    [SerializeField] private Transform pler;
    private bool combo = false;
    private void Start()
    {
        ranim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveBoss();
    }

    void MoveBoss()
    {
        var kc = transform.position.x - pler.transform.position.x;
        if (kc > 0)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if (kc < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Mathf.Abs(kc) < 8f && Mathf.Abs(kc) > 3f)
        {
            if (!combo)
            {
                StartCoroutine(RockSkill());
            }
        }
        if (Mathf.Abs(kc) < 3f)
        {
            if (!combo)
            {
                StartCoroutine(RockAtk());
            }
        }
    }
    IEnumerator RockSkill()
    {
        combo = true;
        ranim.Play("RockSkill");
        yield return new WaitForSeconds(5f);
        combo = false;
    }

    IEnumerator RockAtk()
    {
        combo = true;
        ranim.Play("RockAtk");
        yield return new WaitForSeconds(3f);
        combo = false;
    }
}
