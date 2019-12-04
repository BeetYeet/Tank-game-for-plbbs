using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDrop : MonoBehaviour
{
    public float cooldown;
    public float cooldownTimer;

    public GameObject landmine;
    public Transform drop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0)
            {
                cooldownTimer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && cooldownTimer == 0)
        {
            Instantiate(landmine, drop.position, drop.rotation);
            cooldownTimer = cooldown;
        }
    }
}
