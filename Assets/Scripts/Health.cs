using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
	public int objectHealth;
	public SoundManager sSource;
	public AudioClip hitSound1;
	public AudioClip hitSound2;
    public HealthBar hpBar;
	private void Start()
	{
		//SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
	}

	void Update()
	{
		if (objectHealth <= 0)
		{
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
            DoDamage(1);
		}
	}

	public void DoDamage(int damage)
	{
		objectHealth -= damage;
		SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        hpBar.StartAnimation();
	}
}