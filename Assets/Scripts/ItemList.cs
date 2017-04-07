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
	public Text Pipes;
	public Text NuclearPowerCell;
	public Text CO2Converter;
	public Text TorqueWrench;
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
		Pipes  = Pipes.GetComponent<Text>();
		NuclearPowerCell  = NuclearPowerCell.GetComponent<Text>();
		CO2Converter  = CO2Converter.GetComponent<Text>();
		TorqueWrench  = TorqueWrench.GetComponent<Text>();
		GameOverText.text = "";
		deathMessage.text = "";
	}

	// Update is called once per frame
	void Update ()
	{
		Battery.text = "Batteries: " + interact.BatteryCount.ToString();
		Scrap.text = "Scrap: " + interact.ScrapCount.ToString ();
		Pipes.text = "Pipes: " + interact.PipingCount.ToString ();
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

		if (interact.NuclearPowerCellCollected) {
			NuclearPowerCell.text = "Nuclear PowerCell: yes";
		}
		else{
			NuclearPowerCell.text = "Nuclear PowerCell: no";
		}

		if (interact.CO2ConverterCollected) {
			CO2Converter.text = "CO2 Converter: yes";
		}
		else{
			CO2Converter.text = "CO2 Converter: no";
		}

		if (interact.HasTorqueWrench) {
			TorqueWrench.text = "Torque Wrench: yes";
		}
		else{
			TorqueWrench.text = "Torque Wrench: no";
		}



	}
}
