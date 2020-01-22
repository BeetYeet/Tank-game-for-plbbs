using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
	Rigidbody Rbody;

	float gasForce;
	public float gasIncrease = 2;
	public float gasMax = 10;

	public float linearBrakeForce = .5f;
	public float constantBrakeForce = 1;

	float reverseForce;
	public float reverseIncrease = 3;
	public float reverseMax = 5;

	public float rotationPower;

	[Range(0f, 1f)] public float antiDriftFactor = 0.5f;

	void Start()
	{
		Rbody = GetComponent<Rigidbody>();
	}
	private void FixedUpdate()
	{


		Vector3 forwardVelocity = Vector3.Project(Rbody.velocity, transform.forward);
		if (Input.GetButton("Brake_" + gameObject.name))
		{
			if (forwardVelocity.magnitude > 0f)
			{

				if (forwardVelocity.magnitude * linearBrakeForce + constantBrakeForce > forwardVelocity.magnitude)
				{
					Rbody.velocity -= forwardVelocity * linearBrakeForce + forwardVelocity.normalized * constantBrakeForce;
				}
				else
				{
					Rbody.velocity -= forwardVelocity;

				}

			}
		}


		if (Input.GetButton("Gas_" + gameObject.name))
		{

		}

		Rbody.velocity -= Vector3.Project(Rbody.velocity, transform.right) * antiDriftFactor;
	}

	private void Rotate()
	{

		transform.Rotate(0, Input.GetAxisRaw("Horizontal_" + gameObject.name) * rotationPower, 0);

	}
}
