using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	public Color playerColor;
	public Color damagecolor;
	public MeshRenderer mr;
	Material mat;

	public int materialIndex = 0;
	void Start()
	{
		mr = GetComponent<MeshRenderer>();
		mr.materials[materialIndex] = new Material(mr.materials[materialIndex]);
		mat = mr.materials[materialIndex];
	}

	// Update is called once per frame
	void Update()
	{
		mat.SetColor("_BaseColor", playerColor * damagecolor);
	}
}
