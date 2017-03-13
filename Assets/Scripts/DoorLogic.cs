using UnityEngine;
using System.Collections;

public class DoorLogic : Interaction 
{
	public Transform door;

	void Update () 
	{
		OpenDoor ();
	}

	void OpenDoor()
	{
		door.gameObject.SetActive (Active);	
	}
}
