using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FixInteraction : MonoBehaviour 
{
	[SerializeField]
	private Image repairSign;
	[SerializeField]
	private Slider repairValue;
	[SerializeField]
	private float repairTime;

	public bool IsRepaired { get; set; }
	public bool BeginRepair { get; set; }
	public bool InTrigger { get; set; }

	private float amountRepair = 0;

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
		if (!IsRepaired) {
			if (BeginRepair) {
				repairValue.gameObject.SetActive (true);
				repairSign.gameObject.SetActive (false);
				if (amountRepair >= repairTime) {
					IsRepaired = true;
					Debug.Log ("Repaired!!");
				} else {
					amountRepair += 1 * Time.deltaTime;
					repairValue.value = amountRepair;
					Debug.Log (amountRepair);
				}
			} else if (InTrigger) {
				repairSign.gameObject.SetActive (true);
			} else {
				repairValue.gameObject.SetActive (false);
				repairSign.gameObject.SetActive (false);
			}
		} else {
			repairValue.gameObject.SetActive (false);
			repairSign.gameObject.SetActive (false);
		}
	}
}
