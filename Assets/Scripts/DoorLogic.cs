using UnityEngine;
using System.Collections;

public class DoorLogic : DoorInteraction 
{
	public Transform door;

	public override void Update () 
	{
		//uses the parent's update
		base.Update ();
		//controls the door
		OpenDoor ();
	}

	void OpenDoor()
	{
		door.gameObject.SetActive (Active);
	}
}
