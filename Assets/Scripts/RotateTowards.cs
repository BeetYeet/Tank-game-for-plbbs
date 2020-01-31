using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{

    void Update()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Camera.main.transform.up);
        transform.rotation = rotation;
    }
}
