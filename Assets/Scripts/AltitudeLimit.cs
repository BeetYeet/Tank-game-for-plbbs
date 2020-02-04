using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeLimit : MonoBehaviour
{

	public float maxAltitude = 50;
	public float minAltitude = -10;
	void Update()
	{
		if (transform.position.y > maxAltitude || transform.position.y < minAltitude)
		{
			Health h = GetComponent<Health>();
			if (h)
			{
				h.health = 0;
				return;
			}
			Destroy(gameObject);
		}
	}
}
