using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject mainMenu;
    public TextMeshProUGUI victoryText;

    private void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }
    private void Awake()
    {
        if (player1 == null)
        {
            player1 = GameObject.Find("Player1");
            victoryText.text = "player 1 wins";
            Debug.Log("Player object not assigned, please assign player object. If object got destroyed, ignore this message");
        }
        if(player2 == null)
        {
            player2 = GameObject.Find("Player2");
            victoryText.text = "Player 2 Wins";
            Debug.Log("Player object not assigned, please assign player object. If object got destroyed, ignore this message");
        }
        
    }

    void Update()
    {
        if (player1 == null || player2 == null)
        {
            mainMenu.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else
        {
            mainMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
