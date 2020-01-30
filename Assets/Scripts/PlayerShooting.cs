using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[Header("Bullet Stats")]
	public int bulletDamage;
	public float bulletExplosionRadius;
	public GameObject bullet;

	[Header("Shooting")]
	float currRange;
	public float startRange;
	public float range;
	public float rangeFactor;
	public float rangeChargeUp;
	public Transform shootPoint;
	public const string fireButton = "Fire_";

	[Header("Cooldown")]
	public float cooldown;
	public float currCooldown;

	[Header("Debug")]
	private bool debug = false;
	public float maxCurrRange;

	[Header("Bullet Prediction")]
	public GameObject groundPlane;
	float markerHeightAboveGround = .1f;
	public TrailRenderer bulletPrediction;
	public Light hitLight;


	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnDrawGizmos(){
		BulletScript.TriggerGizmos();
	}

	List<Vector3> GetLandingPosition(Vector3 initialSpeed, Vector3 initialPosition)
	{
		List<Vector3> result = new List<Vector3>();
		result.Add(initialPosition);

		Vector3 vel = initialSpeed;
		Vector3 pos = initialPosition;

		int counterMax = 5;
		int counter = 0;

		int breakout = 10000;
		while (breakout > 0)
		{
			breakout--;
			counter--;

			pos += vel * Time.fixedDeltaTime;
			vel += Physics.gravity * Time.fixedDeltaTime;

			if (pos.y > groundPlane.transform.position.y)
			{
				if (counter == 0)
					result.Add(pos);
			}
			else
			{
				pos.y = groundPlane.transform.position.y;
				result.Add(pos);
				break;
			}
			if (counter < 1)
			{
				counter = counterMax;
			}
		}
		if (breakout == 0)
		{
			Debug.LogError("Too long inside loop!");
		}

		return result;
	}

	void Update()
	{
		if (currCooldown > 0f)
		{
			currCooldown -= Time.deltaTime;
			if (currCooldown < 0f)
			{
				currCooldown = 0f;
				if (Input.GetButton(fireButton + gameObject.name))
				{
					StartCharge();
				}
			}
		}
		if (currCooldown == 0f && Input.GetButtonDown(fireButton + gameObject.name))
		{
			StartCharge();
		}
		if (currCooldown == 0f && Input.GetButton(fireButton + gameObject.name))
		{
			ContinueCharge();
		}
		if (currCooldown == 0f && Input.GetButtonUp(fireButton + gameObject.name) && currRange > startRange)
		{
			EndCharge();
		}
		if (debug)
		{
			if (currRange < maxCurrRange)
				maxCurrRange = currRange;
		}
	}

	private void EndCharge()
	{
		Fire();
		hitLight.enabled = false;
		bulletPrediction.enabled = false;
	}

	private void ContinueCharge()
	{
		currRange = currRange + rangeChargeUp * Time.deltaTime;
		float _ = rangeChargeUp * rangeFactor;
		currRange = Mathf.LerpUnclamped(currRange, _, Time.deltaTime);

		DisplayTrail(currRange * range);
	}

	private void StartCharge()
	{
		currRange = startRange;

		hitLight.enabled = true;
		bulletPrediction.enabled = true;
	}

	private void DisplayTrail(float velocity)
	{
		List<Vector3> path = GetLandingPosition(velocity * shootPoint.forward + rb.velocity, shootPoint.position);
		Vector3 _ = path[path.Count - 1];
		hitLight.transform.position = new Vector3(_.x, _.y + markerHeightAboveGround, _.z);


		path.Reverse();
		bulletPrediction.Clear();
		bulletPrediction.AddPositions(path.ToArray());
	}

	void Fire()
	{
		GameObject _ = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
		_.GetComponent<Rigidbody>().AddForce(shootPoint.forward * currRange * range + rb.velocity, ForceMode.VelocityChange);
		_.GetComponent<BulletScript>().Initialize(bulletDamage, bulletExplosionRadius);
		currRange = 0f;
		currCooldown = cooldown;
	}
}
