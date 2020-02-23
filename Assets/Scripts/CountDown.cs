using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	public int startAt = 3;
	Image text;
	float timer;

	public List<Sprite> sprites = new List<Sprite>();
	public float startStayTime = 2f;

	void Start()
	{
		timer = startAt;
		text = GetComponent<Image>();
	}
	void LateUpdate()
	{
		if (Time.timeScale == Mathf.Epsilon)
		{
			text.sprite = null;
			text.color = new Color(1, 1, 1, 0);
			return;
		}
		else
		{
			text.color = new Color(1, 1, 1, 1);
		}
		timer -= Time.deltaTime;
		int v = Mathf.RoundToInt(Mathf.CeilToInt(timer));
		int index = v < 0 ? 0 : v;

		text.sprite = sprites[index];
		text.SetNativeSize();
		if (index == 0)
		{
			GameController.gameIsInAction = true;
			Destroy(transform.root.gameObject, startStayTime);
		}
	}
}
