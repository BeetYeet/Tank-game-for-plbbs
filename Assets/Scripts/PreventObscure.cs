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
	Material originalMat;
	MeshRenderer mr;

	private void Start()
	{
		mr = GetComponent<MeshRenderer>();
		mat = new Material(mr.material);
		mat.SetFloat("_Surface", (float)SurfaceType.Transparent);
		mat.EnableKeyword("_ALPHABLEND_ON");
		mat.DisableKeyword("_SPECGLOSSMAP");
		originalMat = mr.material;
	}


	void Update()
	{
		if (TestObj(player1) || TestObj(player2))
		{
			Debug.Log("Fading out");
			FadeOut();
		}
		else
		{
			Debug.Log("Fading in");
			FadeIn();
		}
	}

	private void FadeIn()
	{
		opacity = Mathf.Clamp(opacity + opacitychange * Time.deltaTime, minOpacity, 1f);
		Color col = mat.GetColor("_BaseColor");
		col.a = opacity;
		mat.SetColor("_BaseColor", col);
		if (opacity == 1f)
		{
			mr.material = originalMat;
		}
	}

	private void FadeOut()
	{
		opacity = Mathf.Clamp(opacity - opacitychange * Time.deltaTime, minOpacity, 1f);
		Color col = mat.GetColor("_BaseColor");
		col.a = opacity;
		mat.SetColor("_BaseColor", col);
		mr.material = mat;
	}


	bool TestObj(GameObject obj)
	{
		Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(obj.transform.position));
		return Physics.Raycast(ray, 1000, layerMask);
	}
}
