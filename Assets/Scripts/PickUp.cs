using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    public int speedUp;
    public int damageUp;
    public int healthUp;

    private int pickUpNumber = 0;

    //Refrencing the scripts
    public MovementTest move;
    public PlayerShooting hurt;
    public Health health;

    void Start()
    {
        move = GameObject.FindObjectOfType<MovementTest>();
        hurt = GameObject.FindObjectOfType<PlayerShooting>();
        health = GameObject.FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pickUpNumber = Random.Range(0, 3);
            Destroy(gameObject);
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
            Health();
        }
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

    void Health() //Increases health
    {
        health.objectHealth += healthUp;
        Debug.Log("HealthUp active");
    }

    void ShowUpgrade()
    {
        Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
}
