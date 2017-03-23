using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//WARNING! Outdated, and most likely replaced

public class FixInteraction : MonoBehaviour 
{
	[SerializeField]
	private Image repairSign;				//image to show that repair is need before use
	[SerializeField]
	private Slider repairValue;				//bar to display how long to repair
	[SerializeField]
	private float repairTime;				//how long to repair

	public bool IsRepaired { get; set; }	//property used for if the object is repaired
	public bool BeginRepair { get; set; }	//property determines if the object is being repaired
	public bool InTrigger { get; set; }		//property that determines if the player is in a trigger, should be set by an outside class/object

	private float amountRepair = 0;			//how much is currently repaired

	void Start()
	{
		IsRepaired = false;
		BeginRepair = false;
		repairSign.gameObject.SetActive (false);
		repairValue.maxValue = repairTime;
		repairValue.value = 0;
		repairValue.gameObject.SetActive (false);
	}

	void Update () 
	{
		Repair ();
	}

	void Repair()
	{
		//if the object is not already repaired
		if (!IsRepaired) {
			//if player started the repair
			if (BeginRepair) {
				//turn off repair graphic, turn on repair bar
				ControlGUI (false, true);
				//if repair is complete
				if (amountRepair >= repairTime) {
					//set the object state to repaired
					IsRepaired = true;
				//if repair is not complete
				} else {
					//increase the repair amount 
					amountRepair += 1 * Time.deltaTime;
					//set the repair bar value to the repair amount
					repairValue.value = amountRepair;
				}
			//if player is in the trigger 
			} else if (InTrigger) {
				//turn on repair graphic, turn off repair bar
				ControlGUI (true, false);
			//if player is not in the trigger
			} else {
				//turn off repair graphic, turn off repair bar
				ControlGUI (false, false);
			}
		//if the object is repaired
		} else {
			//turn off repair graphic, turn of repair bar
			ControlGUI (false, false);
		}
	}

	void ControlGUI(bool repairSignActive, bool repairValueActive)
	{
		repairSign.gameObject.SetActive (repairSignActive);
		repairValue.gameObject.SetActive (repairValueActive);
	}
}
