using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public string sceneName2;

    public MainMenuScript trigger;
    public MainMenuGoBack trigger2;

    private void Start()
    {
        trigger = GameObject.FindObjectOfType<MainMenuScript>();
        trigger2 = GameObject.FindObjectOfType<MainMenuGoBack>();
    }

    void Update()
    {
        trigger2 = GameObject.FindObjectOfType<MainMenuGoBack>();
        if (trigger != null && trigger.change == true)
        {
            StartCoroutine(LoadScene());
        }

    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        if (trigger.button1 == true)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (trigger.button2 == true)
        {
            SceneManager.LoadScene(sceneName2);
        }
    }
}
