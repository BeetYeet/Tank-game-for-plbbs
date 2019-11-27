using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	float damage;

	public void Initialize(float damage)
	{
		this.damage = damage;
	}

	private void Update()
	{
		transform.LookAt(transform.position + rb.velocity, Vector3.up);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
