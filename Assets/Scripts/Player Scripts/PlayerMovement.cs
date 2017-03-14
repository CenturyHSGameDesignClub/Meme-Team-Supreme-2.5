using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	[Header("Input Settings:")]
	[SerializeField]
	private float inputDeadzone = 0.2f;			//determines when input axis value is accepted
	[SerializeField]
	private string xInputAxis = "Horizontal";
	[SerializeField]
	private string yInputAxis = "Vertical";
	[SerializeField]
	private string jumpButton = "Jump";
	[SerializeField]
	private string actionButton;
	[SerializeField]
	private string repairButton;
	[Space]
	[Header("Movement Settings:")]
	[SerializeField]
    private float speed = 5;					//speed of basic movement
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 100;				//force applied to rigidbody

    private Rigidbody rb;
	private Animator anim;
	private float xInput = 0;
	private float yInput = 0;
	private bool jumpPressed = false;
	private bool isGrounded = true;
	private bool allowClimb = false;

	public bool AllowClimb 
	{ 
		get{
			return allowClimb;
		}
		set{
			allowClimb = value;
			rb.useGravity = !value;
		}
	}
	public bool Action { get; set; }
	public bool Repair { get; set; }

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		AllowClimb = false;
	}

	void Update ()
    {
		GetInput ();
		Flip ();
		JumpLogic ();
		Animation ();
	}

	void GetInput()
	{
		xInput = Input.GetAxis (xInputAxis);
		yInput = Input.GetAxis (yInputAxis);
		jumpPressed = Input.GetButtonDown (jumpButton);
		Action = Input.GetButtonDown (actionButton);
		Repair = Input.GetButton (repairButton);

		if (Mathf.Abs (xInput) > inputDeadzone) {
			xInput *= speed;
		}

		if (Mathf.Abs (yInput) > inputDeadzone) {
			yInput *= speed;
		}
	}

	void Animation()
	{
		anim.SetBool ("IsRunning", Mathf.Abs (xInput) > inputDeadzone);
	}

    void FixedUpdate ()
    {
		if (!Repair) {
			if (AllowClimb) {
				rb.velocity = new Vector3 (0, yInput, xInput);
			} else if (isGrounded) {
				rb.velocity = new Vector3 (0, 0, xInput);
			} else {
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, xInput);
			}
		}
    }

	//grounded once player lands
	void OnCollisionEnter(Collision col)
	{
		isGrounded = true;
	}

	//not grounded when not on another collider
	void OnCollisionExit(Collision col)
	{
		isGrounded = false;
	}

	//applies a force to the rigidbody reference when gameobject is grounded and pressed jump key
	void JumpLogic() 
	{
		if (isGrounded && jumpPressed) {
			rb.AddForce (new Vector3 (0, jumpPower, 0));
		}
	}

	//flips the player's transform according to the input on x axis
	void Flip()
	{
		//flips right if x axis input is greater than 0
		if (xInput > 0) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			//flips left if x axis input is less than 0
		} else if (xInput < 0) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		}
	}
}
