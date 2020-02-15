using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMainMenuScript : MonoBehaviour
{
	public string fightSceneName;
	public string instructionsSceneName;
	public string creditsSceneName;
	public Animator transition;
	public AudioClip selectionSound;
	public float actionDelay = 1.25f;

	string toLoad = "";

	[System.Serializable]
	public enum MenuAction
	{
		LoadFightScene,
		LoadInstructionsScene,
		LoadCreditsScene,
		ExitGame
	}
	public void ButtonPress(MenuAction action)
	{
		switch (action)
		{
			case MenuAction.LoadFightScene:
				LoadScene(fightSceneName);
				ButtonWasPressed();
				break;

			case MenuAction.LoadInstructionsScene:
				LoadScene(instructionsSceneName);
				ButtonWasPressed();
				break;

			case MenuAction.LoadCreditsScene:
				LoadScene(creditsSceneName);
				ButtonWasPressed();
				break;

			case MenuAction.ExitGame:
				Invoke("Exit", actionDelay);
				ButtonWasPressed();
				break;
		}
	}

	void LoadScene(string name)
	{
		toLoad = name;
		Invoke("FinishLoading", actionDelay);
	}

	void FinishLoading()
	{
		SceneManager.LoadScene(toLoad);
	}

	public void ButtonPress(int action)
	{
		ButtonPress((MenuAction)action);
	}

	void ButtonWasPressed()
	{
		SoundManager.instance.PlaySingle(selectionSound);
		transition.SetTrigger("end");
	}

	void Exit()
	{
#if DEBUG
		Debug.Log("Would Quit Here");
#else
		Application.Quit();
#endif
	}

}
