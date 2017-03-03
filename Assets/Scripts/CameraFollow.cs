﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
    private Transform target;
	[SerializeField]
    private float smoothing = 5f;

    Vector3 offset;

	void Start ()
    {
        offset = transform.position - target.position;
    }
	
	void LateUpdate ()
    {
        Vector3 targetCamPos = target.position + offset;
		//transform.position = targetCamPos* Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing);
    }
}
