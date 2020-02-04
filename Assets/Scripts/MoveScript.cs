using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
	Rigidbody Rbody;

	public float gasForce;
	public float gasFalloff;

	public float reverseForce;
	public float reverseFalloff;

	public float rotationPower;
	[Range(0f, 1f)]
	public float aimRotationFactor = 0.5f;

	[Range(0f, 1f)] public float antiDriftFactor = 0.5f;

	void Start()
	{
		Rbody = GetComponent<Rigidbody>();
	}
	private void FixedUpdate()
	{

		if (!GameController.gameIsInAction)
			return;

		transform.Rotate(0, Input.GetAxisRaw("Horizontal_" + gameObject.name) * rotationPower * (Input.GetButton("Fire_" + gameObject.name) ? aimRotationFactor : 1f), 0);


		Vector3 forwardVelocity = Vector3.Project(Rbody.velocity, transform.forward);
		Debug.DrawRay(transform.position, forwardVelocity);
		if (Input.GetButton("Brake_" + gameObject.name))
		{
			Rbody.AddForce(-transform.forward * Time.fixedDeltaTime * Mathf.Clamp(reverseForce - Rbody.velocity.magnitude * reverseFalloff, 0f, Mathf.Infinity), ForceMode.VelocityChange);
		}

		if (Input.GetButton("Gas_" + gameObject.name))
		{
			Rbody.AddForce(transform.forward * Time.fixedDeltaTime * Mathf.Clamp(gasForce - Rbody.velocity.magnitude * gasFalloff, 0f, Mathf.Infinity), ForceMode.VelocityChange);
		}



		Vector3 sidewardVelocity = Vector3.Project(Rbody.velocity, transform.right);
		Rbody.velocity -= sidewardVelocity * antiDriftFactor;
		Debug.DrawRay(transform.position, sidewardVelocity * (1 - antiDriftFactor));


	}
}
