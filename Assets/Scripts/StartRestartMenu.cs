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
    private void Start()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("PlayerObjects Not Assigned");
        }
    }
    void Update()
    {
        // fixar en najs win animations och så
        if (player1 == null || player2 == null || Input.GetKeyDown(KeyCode.Escape))
        {
            restartCanvas.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1f;
            restartCanvas.SetActive(false);
        }
        if (player1 == null)
        {
            victoryString = "Player 2 wins";
            gamoverText.text = victoryString.ToString();
        }
        if (player2 == null)
        {
            victoryString = "Player 1 wins";
            gamoverText.text = victoryString.ToString();
        }
    }
}