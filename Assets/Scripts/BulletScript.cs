using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	public int damage = 10;
	public float explosionRadius = 7f;
	public float explosionKnockback = 100f;
	public float explosionKnockbackRadius = 10f;
	public GameObject hitEffect;
	public SoundManager sm;
	public AudioClip hitSound;
	public GameObject explosionLight;

	public float power = 1f;

	static List<DebugSphere> debugSpheres = new List<DebugSphere>();
	static float lastGizmoDraw = 0;

	private static void DrawGizmos()
	{
		lastGizmoDraw = Time.time;
		List<DebugSphere> _ = new List<DebugSphere>();
		debugSpheres.ForEach(x =>
		{
			if (x.decayTime < Time.time)
			{
				_.Add(x);
				//Debug.Log("Sphere dacay");
			}
			else
			{
				//Debug.Log("Drew Sphere!");
				Gizmos.color = x.color * new Vector4(1f, 1f, 1f, 0.4f);
				Gizmos.DrawSphere(x.pos, x.radius);
			}
		});

		_.ForEach(x =>
		{
			debugSpheres.Remove(x);
		});

	}

	public static void TriggerGizmos()
	{
		if (lastGizmoDraw < Time.time)
		{
			DrawGizmos();
			//Debug.Log("Drew gizmos!");
		}
	}

	private void Start()
	{
		sm = GetComponent<SoundManager>();
		transform.localScale *= Mathf.Sqrt(power);
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
			hitHealth.DoDamage(damage * 5);
			Push(collision.rigidbody, explosionKnockback * 1.5f);
			Debug.Log("Hit other player directly for " + damage * 5 + " damage!");
		}
		else
		{
			int hits = 0;
			for (int i = 0; i < 4; i++)
			{
				if (Explode(explosionRadius / Mathf.Pow(2f, i), damage))
				{
					hits++;
				}
			}
			if (hits != 0)
				Debug.Log("Hit other player indirectly for " + damage * hits);
		}
		Destroy(gameObject);
		Instantiate(hitEffect, transform.position, transform.rotation);
		if (SoundManager.instance == null)
		{
			Debug.LogError("No SoundManager, please make one!");
		}
		else
			SoundManager.instance.PlaySingle(hitSound);
		GameObject _ = Instantiate(explosionLight, transform.position, Quaternion.identity);
		_.GetComponent<Light>().intensity *= power;
	}

	void Push(Rigidbody rigid, float force)
	{
		rigid.AddExplosionForce(force * power, transform.position, explosionKnockbackRadius);
	}


	private bool Explode(float radius, float thisDamage)
	{
		List<GameObject> objectsInRange = new List<GameObject>();
		debugSpheres.Add(new DebugSphere(transform.position, radius, Color.red, Time.time + 3f));
		Physics.OverlapSphere(transform.position, radius).ToList().ForEach(
		x =>
		{
			if (!objectsInRange.Contains(x.transform.root.gameObject))
			{
				objectsInRange.Add(x.transform.root.gameObject);
			}
		});
		bool hit = false;
		foreach (GameObject go in objectsInRange)
		{
			Health hitHealth;
			hitHealth = go.GetComponent<Health>();
			if (hitHealth != null)
			{
				hitHealth.DoDamage(Mathf.RoundToInt(thisDamage));
				Push(go.GetComponent<Rigidbody>(), explosionKnockback);
				hit = true;
			}
		}
		return hit;
	}

	struct DebugSphere
	{
		public Vector3 pos;
		public float radius;
		public Color color;
		public float decayTime;

		public DebugSphere(Vector3 pos, float radius, Color color, float decayTime)
		{
			this.pos = pos;
			this.radius = radius;
			this.color = color;
			this.decayTime = decayTime;
		}
	}
}
