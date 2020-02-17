using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuGoBack : MonoBehaviour
{
	public AudioClip selectionSound;
	public Animator transition;
	bool transitioning = false;

	private void LateUpdate()
	{
		if (transitioning)
		{
			Time.timeScale = 1f;
		}
	}

	public void GoBack()
	{
		SoundManager.instance.PlaySingle(selectionSound);
		transition.SetTrigger("end");
		transitioning = true;
		Invoke("ReturnToMainMenu", 1.25f);
	}
	public void Restart()
	{
		SoundManager.instance.PlaySingle(selectionSound);
		transition.SetTrigger("end");
		transitioning = true;
		Invoke("LoadThisLevel", 1.25f);
	}
	void LoadThisLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

}
