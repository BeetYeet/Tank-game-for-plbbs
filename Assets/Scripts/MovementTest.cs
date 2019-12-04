using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public int moveSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.velocity = transform.forward * moveSpeed;
        }

        if (Input.GetButton("Jump"))
        {
            rb.velocity = transform.forward * -moveSpeed / 2;
        }

        transform.Rotate(Vector3.up, 3 * Input.GetAxis("Horizontal"));
    }
}
