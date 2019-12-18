using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuGoBack : MonoBehaviour
{

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
