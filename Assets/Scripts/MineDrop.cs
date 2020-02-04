using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineDrop : MonoBehaviour
{
	public float cooldown;
	float cooldownTimer;

	public GameObject landmine;
	public Transform drop;

	public Image mineCooldownImage;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		mineCooldownImage.fillAmount = cooldownTimer / cooldown;


		if (!GameController.gameIsInAction)
			return;

		if (cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer <= 0)
			{
				cooldownTimer = 0;
			}
		}

		if (Input.GetButtonDown("Mine_" + gameObject.name) && cooldownTimer == 0)
		{
			Debug.Log("Placed Mine");
			Instantiate(landmine, drop.position, drop.rotation);
			cooldownTimer = cooldown;
		}

	}
}
