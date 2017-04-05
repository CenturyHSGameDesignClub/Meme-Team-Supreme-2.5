﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
[System.Serializable]
public class Boundry
{
    public float zMin, zMax;
}*/

public class EnemyMovement : MonoBehaviour
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
	private float speed = 1.5f;
	private float jumpPower = 100;
	private float distanceToGround = 0.6f;
	public GameObject player;
	public PlayerMovement playerMovement;
	public Text GameOverText;
	public Text deathMessage;

	private LayerMask groundLayer;

	//public Boundry boundry;

	private Rigidbody rb;
	private float xInput = 0;
	private float distanceToPlayer;
	private bool jumpPressed = false;
	public float followDistance = 1.5f;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		distanceToPlayer = Math.Abs((player.transform.position.z) - (this.transform.position.z));
		if (distanceToPlayer <= followDistance) {
			xInput = Math.Sign ((player.transform.position.z) - (this.transform.position.z));
		}
		else{
		xInput = 0;
		}
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
		if (col.transform.gameObject.tag.Equals("Player")) {
			playerMovement.enabled = false;
			GameOverText.text = "Game Over";
			deathMessage.text = "You got killed by an alien.";
		}
	}

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