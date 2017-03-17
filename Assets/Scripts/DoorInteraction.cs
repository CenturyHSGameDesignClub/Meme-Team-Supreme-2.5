using UnityEngine;
using System;
using System.Collections;

public class DoorInteraction : MonoBehaviour 
{
	[SerializeField]
	private AudioClip activateSound;		//sound for activating
	[SerializeField]
	private AudioClip deactivateSound;		//sound for deactivating
	[SerializeField]
	private bool activeOnStart = false;     //is it active on start

	public bool Active { 
		get {
			return active;
		}
		set {
			//if new value is the opposite of Active
			if (value == !Active) {
				if (value == true) {
					//play activate sound
					soundInstance.clip = activateSound;
					soundInstance.Play ();
				} else {
					//play deactivate sound
					soundInstance.clip = deactivateSound;
					soundInstance.Play ();
				}
			} 
			//set the new value
			active = value;
		}
	}

	private FixInteraction fix = null;
	private AudioSource soundInstance;
	private bool active = false;
	private bool requireFix = false;
	private bool interaction = false;
	private bool inTrigger = false;

	void Start()
	{
		fix = GetComponent<FixInteraction> ();
		soundInstance = GetComponent<AudioSource> ();
		requireFix = fix != null ? true : false;
		Active = activeOnStart;
	}

	//allows child classes to use this Update() method
	public virtual void Update()
	{
		interaction = Input.GetButtonDown ("Action");
		Active = interaction && inTrigger && !requireFix ? !Active : Active;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = true;
			if (fix) {
				AlertFixLogic (inTrigger);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			//if there is a FixInteraction reference
			if (requireFix) {
				//begin the repair by input
				fix.BeginRepair = Input.GetButton("Repair");
				//if repairing is done
				if (fix.IsRepaired) {
					//set the requirement of repairing to false
					requireFix = false;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = false;
			if (fix) {
				AlertFixLogic (inTrigger);
			}
		}
	}

	//lets the FixInteraction object that the player is in the trigger
	void AlertFixLogic(bool value){
		if (requireFix) {
			fix.InTrigger = value;
		}
	} 
}
