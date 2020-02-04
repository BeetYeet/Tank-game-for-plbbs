using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSounds : MonoBehaviour
{
	public AudioSource idleSound;
	public AudioSource runningSound;
	public MoveScript move;
	public Rigidbody rb;
	float maxVel = 13f;
	[Range(0f, 1f)]
	public float volume = 1f;

	float GetEnginePower()
	{
		float vel = rb.velocity.magnitude;
		if (maxVel < vel)
			maxVel = vel;

		return vel / maxVel;
	}

	// Update is called once per frame
	void Update()
	{
		float power = GetEnginePower();
		idleSound.volume = ((1f - power) * 0.6f + 0.1f) * volume;
		runningSound.volume = (power * 0.6f + 0.1f) * volume;
	}
}
