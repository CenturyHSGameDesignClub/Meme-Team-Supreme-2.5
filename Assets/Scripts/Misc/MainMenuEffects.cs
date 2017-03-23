using UnityEngine;
using System.Collections;

public class MainMenuEffects : MonoBehaviour 
{
	[SerializeField]
	private Transform spinObject;
	[SerializeField]
	private float rotateSpeed = 1;

	void Start () 
	{
		
	}

	void Update () 
	{
		spinObject.Rotate (0, rotateSpeed * Time.deltaTime, 0);
		//Camera.main.transform.LookAt (spinObject);
	}
}
