using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartRestartMenu : MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;
	public GameObject restartCanvas;
	public Image gameoverText;
	public Button resumeButton;
	public Sprite paused;
	public Sprite p1Wins;
	public Sprite p2Wins;
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
			menuToggled = !menuToggled;

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
					gameoverText.sprite = p2Wins;
				}
				else
				{
					gameoverText.sprite = p1Wins;
				}
			}
		}
		else if (menuToggled)
		{
			restartCanvas.SetActive(true);
			Time.timeScale = Mathf.Epsilon;
			gameoverText.sprite = paused;
		}
		else
		{
			Time.timeScale = 1f;
			restartCanvas.SetActive(false);
		}
	}
	public void Resume()
	{
		menuToggled = false;
	}

}
