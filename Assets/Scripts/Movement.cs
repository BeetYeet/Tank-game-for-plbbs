using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.velocity = transform.forward * -moveSpeed / 2;
        }
        if (Input.GetButton("Jump"))
        {
            rb.velocity = transform.forward * moveSpeed;
        }

        transform.Rotate(Vector3.up, 3 * Input.GetAxis("Horizontal"));
    }
}
