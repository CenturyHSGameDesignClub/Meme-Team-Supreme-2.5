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


	// Use this for initialization
	void Start ()
    {
		//Barrier1Collider = Barrier1.GetComponent<Collider> ();
		//Barrier2Collider = Barrier2.GetComponent<Collider> ();

		PowerGenMessageShown = false;
		if (tutorial == true) {
			StartCoroutine (Tutorial ());
		}


	}
	
	// Update is called once per frame
	void Update ()
    {
		StartCoroutine(ComputerGuide());
	}


    IEnumerator Tutorial()
    {
		OxygenController.enabled = false;
        Narration.text = "Welcome to (Game title goes here)";
        yield return new WaitForSeconds(5);
        Narration.text = "Press A and D to move left and right";
        yield return new WaitForSeconds(5);
        Narration.text = "Press Space to jump";
        yield return new WaitForSeconds(5);
        Narration.text = "Hold W or S to climb latters";
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
        Narration.text = "Have fun playing (Title), and do your best not to die, okay?";
        yield return new WaitForSeconds(5);
		Narration.text = "";
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
	}
}
