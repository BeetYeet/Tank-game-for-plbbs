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

	public int speedUp;
	public int damageUp;
	public int healthUp;

	public int pickUpNumber;
	public GameObject floatingTextPrefab;

	//Refrencing the scripts
	public MoveScript move;
	public PlayerShooting hurt;


	private void Start()
	{
		//SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
		move = GameObject.FindObjectOfType<MoveScript>();
		hurt = GameObject.FindObjectOfType<PlayerShooting>();
	}

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


	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Pickup")
		{
			pickUpNumber = Random.Range(0, 3);
		}

		if (floatingTextPrefab)
		{
			ShowUpgrade();
		}

		if (pickUpNumber == 0)
		{
			Speed();
		}
		else if (pickUpNumber == 1)
		{
			Damage();
		}
		else if (pickUpNumber == 2)
		{
			HealthUp();
		}
	}

	void ShowUpgrade()
	{
		var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
		if (pickUpNumber == 0)
		{
			go.GetComponent<TextMesh>().text = "Speed Up";

		}
		else if (pickUpNumber == 1)
		{
			go.GetComponent<TextMesh>().text = "Damage Up";

		}
		else if (pickUpNumber == 2)
		{
			go.GetComponent<TextMesh>().text = "Health Up";

		}
	}
	void Speed() //Increases Speed
	{
		move.gasForce += speedUp;
		Debug.Log("SpeedUp active");
	}

	void Damage() //Increases Damage
	{
		hurt.bulletDamageBonus += damageUp;
		Debug.Log("DamageUp active");
	}

	void HealthUp() //Increases health
	{
		health += healthUp;
		Debug.Log("HealthUp active");
	}

}
