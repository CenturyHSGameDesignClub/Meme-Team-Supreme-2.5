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
		SetTarget ();
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

	public void SetTarget()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		if (target == null) {
			Debug.LogError ("Error: there is no player in the scene");
		}
	}

	public void SetTarget(Transform other)
	{
		target = other;

		if (target == null) {
			Debug.LogError ("Error: the target does not exist in the scene");
		}
	}
}
