using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
    public float zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Boundry boundry;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                0.0f,
                0.0f,
                Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)
            );
    }
}
