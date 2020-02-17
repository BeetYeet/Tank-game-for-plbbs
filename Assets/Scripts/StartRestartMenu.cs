using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartRestartMenu : MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;
	public GameObject restartCanvas;
	public TextMeshProUGUI gamoverText;
	public string victoryString;
	bool menuToggled = false;
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
			restartCanvas.SetActive(true);
			Time.timeScale = 0.1f;
			

			if (player1 == null)
			{
				gamoverText.text = "Player 2 wins";
			}
			else
			{
				gamoverText.text = "Player 1 wins";
			}
		}
		else if (menuToggled)
		{
			restartCanvas.SetActive(true);
			Time.timeScale = 0f;
			gamoverText.text = "Game Paused";
		}
		else
		{
			Time.timeScale = 1f;
			restartCanvas.SetActive(false);
		}
	}
}