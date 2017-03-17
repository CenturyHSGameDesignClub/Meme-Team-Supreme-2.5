using UnityEngine;
using System.Collections;

//represents the current gravity direction
public enum GravityState {
	UP,
	DOWN,
	LEFT,
	RIGHT
}

public class GravityController : MonoBehaviour {	
	[SerializeField]
	private Vector3 gravityUp = new Vector3(0, 9.81f, 0);
	[SerializeField]
	private Vector3 gravityDown = new Vector3(0, -9.81f, 0);
	[SerializeField]
	private Vector3 gravityLeft = new Vector3(0, 0, -9.81f);
	[SerializeField]
	private Vector3 gravityRight = new Vector3(0, 0, 9.81f);
	[SerializeField]
	private float gravityUpMultipler = 1;
	[SerializeField]
	private float gravityDownMultipler = 1;
	[SerializeField]
	private float gravityLeftMultipler = -1;
	[SerializeField]
	private float gravityRightMultipler = 1;

	private GravityState state = GravityState.DOWN;							//allows outside classes to recognize the current direction of gravity
	private bool isReverse = false;									//easier for outside classes to effect only one axis
	private float jumpDirection = 1;
	private float inputAxisDirection = 1;						//the current gravity multipler that effects other classes velocity calculation
	private bool updated = true;

	void Start()
	{
		CalculatePhysics ();
	}

	void Update () 
	{
		ChangeDirection ();
	}

	//changes the state and direction of gravity by input
	void ChangeDirection()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			state = GravityState.LEFT;
			inputAxisDirection = gravityLeftMultipler;
			jumpDirection = 1;
			isReverse = true;
			Physics.gravity = gravityLeft;
			updated = false;

		} 
		else if(Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			state = GravityState.RIGHT;
			inputAxisDirection = gravityRightMultipler;
			jumpDirection = -1;
			isReverse = true;
			Physics.gravity = gravityRight;
			updated = false;
		} 
		else if(Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			state = GravityState.UP;
			inputAxisDirection = gravityUpMultipler;
			jumpDirection = -1;
			isReverse = false;
			Physics.gravity = gravityUp;
			updated = false;
		} 
		else if(Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			state = GravityState.DOWN;
			inputAxisDirection = gravityDownMultipler;
			jumpDirection = 1;
			isReverse = false;
			Physics.gravity = gravityDown;
			updated = false;
		}

		if (!updated) {
			CalculatePhysics ();
			updated = true;
		}
	}

	void CalculatePhysics()
	{
		Movement[] movements = GameObject.FindObjectsOfType<Movement> ();

		if (movements == null)
			return;

		for (int x = 0; x < movements.Length; x++) {
			movements [x].InputDirection = inputAxisDirection;
			movements [x].JumpDirection = jumpDirection;
			movements [x].IsReverse = isReverse;
			movements [x].SetGravitySettings (state);
		}
	}
}
