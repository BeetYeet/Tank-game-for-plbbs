using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
	Rigidbody Rbody;
	public float CurrentGasPower;
	public float BrakePower;
	public float GasLimit;
	public float GasForce;
	public float CurrentBrake;
	public float RotationPower;

	[Range(0f,1f)] public float antiDriftFactor = 0.5f;
	// Start is called before the first frame update
	void Start()
	{
		Rbody = GetComponent<Rigidbody>();
	}
	private void FixedUpdate()
	{
		Rbody.velocity -= Vector3.Project(Rbody.velocity, transform.right) * antiDriftFactor;
	}
	// Update is called once per frame
	void Update()
	{
		Rotate();
		Gas();
		Brake();
		Result();
		if (CurrentGasPower > GasLimit)
		{
			CurrentGasPower = GasLimit;
		}
		if (CurrentGasPower < GasForce)
		{
			CurrentGasPower = GasForce;
		}
		CurrentGasPower -= GasForce;

	}


	private void Brake()
	{
		if (Input.GetButton("Brake_" + gameObject.name))
		{
			CurrentBrake = BrakePower;
		}
		if (!Input.GetButton("Brake_" + gameObject.name))
		{
			CurrentBrake = 0;
		}
	}

	private void Gas()
	{
		if (Input.GetButton("Gas_" + gameObject.name))
		{
			CurrentGasPower += GasForce * 2;
		}

	}

	private void Rotate()
	{

		transform.Rotate(0, Input.GetAxisRaw("Horizontal_" + gameObject.name) * RotationPower, 0);

	}
	private void Result()
	{
		Rbody.AddRelativeForce(0, 0, CurrentGasPower + CurrentBrake);
	}
}
