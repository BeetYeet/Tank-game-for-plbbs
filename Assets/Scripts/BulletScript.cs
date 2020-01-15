using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Rigidbody rb;
    int damage;
    public GameObject hitEffect;
    public GameObject nullHitEffect;
    public SoundManager sm;
    public AudioClip hitSound;
    private void Start()
    {
        sm = GetComponent<SoundManager>();
    }

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    private void Update()
    {
        transform.LookAt(transform.position + rb.velocity, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health hitHealth = collision.gameObject.GetComponent<Health>();
        if (hitHealth != null)
        {
            hitHealth.DoDamage(damage);
        }
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(nullHitEffect, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        SoundManager.instance.PlaySingle(hitSound);
    }
}