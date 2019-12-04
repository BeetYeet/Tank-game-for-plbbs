using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public int damage;

    public float timer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer != 0f)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                timer = 0f;
            }
        }
        else
        {
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                    hit.collider.gameObject.GetComponent<Health>().DoDamage(damage);
                }
            }
        }
    }

}
