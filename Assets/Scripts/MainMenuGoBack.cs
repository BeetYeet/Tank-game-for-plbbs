using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuGoBack : MonoBehaviour
{
	public AudioClip selectionSound;
	public Animator transition;
	public void GoBack()
	{
		SoundManager.instance.PlaySingle(selectionSound);
		transition.SetTrigger("end");
		Invoke("ReturnToMainMenu", 1.25f);
	}
	public void Restart()
	{
		SoundManager.instance.PlaySingle(selectionSound);
		transition.SetTrigger("end");
		Invoke("LoadThisLevel", 1.25f);
	}
	void LoadThisLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void ReturnToMainMenu(){
		SceneManager.LoadScene("MainMenuScene");
	}

}
