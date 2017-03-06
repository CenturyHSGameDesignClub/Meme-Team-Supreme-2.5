using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[HideInInspector]
    public Transform target;			//scripts should be able to do this for you
	[SerializeField]
    private float smoothing = 5f;

	private Vector3 offset = Vector3.zero;
	private Vector3 targetCamPos = Vector3.zero;

	void Start ()
    {
		//setting the offset
        offset = transform.position - target.position;
    }
	
	void LateUpdate ()
    {
		//new position based on the target's postion and offset
        targetCamPos = target.position + offset;
		//smoothly adjusts the postion to the new one
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing);
    }
}
