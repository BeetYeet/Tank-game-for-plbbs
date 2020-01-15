using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    public int objectHealth;
    public SoundManager sSource;
    public AudioClip hitSound1;
    public AudioClip hitSound2;

    public int pickUpNumber = 0;
    public PickUp pick;
    public MovementTest move;
    public PlayerShooting hurt;
    public Health health;

    public int speedUp;
    public int damageUp;
    public int healthUp;

    private void Start()
    {
        //SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        pick = GameObject.FindObjectOfType<PickUp>();
        move = GameObject.FindObjectOfType<MovementTest>();
        hurt = GameObject.FindObjectOfType<PlayerShooting>();
        health = GameObject.FindObjectOfType<Health>();
    }

    void Update()
    {
        if (objectHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            pickUpNumber = Random.Range(0, 3);
            if (floatingTextPrefab)
            {
                ShowUpgrade();
            }
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

    public void DoDamage(int damage)
    {
        objectHealth -= damage;
        SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
    }

    void Speed() //Increases Speed
    {
        move.moveSpeed += speedUp;
        Debug.Log("SpeedUp active");
    }

    void Damage() //Increases Damage
    {
        hurt.bulletDamage += damageUp;
        Debug.Log("DamageUp active");
    }

    void HealthUp() //Increases health
    {
        health.objectHealth += healthUp;
        Debug.Log("HealthUp active");
    }

    void ShowUpgrade()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up), transform);

        if (pickUpNumber == 0)
        {
            go.GetComponent<TextMesh>().text = "SpeedUp";
        }
        else if (pickUpNumber == 1)
        {
            go.GetComponent<TextMesh>().text = "DamageUp";
        }
        else if (pickUpNumber == 2)
        {
            go.GetComponent<TextMesh>().text = "HealthUp";
        }
    }
}
