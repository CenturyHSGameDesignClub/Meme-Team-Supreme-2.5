using UnityEngine;
using System.Collections;

public class LadderLogic : MonoBehaviour 
{
	//allows the player to climb the ladder once entered the trigger
	void OnTriggerEnter(Collider other)
	{
		//checks for the player
		if (other.gameObject.CompareTag ("Player")) {
			//reference to the player
			var playerController = other.gameObject.GetComponent<PlayerMovement> ();
			if (playerController != null) {
				//alerts player's reference to allow climb
				playerController.AllowClimb = true;
			}
		}
	}

	//does not allow the player to climb the ladder once exited the trigger
	void OnTriggerExit(Collider other)
	{
		//checks for the player
		if (other.gameObject.CompareTag ("Player")) {	
			//reference to the player
			var playerController = other.gameObject.GetComponent<PlayerMovement> ();
			if (playerController != null) {
				//alerts player's reference to not allow climb
				playerController.AllowClimb = false;
			}
		}
	}
}
