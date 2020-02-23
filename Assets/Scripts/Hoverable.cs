using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hoverable : MonoBehaviour
{
	Animator anim;
	public AudioSource hoverSound;
	public AudioSource clickSound;
	void Awake()
	{
		anim = GetComponent<Animator>();
		if (hoverSound != null)
		{
			hoverSound.Stop();
			hoverSound.ignoreListenerPause = true;
		}

		if (clickSound != null)
		{
			clickSound.Stop();
			clickSound.ignoreListenerPause = true;
		}
	}

	public void Hover()
	{
		if (Time.timeSinceLevelLoad > .01f)
		{
			float scale = Time.timeScale;
			Time.timeScale = 1;
			hoverSound.Play();
			Time.timeScale = scale;
		}
		anim.SetBool("IsHovered", true);
	}
	public void DeHover()
	{
		anim.SetBool("IsHovered", false);
	}

	public void PlayClickSound()
	{
		float scale = Time.timeScale;
		Time.timeScale = 1;
		clickSound.Play();
		Time.timeScale = scale;
	}
}
