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
	[Header("Zoom Settings:")]
	[SerializeField]
	private float zoomSpeed = 2;
	[SerializeField]
	private float minZoom = 1;
	[SerializeField]
	private float maxZoom = 5;
	[SerializeField]
	private float startZoom = 1.5f;
	[SerializeField]
	private bool isInverse = true;
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 100;				//force applied to rigidbody
	[SerializeField]
	private LayerMask groundLayer;

	private Camera playerCamera;
    private Rigidbody rb;
	private Animator anim;
	private float xInput = 0;
	private float yInput = 0;
	private float wheelInput = 0;
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
		playerCamera = GameObject.FindObjectOfType<CameraFollow> ().GetComponent<Camera>();
		playerCamera.orthographicSize = startZoom;
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
		Zoom ();
	}

	void GetInput()
	{
		xInput = Input.GetAxis (xInputAxis);
		yInput = Input.GetAxis (yInputAxis);
		jumpPressed = Input.GetButtonDown (jumpButton);
		Action = Input.GetButtonDown (actionButton);
		Repair = Input.GetButton (repairButton);
		wheelInput = Input.GetAxis ("Mouse ScrollWheel");

		//checks if the input deadzone was overcome
		if (Mathf.Abs (xInput) > inputDeadzone) {
			xInput *= speed;
		}

		if (Mathf.Abs (yInput) > inputDeadzone) {
			yInput *= speed;
		}
	}

	void Animation()
	{
		//applies the moving animation to the model based on the input and any other condition
		anim.SetBool ("IsRunning", Mathf.Abs (xInput) > inputDeadzone && !Repair);
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
		//Debug.Log ("OnCollisionEnter");
		isGrounded = true;
	}

	void OnCollisionStay(Collision col)
	{
		//Debug.Log ("OnCollisionStay");
		isGrounded = true;
	}

	//not grounded when not on another collider
	void OnCollisionExit(Collision col)
	{
		//Debug.Log ("OnCollisionExit");
		isGrounded = false;
	}		

	//applies a force to the rigidbody reference when gameobject is grounded and pressed jump key
	void JumpLogic() 
	{
		if (isGrounded && jumpPressed && !Repair) {
			rb.AddForce (new Vector3 (0, jumpPower, 0), ForceMode.Force);
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

	void Zoom()
	{
		if (wheelInput > 0 || wheelInput < 0) {
			wheelInput *= isInverse ? (zoomSpeed * -1) : zoomSpeed;
			playerCamera.orthographicSize = Mathf.Lerp (playerCamera.orthographicSize, wheelInput + playerCamera.orthographicSize, zoomSpeed);
			playerCamera.orthographicSize = Mathf.Clamp (playerCamera.orthographicSize, minZoom, maxZoom);
		}
	}
}
