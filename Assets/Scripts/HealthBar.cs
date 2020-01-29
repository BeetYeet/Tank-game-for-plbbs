using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Animator anim;
    Vector2 scaleFactor;
    public Health hpScript;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        scaleFactor = sr.size;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float _ = hpScript.health / (float)hpScript.maxHealth;
        sr.size = new Vector2(_ * scaleFactor.x, scaleFactor.y);
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
