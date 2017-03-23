using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	[Header("Movement Settings:")]
	[SerializeField]
	private float patrolSpeed = 1;
	[SerializeField]
	private float followSpeed = 1.5f;
	[Space]
	[Header("AI Settings:")]
	[SerializeField]
	private float followRange = 5;
	[SerializeField]
	private float groundCheckRange = 0.5f;
	[SerializeField]
	private Vector3 groundCheckDir = new Vector3(0, -1, 1);
	[Space]
	[Header("Raycast Settings:")]
	[SerializeField]
	private float forwardRange = 1;
	[SerializeField]
	private float backRange = 0.5f;
	[SerializeField]
	private float upRange = 0.5f;


	private Animator anim;
	private Rigidbody rb;
	private Transform target = null;
	private bool followTarget = false;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		if (followTarget) {
			Follow ();
		} else {
			Patrol ();
		}
		GroundCheck ();
		Animation ();
	}

	void FixedUpdate()
	{
		if (followTarget) {
			rb.velocity = transform.TransformDirection (new Vector3 (rb.velocity.x, rb.velocity.y, followSpeed));
		} else {
			rb.velocity = transform.TransformDirection (new Vector3 (rb.velocity.x, rb.velocity.y, patrolSpeed));
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
			Destroy (col.gameObject);
		}
	}

	void Animation() 
	{
		anim.SetBool ("IsFollowing", followTarget);
	}

	void Patrol()
	{
		RaycastHit hit;
		Debug.DrawRay (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.forward), Color.blue);
		if (Physics.Raycast (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1)) {
			if (hit.collider != null) {
				//Debug.Log ("Hit");
				if(hit.collider.CompareTag("Player")) {
					target = hit.collider.transform;
					followTarget = true;
				} else {
					Flip ();
				}
			}
		}
		if (Physics.Raycast (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.back), out hit, 0.5f)) {
			if (hit.collider != null) {
				//Debug.Log ("Hit");
				if(hit.collider.CompareTag("Player")) {
					target = hit.collider.transform;
					followTarget = true;
				}
			}
		}
		if (Physics.Raycast (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.up), out hit, 0.5f)) {
			if (hit.collider != null) {
				//Debug.Log ("Hit");
				if(hit.collider.CompareTag("Player")) {
					target = hit.collider.transform;
					followTarget = true;
				}
			}
		}
	}

	void GroundCheck()
	{
		RaycastHit hit;
		if (Physics.Raycast (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(groundCheckDir), out hit)) {
			if (hit.distance > groundCheckRange) {
				if (!followTarget) {
					Flip ();
				}
			}
		}
	}

	void Follow()
	{
		float distance = Vector3.Distance (transform.position, target.position);
		if (distance <= followRange) {
			transform.LookAt (new Vector3(target.position.x, transform.position.y, target.position.z));
		} else {
			followTarget = false;
		}
	}

	void Flip()
	{
		if (transform.rotation.y <= 0) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		} else if(transform.rotation.y <= 180) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}
}
