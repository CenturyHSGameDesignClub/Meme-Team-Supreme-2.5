using UnityEngine;
using System;
using System.Collections;

public class Interaction : MonoBehaviour 
{
	[SerializeField]
	private bool activeOnStart = false;

	public bool Active { get; set; }

	private FixInteraction fix;
	private bool requireFix;

	void Start()
	{
		fix = GetComponent<FixInteraction> ();
		requireFix = fix != null ? true : false;
		Active = activeOnStart;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			if (fix) {
				AlertFixLogic (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			var playerController = other.GetComponent<PlayerMovement> ();
			if (playerController != null) {
				if (requireFix) {
					fix.BeginRepair = playerController.Repair;
					if (fix.IsRepaired) {
						requireFix = false;
					}
				}
				else {
					Active = playerController.Action ? !Active : Active;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			if (fix) {
				AlertFixLogic (false);
			}
		}
	}

	void AlertFixLogic(bool value){
		if (requireFix) {
			fix.InTrigger = value;
		}
	}
}
