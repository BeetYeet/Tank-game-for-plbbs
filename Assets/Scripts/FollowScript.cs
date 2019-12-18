using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targ;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, 3);
    }
}
