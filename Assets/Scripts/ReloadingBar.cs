using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingBar : MonoBehaviour
{
    public Vector3 localScale;
    public PlayerShooting playerShooting;
    public Animator anim;
    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = playerShooting.currCooldown * 3;
        transform.localScale = localScale;
        if (playerShooting.currCooldown > 0 && Input.GetButton(PlayerShooting.fireButton))
        {
            StartAnimation();
        }
    }

    private void StartAnimation()
    {
        anim.SetBool("shootingDenied", true);
    }
    public void StopAnimation()
    {
        anim.SetBool("shootingDenied", false);
    }
}