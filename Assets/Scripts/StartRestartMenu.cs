using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRestartMenu : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject restartCanvas;

    private void Start()
    {
        restartCanvas = GameObject.Find("EndGameMenu");
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    void Update()
    { 
        // fixar en najs win animations och så
        if(player1 == null || player2 == null|| Input.GetKeyDown(KeyCode.Escape))
        {
            restartCanvas.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1f;
            restartCanvas.SetActive(false);
        }
    }
}
