using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int speedUp;
    public int damageUp;
    public int healthUp;

    private int pickUpNumber = 0;

    public MovementTest move; //Refrencing the movement script

    void Start()
    {
        move = GameObject.FindObjectOfType<MovementTest>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpNumber = Random.Range(0, 2);
            Destroy(gameObject);
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
        Debug.Log("DamageUp active");
    }

    void Health() //Increases health
    {
        Debug.Log("HealthUp active");
    }
}
