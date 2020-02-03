using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
	public float constantDecayRate = 20f;
	[Range(0f, 1f)]
	public float linearDecayRate = .3f;

	public float rise = 1.5f;

	Light light;
	void Start()
	{
		light = GetComponent<Light>();
	}

	// Update is called once per frame
	void Update()
	{
		light.intensity = Mathf.Lerp(light.intensity, light.intensity * (1f - linearDecayRate), Time.deltaTime);
		light.intensity -= constantDecayRate;

		if (light.intensity <= 0f)
		{
			Destroy(gameObject);
			return;
		}

		transform.position += Vector3.up * rise * Time.deltaTime;
	}
}
