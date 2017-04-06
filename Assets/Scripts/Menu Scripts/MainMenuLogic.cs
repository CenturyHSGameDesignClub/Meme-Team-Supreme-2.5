using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuLogic : MonoBehaviour 
{
	[SerializeField]
	private string startingScene;
	[SerializeField]
	private string tutorialScene;

	//attached to a button - starts the game
	public void Play()
	{
		SceneManager.LoadScene (startingScene);
	}

	public void StartTutorial()
	{
		SceneManager.LoadScene (tutorialScene);
	}

	//attached to a button - quits the game
	public void Quit()
	{
		Application.Quit ();
	}
}
