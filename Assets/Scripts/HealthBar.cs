using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public Animator anim;
	Vector3 localScale;
	float scaleFactor;
	public Health hpScript;
	void Start()
	{
		localScale = transform.localScale;
		scaleFactor = transform.localScale.x;
		anim = GetComponent<Animator>();
	}
	void Update()
	{
		localScale.x = scaleFactor * hpScript.health / hpScript.maxHealth;
		transform.localScale = localScale;
		float _ = hpScript.health / (float)hpScript.maxHealth;
		Debug.Log(_);
		transform.localPosition = -Vector3.right * _;
	}
	public void StartAnimation()
	{
		anim.SetBool("isShot", true);
	}
	public void StopAnimation()
	{
		anim.SetBool("isShot", false);
	}
}
