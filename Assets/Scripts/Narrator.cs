using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narrator : MonoBehaviour
{
    public Interaction Interaction;
    public OxygenController OxygenController;

    public Text Narration;

	public bool tutorial;
	//public GameObject Barrier1;
	//public GameObject Barrier2;

	//private Collider Barrier1Collider;
	//private Collider Barrier2Collider;

	private bool HullHoleMessageShown;
	private bool PowerGenMessageShown;
	private bool OxygenGenMessageShown;
	private bool done = false;


	// Use this for initialization
	void Start ()
    {
		//Barrier1Collider = Barrier1.GetComponent<Collider> ();
		//Barrier2Collider = Barrier2.GetComponent<Collider> ();

		PowerGenMessageShown = false;
		if (tutorial == true) {
			StartCoroutine (Tutorial ());

		} else {
			done = true;
		}
			


	}
	
	// Update is called once per frame
	void Update ()
    {
		if (done == true) {
			StartCoroutine (ComputerGuide ());
		}
	}


    IEnumerator Tutorial()
    {
		OxygenController.enabled = false;
        Narration.text = "Welcome to Into the Void";
        yield return new WaitForSeconds(5);
        Narration.text = "Press A and D to move left and right";
        yield return new WaitForSeconds(5);
        Narration.text = "Press Space to jump";
        yield return new WaitForSeconds(5);
        Narration.text = "Hold W or S to climb ladders";
        yield return new WaitForSeconds(5);
        Narration.text = "Walk up to an object and press 'E' to pick up or repair that object.";
        yield return new WaitForSeconds(5);
		Narration.text = "Get oxygen canisters to give more oxygen, but it maxes at 100.";
		yield return new WaitForSeconds(5);
		Narration.text = "Running out of oxygen, running into an enemy or falling off the ship will kill you.";
		yield return new WaitForSeconds(5);
		/*Narration.text = "Use the scrap metal and torch to repair the holes in the ship.";
		yield return new WaitForSeconds(5);
		Narration.text = "Then you will be able to pick up the book, batteries and wrench, to restore power.";
		yield return new WaitForSeconds(5);*/
        Narration.text = "Have fun playing Into the Void, and do your best not to die, okay?";
        yield return new WaitForSeconds(5);
		Narration.text = "";
		done = true;
		//OxygenController.enabled = true;
		//Barrier1Collider.enabled = false;
		//Barrier2Collider.enabled = false;
    }

	IEnumerator ComputerGuide()
	{
	

		if (HullHoleMessageShown == false)
		{			
			HullHoleMessageShown = true;
			Narration.text = "First, we need to repair the holes in the hull.";
			yield return new WaitForSeconds (5);
			Narration.text = "We will need 1 piece of scrap metal per hole, for 4 total, as well as a welding torch.";
			yield return new WaitForSeconds (5);
			Narration.text = "";
		}

		if (Interaction.allHolesRepaired == true && PowerGenMessageShown == false) 
		{
			PowerGenMessageShown = true;
			Narration.text = "Now that all the holes are repaired, we need to fix the power.";
			yield return new WaitForSeconds (5);
			Narration.text = "We need 3 batteries, a wrench, and the startup passcode to restore power.";
			yield return new WaitForSeconds (5);
			Narration.text = "";
		}

		if (Interaction.PowerGenRepaired == true && OxygenGenMessageShown == false) 
		{
			OxygenGenMessageShown = true;
			Narration.text = "Since the Power Generator is functional, we now need to activate the Oxygen Converter.";
			yield return new WaitForSeconds (5);
			Narration.text = "The converter requires 3 pipes, a new CO2 Converter, a nuclear power cell, and a torque wrench to return to an operational state.";
			yield return new WaitForSeconds (7);
			Narration.text = "";
		}
	}
}
