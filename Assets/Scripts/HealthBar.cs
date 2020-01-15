using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Animator anim;
    Vector3 localScale;
    public Health hpScript;
    void Start()
    {
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        localScale.x = hpScript.objectHealth;
        transform.localScale = localScale;
    }
    public void StartAnimation()
    {
        anim.SetBool("isShot", true);
    }
    public void StopAnimation()
    {
        anim.SetBool("isShot", false);
    }
}
