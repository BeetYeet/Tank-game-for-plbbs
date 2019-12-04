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

	void Start()
	{

	}

	void Update()
	{
		if (currCooldown > 0f)
		{
			currCooldown -= Time.deltaTime;
			if (currCooldown < 0f)
			{
				currCooldown = 0f;
			}
		}
		if (currCooldown == 0f && Input.GetButtonDown(fireButton))
		{
			currRange = startRange;
		}
		if (currCooldown == 0f && Input.GetButton(fireButton))
		{
			currRange = currRange + rangeChargeUp * Time.deltaTime;
			float _ = rangeChargeUp * rangeFactor;
			currRange = Mathf.LerpUnclamped(currRange, _, Time.deltaTime);
		}
		if (currCooldown == 0f && Input.GetButtonUp(fireButton))
		{
			Fire();
		}
	}

	void Fire()
	{
		GameObject _ = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
		_.GetComponent<Rigidbody>().AddForce(shootPoint.forward * currRange * range);
		_.GetComponent<BulletScript>().Initialize(bulletDamage);
		currRange = 0f;
		currCooldown = cooldown;
	}
}
