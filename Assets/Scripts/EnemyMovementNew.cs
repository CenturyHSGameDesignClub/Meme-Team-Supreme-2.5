using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EnemyMovementNew : MonoBehaviour
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

	[Space]
	[Header("Movement Settings:")]
	[SerializeField]
	private float speed = 5;					//speed of basic movement
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 100;				//force applied to rigidbody
	[SerializeField]
	private LayerMask groundLayer;

	private Rigidbody rb;
	private Animator anim;
	private float xInput = 0;
	private float yInput = 0;
	private float distanceToPlayer;
	private float verticalDistanceToPlayer;
	private bool jumpPressed = false;
	public float followDistance = 1.5f;
	private bool isGrounded = true;
	private bool allowClimb = false;
	public GameObject player;
	public PlayerMovement playerMovement;
	public Text GameOverText;
	public Text deathMessage;

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
		distanceToPlayer = Math.Abs((player.transform.position.z) - (this.transform.position.z));
		verticalDistanceToPlayer = Math.Abs((player.transform.position.y) - (this.transform.position.y));
		if ((distanceToPlayer <= followDistance) && (verticalDistanceToPlayer <= 0.25)) {
			xInput = Math.Sign ((player.transform.position.z) - (this.transform.position.z));
		}
		else{
			xInput = 0;
		}
		yInput = Input.GetAxis (yInputAxis);
		jumpPressed = Input.GetButtonDown (jumpButton);


		if (Mathf.Abs (xInput) > inputDeadzone) {
			xInput *= speed;
		}

		if (Mathf.Abs (yInput) > inputDeadzone) {
			yInput *= speed;
		}
	}

	void Animation()
	{
		//anim.SetBool ("IsRunning", Mathf.Abs (xInput) > inputDeadzone && !Repair);
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
		if (col.transform.gameObject.tag.Equals("Player")) {
			playerMovement.enabled = false;
			GameOverText.text = "Game Over";
			deathMessage.text = "You got killed by an alien.";
		}
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
	//Disabling so the AI enemy cannot jum
	void JumpLogic() 
	{
//		if (isGrounded && jumpPressed && !Repair) {
//			rb.AddForce (new Vector3 (0, jumpPower, 0));
//		}
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
