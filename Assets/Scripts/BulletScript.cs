using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	int damage;

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
		Destroy(gameObject);
		if (hitHealth != null)
		{
			hitHealth.DoDamage(damage);
		}
	}
}
