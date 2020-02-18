using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hoverable : MonoBehaviour
{
	Button button;
	Animator anim;
	void Start()
	{
		button = GetComponent<Button>();
		anim = GetComponent<Animator>();
	}

	public void Hover()
	{
		anim.SetBool("IsHovered", true);
	}
	public void DeHover()
	{
		anim.SetBool("IsHovered", false);
	}
}
