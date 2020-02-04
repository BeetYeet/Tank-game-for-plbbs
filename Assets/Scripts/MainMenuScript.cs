using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public int selection;
    public bool selectedMap = false;
    public AudioClip selectionSound;
    public bool change = false;
    public bool button1 = false;
    public bool button2 = false;

    void Update()
    {
        if (Input.GetButton("Select"))
        {
            if (selection > 0)
            {
                selectedMap = true;
            }
        }

        if (selection == 1 && selectedMap == true)
        {
            LoadMap();
        }
        else if (selection == 2 && selectedMap == true)
        {
            LoadCredits();
        }
        else if (selection == 3 && selectedMap == true)
        {
            QuitGame();
        }
    }
    public void LoadMap()
    {
        SoundManager.instance.PlaySingle(selectionSound);
        //SceneManager.LoadScene(0);
        change = true;
        button1 = true;
    }
    public void LoadCredits()
    {
        SoundManager.instance.PlaySingle(selectionSound);
        //SceneManager.LoadScene(2);
        change = true;
        button2 = true;
    }
    public void QuitGame()
    {
        SoundManager.instance.PlaySingle(selectionSound);
        Application.Quit();
    }
}
