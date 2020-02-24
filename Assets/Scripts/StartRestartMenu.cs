using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class StartRestartMenu : MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;
	public GameObject restartCanvas;
	public Transform gameoverTextParent;
	public GameObject gameoverText;
	public Button resumeButton;
	public GameObject paused;
	public GameObject p1Wins;
	public GameObject p2Wins;
	bool menuToggled = false;
	bool gameWasOver = false;
	private void Start()
	{
		if (player1 == null || player2 == null)
		{
			Debug.LogError("Player Objects Not Assigned");
		}
	}
	void Update()
	{
		if (Input.GetButtonDown("Menu"))
		{
			menuToggled = !menuToggled;
			ReplaceWith(paused);
		}

		if (player1 == null || player2 == null)
		{

			if (!gameWasOver)
			{
				gameWasOver = true;
				restartCanvas.SetActive(true);
				resumeButton.interactable = false;
				EventSystem.current.SetSelectedGameObject(resumeButton.FindSelectableOnDown().gameObject);
				Time.timeScale = 0.1f;

				if (player1 == null)
				{
					ReplaceWith(p2Wins);
				}
				else
				{
					ReplaceWith(p1Wins);
				}
			}
		}
		else if (menuToggled)
		{
			restartCanvas.SetActive(true);
			Time.timeScale = Mathf.Epsilon;
		}
		else
		{
			Time.timeScale = 1f;
			restartCanvas.SetActive(false);
		}
	}

	private void ReplaceWith(GameObject newGameobject)
	{
		Destroy(gameoverText);
		gameoverText = Instantiate(newGameobject, gameoverTextParent);
	}

	public void Resume()
	{
		menuToggled = false;
	}

}
