using UnityEngine;
using System.Collections;

<<<<<<< HEAD
/*
[System.Serializable]
public class Boundry
{
    public float zMin, zMax;
}*/

public class PlayerMovement : MonoBehaviour
{
    /*[Header("Input Settings:")]
	[SerializeField]
	private float inputDeadzone = 0.2f;
	[Space]
	[Header("Movement Settings:")]
	[SerializeField]
    private float speed = 5;
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 100;
	[SerializeField]
	private float distanceToGround = 0.6f;
	[SerializeField]
	private LayerMask groundLayer;*/


    //PLEASE do not do the thing with headers it makes it really  
    //hard to read and undestand what variables we have in the code.
    //Plus, you are not supposed to be able to edit private variables
    //in the scene(hence the "Private").
    private float inputDeadzone = 0.2f;
    private float speed = 2;
    private float jumpPower = 100;
    private float distanceToGround = 0.6f;

    private LayerMask groundLayer;

    //public Boundry boundry;

    private Rigidbody rb;
	private float xInput = 0;
	private bool jumpPressed = false;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		xInput = Input.GetAxis("Horizontal");
		jumpPressed = Input.GetButtonDown ("Jump");

		Debug.Log (Grounded ());
		JumpLogic ();

		if (Mathf.Abs (xInput) > inputDeadzone) {
			xInput *= speed;
		}
	}

    void FixedUpdate ()
    {
		if (Grounded ()) {
			rb.velocity = new Vector3 (0, 0, xInput);
		} else {
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, xInput);
		}

		/*
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                0.0f,
                0.0f,
                Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)
            );
        */
    }

	bool Grounded()
	{
		Ray ray = new Ray (transform.position, -Vector3.up);
		return Physics.Raycast (ray, distanceToGround, groundLayer);
	}

	void JumpLogic() 
	{
		if (Grounded () && jumpPressed) {
			rb.AddForce (new Vector3 (0, jumpPower, 0));
		}
	}

	void OnCollisionEnter(Collision col)
	{
		
=======
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
>>>>>>> 71cba9553f1be5dd837e9d3c53ee16fa7a00aa06
	}
}
