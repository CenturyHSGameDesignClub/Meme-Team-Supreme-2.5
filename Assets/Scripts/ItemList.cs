using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public Interaction interact;
	public Text Battery;
	public Text Scrap;
	public Text Torch;
	public Text Wrench;
	public Text Passcode;
	public Text GameOverText;
	public Text deathMessage;

	// Use this for initialization
	void Start ()
	{
		
		Battery = Battery.GetComponent<Text>();
		Scrap  = Scrap.GetComponent<Text>();
		Torch  = Torch.GetComponent<Text>();
		Wrench  = Wrench.GetComponent<Text>();
		Passcode  = Passcode.GetComponent<Text>();
		GameOverText.text = "";
		deathMessage.text = "";
	}

	// Update is called once per frame
	void Update ()
	{
		Battery.text = "Batteries: " + interact.BatteryCount.ToString();
		Scrap.text = "Scrap: " + interact.ScrapCount.ToString ();
		if (interact.HasTorch) {
			Torch.text = "Torch: yes";
		}
		else{
			Torch.text = "Torch: no";
		}

		if (interact.HasWrench) {
			Wrench.text = "Wrench: yes";
		}
		else{
			Wrench.text = "Wrench: no";
		}

		if (interact.PasscodeBookCollected) {
			Passcode.text = "Passcode: yes";
		}
		else{
			Passcode.text = "Passcode: no";
		}



	}
}
