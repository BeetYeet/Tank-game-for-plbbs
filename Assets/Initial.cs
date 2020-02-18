using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Initial : MonoBehaviour
{
	Button button;
	private void Awake()
	{
		button = GetComponent<Button>();
	}
	void OnEnable()
	{
		button.Select();
		button.OnSelect(null);
		GetComponent<Hoverable>().Hover();
	}
}
