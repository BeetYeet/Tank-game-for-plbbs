using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{
	Button button;
	static bool hasTakenInputThisFrame = false;
	void Start()
	{
		button = GetComponent<Button>();
	}

	private void Update()
	{
		hasTakenInputThisFrame = false;
	}
	void LateUpdate()
	{
		if (hasTakenInputThisFrame || EventSystem.current.currentSelectedGameObject != gameObject)
			return;
		if (Input.GetButtonDown("Gas_P1") || Input.GetButtonDown("Gas_P2"))
		{
			if (button.navigation.selectOnUp != null)
				EventSystem.current.SetSelectedGameObject(button.navigation.selectOnUp.gameObject);
			//Debug.Log("Button Up");
		}

		if (Input.GetButtonDown("Brake_P1") || Input.GetButtonDown("Brake_P2"))
		{
			if (button.navigation.selectOnDown != null)
				EventSystem.current.SetSelectedGameObject(button.navigation.selectOnDown.gameObject);
			//Debug.Log("Button Down");
		}
		hasTakenInputThisFrame = true;
	}

}
