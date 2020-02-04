using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAbove : MonoBehaviour
{
	public Transform target;
	public Vector3 relativePosition = Vector3.up * 2f;
	void Update()
	{
		transform.position = target.position + relativePosition;
	}
}
