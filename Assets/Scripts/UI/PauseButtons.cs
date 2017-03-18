using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseButtons : MonoBehaviour {

	[SerializeField]
	private GameObject pauseScreen;			//reference to the GUI that holds the pasue menu
	[SerializeField]
	private string titleScene;				//name of the title scene

	void Start()
	{
		pauseScreen.SetActive (false);		//begins with the pauseScreen not visible
		Time.timeScale = 1f;				//begins with a timeScale of 1
	}

	void Update()
	{
		PauseInput ();
	}

	void PauseInput()
	{
		//checks for the escape key
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//determine what is the current timeScale
			if (Time.timeScale > 0) {
				//make pause menu visible
				pauseScreen.SetActive (true);
				//stop time
				Time.timeScale = 0f;
			} else {
				//make pause menu invisible
				pauseScreen.SetActive (false);
				//set time back to normal
				Time.timeScale = 1f;
			}
		}
	}

	//should be called by a button click, continues the game
	public void Continue()
	{
		pauseScreen.SetActive (false);
		Time.timeScale = 1f;
	}

	//should be called by a button click, exits to the title
	public void ExitToTitle()
	{
		SceneManager.LoadScene (titleScene);
	}

	//should be called by a button click, exits the game
	public void ExitGame()
	{
		Application.Quit ();
	}
}
