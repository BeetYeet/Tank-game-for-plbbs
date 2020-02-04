using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.BaseShaderGUI;

public class PreventObscure : MonoBehaviour
{
	public LayerMask layerMask;

	public GameObject player1;
	public GameObject player2;

	float opacity = 1f;
	public float minOpacity = .5f;
	public float opacitychange = 1f;

	Material mat;

	private void Start()
	{
		mat = new Material(GetComponent<MeshRenderer>().material);
		GetComponent<MeshRenderer>().material = mat;
	}


	void Update()
	{
		if (TestObj(player1) || TestObj(player2))
		{
			FadeOut();
			if (mat.GetFloat("_Surface") == (float)SurfaceType.Opaque)
				mat.SetFloat("_Surface", (float)SurfaceType.Transparent);
			Debug.Log("Obstructing Player");
		}
		else
		{
			FadeIn();
			if (mat.GetFloat("_Surface") == (float)SurfaceType.Transparent)
				mat.SetFloat("_Surface", (float)SurfaceType.Opaque);
		}
	}

	private void FadeIn()
	{
		opacity = Mathf.Clamp(opacity - opacitychange * Time.deltaTime, minOpacity, 1f);
		Color col = mat.GetColor("_BaseColor");
		col.a = opacity;
		mat.SetColor("_BaseColor", col);
	}

	private void FadeOut()
	{
		opacity = Mathf.Clamp(opacity + opacitychange * Time.deltaTime, minOpacity, 1f);
		Color col = mat.GetColor("_BaseColor");
		col.a = opacity;
		mat.SetColor("_BaseColor", col);
	}


	bool TestObj(GameObject obj)
	{
		Ray ray = Camera.main.ScreenPointToRay(obj.transform.position);
		return Physics.Raycast(ray, 1000, layerMask);
	}
}
