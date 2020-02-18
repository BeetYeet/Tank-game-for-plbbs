using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	public GameObject hitEffect;
	public SoundManager sm;
	public AudioClip hitSound;
	public GameObject explosionLight;

	[SerializeField]
	public BulletInfo stats;

	[System.Serializable]
	public struct BulletInfo
	{
		public int damage;
		public float explosionRadius;
		public float explosionKnockback;
		public float explosionKnockbackRadius;
		public float power;
		public BulletInfo(int damage, float explosionRadius, float explosionKnockback, float explosionKnockbackRadius, float power)
		{
			this.damage = damage;
			this.explosionRadius = explosionRadius;
			this.explosionKnockback = explosionKnockback;
			this.explosionKnockbackRadius = explosionKnockbackRadius;
			this.power = power;
		}
	}


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
		transform.localScale *= Mathf.Sqrt(stats.power);
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
			hitHealth.DoDamage(stats.damage * 5);
			Push(collision.rigidbody, stats.explosionKnockback * 1.5f, stats.explosionKnockbackRadius);
			Debug.Log("Hit other player directly for " + stats.damage * 5 + " damage!");
		}
		else
		{
			int hits = 0;
			for (int i = 0; i < 4; i++)
			{
				if (Explode(stats.explosionRadius / Mathf.Pow(2f, i), stats.damage))
				{
					hits++;
				}
			}
			if (hits != 0)
				Debug.Log("Hit other player indirectly for " + stats.damage * hits);
		}
		PropExplode();
		GameObject _ = Instantiate(hitEffect, transform.position, transform.rotation);
		ParticleSystem.MainModule main = _.GetComponent<ParticleSystem>().main;
		main.startLifetime = new ParticleSystem.MinMaxCurve(stats.power * stats.power / 9f, stats.power * stats.power / 6f);
		if (SoundManager.instance == null)
		{
			Debug.LogError("No SoundManager, please make one!");
		}
		else
			SoundManager.instance.RandomizeSfx(hitSound);
		_ = Instantiate(explosionLight, transform.position, Quaternion.identity);
		_.GetComponent<Light>().intensity *= stats.power;
		Destroy(gameObject);
	}

	void Push(Rigidbody rigid, float force, float radius)
	{
		rigid.AddExplosionForce(force * stats.power, transform.position, radius);
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
				Push(go.GetComponent<Rigidbody>(), stats.explosionKnockback, stats.explosionKnockbackRadius);
				hit = true;
			}
		}
		return hit;
	}


	void PropExplode()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, stats.explosionKnockbackRadius * 2f);
		foreach (Collider c in cols)
		{
			Rigidbody rb = c.transform.root.GetComponent<Rigidbody>();
			if (rb != null)
			{
				Push(rb, stats.explosionKnockback / 50f, stats.explosionKnockbackRadius * 2f);
			}
		}
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
