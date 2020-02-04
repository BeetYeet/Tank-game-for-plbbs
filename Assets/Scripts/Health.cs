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





	void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
		}
		if (health > maxHealth)
		{
			health = maxHealth;
		}
	}

	public void DoDamage(int damage)
	{
		health -= damage;
		GetComponent<Animator>().SetTrigger("Damage");
		SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
	}



}
