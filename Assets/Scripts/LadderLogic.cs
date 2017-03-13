using UnityEngine;
using System.Collections;

public class LadderLogic : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			var playerController = other.gameObject.GetComponent<PlayerMovement> ();
			if (playerController != null) {
				playerController.AllowClimb = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			var playerController = other.gameObject.GetComponent<PlayerMovement> ();
			if (playerController != null) {
				playerController.AllowClimb = false;
			}
		}
	}
}
