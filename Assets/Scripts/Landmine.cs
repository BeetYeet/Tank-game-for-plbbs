using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public int damage;

    public float timer;
	float timerMax;

	public UnityEngine.UI.Image timerImage;

    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
		timerMax = timer;
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
				Destroy(timerImage.canvas.gameObject);
            }
			timerImage.fillAmount = timer / timerMax;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer == 0f)
        {
            if (other.gameObject.tag == "Player")
            {
                Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                other.gameObject.GetComponent<Health>().DoDamage(damage);
                
            }
        }
    }

}
