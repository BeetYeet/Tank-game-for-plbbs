using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	int damage;
	float explosionRadius;
	AnimationCurve falloff;
	public GameObject hitEffect;
	public SoundManager sm;
	public AudioClip hitSound;
	private void Start()
	{
		sm = GetComponent<SoundManager>();
	}

	public void Initialize(int damage, float explosionRadius, AnimationCurve falloff)
	{
		this.damage = damage;
		this.explosionRadius = explosionRadius;
		this.falloff = falloff;
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
			Debug.Log("Hit other player directly for " + damage + " damage!");
		}
		else
		{
			List<GameObject> objectsInRange = new List<GameObject>();
			Physics.OverlapSphere(transform.position, explosionRadius).ToList().ForEach(
			x =>
			{
				if (!objectsInRange.Contains(x.transform.root.gameObject))
				{
					objectsInRange.Add(x.transform.root.gameObject);
				}
			});

			foreach (GameObject go in objectsInRange)
			{
				hitHealth = go.GetComponent<Health>();
				if (hitHealth != null)
				{
					float distance = Mathf.Clamp01(1 - (transform.position - go.transform.position).magnitude / explosionRadius);
					float thisDamage = falloff.Evaluate(distance) * 0.8f * damage;
					hitHealth.DoDamage(Mathf.RoundToInt(thisDamage));
					Debug.Log("Hit other player indirectly for " + thisDamage + " damage!\n(distance of " + (transform.position - go.transform.position).magnitude + " standing for a part of the radius equal to " + (transform.position - go.transform.position).magnitude / explosionRadius + " and a portion of damage equal to" + falloff.Evaluate(distance) * 0.8f + ")");
				}
			}
		}
		Destroy(gameObject);
		Instantiate(hitEffect, transform.position, transform.rotation);
		if (SoundManager.instance == null)
		{
			Debug.LogError("No SoundManager, please make one!");
		}
		else
			SoundManager.instance.PlaySingle(hitSound);

	}
}
