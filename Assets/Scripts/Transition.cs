using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    public MainMenuScript trigger;

    private void Start()
    {
        trigger = GameObject.FindObjectOfType<MainMenuScript>();
    }

    void Update()
    {
        if (trigger != null && trigger.change == true)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
