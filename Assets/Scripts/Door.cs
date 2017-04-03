using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public Transform door;
	public Interaction interaction;

	void OnTriggerEnter()
	{
		if (interaction.HasPower) {
			door.gameObject.SetActive (false);
		}
	}

	void OnTriggerExit()
	{
		if (interaction.HasPower) {
			door.gameObject.SetActive (true);
		}
	}
}
