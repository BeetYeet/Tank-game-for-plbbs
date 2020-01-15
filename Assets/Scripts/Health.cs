using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
	public int health;
	public int maxHealth;

	public AudioClip hitSound1;
	public AudioClip hitSound2;
    public HealthBar hpBar;
	private void Start()
	{
		health = maxHealth;
		//SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
	}

	void Update()
	{
		if (health <= 0)
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
		health -= damage;
		SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        hpBar.StartAnimation();
	}
}