using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
	public int startAt = 3;
	TextMeshProUGUI text;
	float timer;

	public string startText = "GO!!";
	public float startStayTime = 2f;

	void Start()
	{
		timer = startAt;
		text = GetComponent<TextMeshProUGUI>();
	}
	void LateUpdate()
	{
		if(Time.timeScale == 0f){
			text.text = "";
			return;
		}
		timer -= Time.deltaTime;
		text.text = Mathf.CeilToInt(timer).ToString();
		if (timer <= 0f)
		{
			text.text = startText;
			GameController.gameIsInAction = true;
			Destroy(transform.root.gameObject, startStayTime);
		}
	}
}
