using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuGoBack : MonoBehaviour
{
    public Animator tran;
    public bool trig = false;
    public bool ger = false;

    public void GoBack()
    {
        StartCoroutine(LoadScene());
        ger = true;
        //SceneManager.LoadScene("MainMenuScene");
    }
    public void Restart()
    {
        trig = true;
        StartCoroutine(LoadScene());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadScene()
    {
        tran.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        if (trig == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (ger == true)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
