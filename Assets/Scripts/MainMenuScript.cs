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
        //SoundManager.instance.PlaySingle(selectionSound);
        //SceneManager.LoadScene(1);
        change = true;
    }
    public void LoadCredits()
    {
        SoundManager.instance.PlaySingle(selectionSound);
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        SoundManager.instance.PlaySingle(selectionSound);
        Application.Quit();
    }
}
