using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hoverable : MonoBehaviour
{
	Animator anim;
	public AudioClip hoverSound;
	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void Hover()
	{
		if (Time.timeSinceLevelLoad > .01f)
			GetComponent<AudioSource>().PlayOneShot(hoverSound);
		anim.SetBool("IsHovered", true);
	}
	public void DeHover()
	{
		anim.SetBool("IsHovered", false);
	}
}
