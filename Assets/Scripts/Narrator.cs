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
		StartCoroutine ("Tutorial");
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
        Narration.text = "Press '(JumpButton)' to jump";
        yield return new WaitForSeconds(5);
        Narration.text = "(Info about how to climb ladders)";
        yield return new WaitForSeconds(5);
        Narration.text = "Walk up to an object and press 'E' to pick up or repair that object.";
        yield return new WaitForSeconds(5);
        Narration.text = "Have fun playing (Title), and do your best not to die, okay? However, I promise that if you die we will revive you as a zombie so that you can be studied to deduce why a trained engineer such as yourself was unable to repair a simple ship.";
        yield return new WaitForSeconds(10);


    }
}
