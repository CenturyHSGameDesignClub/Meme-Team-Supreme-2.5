using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	[SerializeField]
	private string restartButton;


	public bool Restart { get; set; }
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Restart = Input.GetButton (restartButton);
		if (Restart) {
			//Restart the level
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
