using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    public Health hpScript;
    void Start()
    {
        localScale = transform.localScale;
    }
    void Update()
    {
        localScale.x = hpScript.objectHealth;
        transform.localScale = localScale;
    }
}
