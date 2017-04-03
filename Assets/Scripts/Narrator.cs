using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narrator : MonoBehaviour
{
    public Interaction Interaction;
    public OxygenController OxygenController;

    public Text Narration;

	// Use this for initialization
	void Start ()
    {

		StartCoroutine(Tutorial());
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator Tutorial()
    {
        Narration.text = "Welcome to (Game title goes here)";
        yield return new WaitForSeconds(5);
        Narration.text = "Press A and D to move left and right";
        yield return new WaitForSeconds(5);
        Narration.text = "Press Space to jump";
        yield return new WaitForSeconds(5);
        Narration.text = "Hold up or down to climb latters";
        yield return new WaitForSeconds(5);
        Narration.text = "Walk up to an object and press 'E' to pick up or repair that object.";
        yield return new WaitForSeconds(5);
		Narration.text = "Get oxygen canisters to give more oxygen, but it maxes at 100.";
		yield return new WaitForSeconds(5);
		Narration.text = "Running out of oxygen or falling off the ship will kill you.";
		yield return new WaitForSeconds(5);
		Narration.text = "Use the scrap metal and torch to repair the holes in the ship.";
		yield return new WaitForSeconds(5);
		Narration.text = "Then you will be able to pick up the book, batteries and wrench, to restore power.";
		yield return new WaitForSeconds(5);
        Narration.text = "Have fun playing (Title), and do your best not to die, okay?";
        yield return new WaitForSeconds(10);


    }
}
