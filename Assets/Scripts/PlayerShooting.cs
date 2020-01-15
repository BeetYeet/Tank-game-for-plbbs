using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public int bulletDamage;
	public float startRange;
	public float range;
	public float rangeFactor;
	public float rangeChargeUp;
	float currRange;
	public float cooldown;
	float currCooldown;

	public GameObject bullet;
	public Transform shootPoint;
	public string fireButton = "Fire1";

	private bool debug = false;
	public float maxCurrRange;

	public GameObject groundPlane;
	float markerHeightAboveGround = .1f;
	public TrailRenderer bulletPrediction;
	public Light hitLight;

	void Start()
	{

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
				if (Input.GetButton(fireButton))
				{
					StartCharge();
				}
			}
		}
		if (currCooldown == 0f && Input.GetButtonDown(fireButton))
		{
			StartCharge();
		}
		if (currCooldown == 0f && Input.GetButton(fireButton))
		{
			ContinueCharge();
		}
		if (currCooldown == 0f && Input.GetButtonUp(fireButton))
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
		List<Vector3> path = GetLandingPosition(velocity * shootPoint.forward, shootPoint.position);
		Vector3 _ = path[path.Count - 1];
		hitLight.transform.position = new Vector3(_.x, _.y + markerHeightAboveGround, _.z);


		path.Reverse();
		bulletPrediction.Clear();
		bulletPrediction.AddPositions(path.ToArray());
	}

	void Fire()
	{
		GameObject _ = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
		_.GetComponent<Rigidbody>().AddForce(shootPoint.forward * currRange * range, ForceMode.VelocityChange);
		_.GetComponent<BulletScript>().Initialize(bulletDamage);
		currRange = 0f;
		currCooldown = cooldown;
	}
}
