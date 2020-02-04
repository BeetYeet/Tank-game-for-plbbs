using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
	public GameObject prefab;
	GameObject spawned;
	bool exists = true;

	public float respawnMinimum = 5f;
	public float respawnMaximum = 10f;

	float timer = 0f;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!spawned && exists)
		{
			exists = false;
			timer = Random.Range(respawnMinimum, respawnMaximum);
		}
		if (!exists && timer > 0f)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				timer = 0f;
				spawned = Instantiate(prefab, transform.position, transform.rotation);
				exists = true;
			}
		}
	}
}
