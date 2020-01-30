using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;
	int damage;
	float explosionRadius;
	public GameObject hitEffect;
	public SoundManager sm;
	public AudioClip hitSound;

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
				Debug.Log("Sphere dacay");
			}
			else
			{
				Debug.Log("Drew Sphere!");
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
			Debug.Log("Drew gizmos!");
		}
	}

	private void Start()
	{
		sm = GetComponent<SoundManager>();
	}

	public void Initialize(int damage, float explosionRadius)
	{
		this.damage = damage;
		this.explosionRadius = explosionRadius;
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
			Explode(explosionRadius, damage);
			Explode(explosionRadius / 2f, damage);
			Explode(explosionRadius / 4f, damage);
			Explode(explosionRadius / 8f, damage);
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

	private void Explode(float radius, float thisDamage)
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

		foreach (GameObject go in objectsInRange)
		{
			Health hitHealth;
			hitHealth = go.GetComponent<Health>();
			if (hitHealth != null)
			{
				hitHealth.DoDamage(Mathf.RoundToInt(thisDamage));
				Debug.Log("Hit other player indirectly for " + Mathf.RoundToInt(thisDamage));
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
