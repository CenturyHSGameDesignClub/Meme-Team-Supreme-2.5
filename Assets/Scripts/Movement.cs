using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float InputDirection { get; set; }
	public float JumpDirection { get; set;}
	public bool IsReverse { get; set; }

	public void SetGravitySettings(GravityState state)
	{
		if (GravityMagic.State == GravityMagic.GravityState.UP)					transform.rotation = Quaternion.Euler(new Vector3(-180, 0, 0));
		else if (GravityMagic.State == GravityMagic.GravityState.DOWN)			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		else if (GravityMagic.State == GravityMagic.GravityState.LEFT)			transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
		else if (GravityMagic.State == GravityMagic.GravityState.RIGHT)			transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}
}
