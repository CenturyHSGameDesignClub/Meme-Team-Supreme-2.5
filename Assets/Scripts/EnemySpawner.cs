using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public bool spawning;
	public float spawnInterval;
	public Interaction interact;

	private bool started = false;

	public GameObject Enemy;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (spawning == true && started == false) {
			StartCoroutine (spawn ());
			started = true;
		}

		if(interact.OxygenGenRepaired){
			spawning = true;
		}
			

	}

	IEnumerator spawn()
	{
		float randomY = Random.Range (0.5f, 4.5f);
		Vector3 randomPosition = new Vector3 (0f, randomY, Random.Range(1.5f, -16f));
		Instantiate (Enemy, randomPosition, Quaternion.identity);
		Instantiate (interact.music);
		yield return new WaitForSeconds (spawnInterval);
		if (spawning) {
			StartCoroutine (spawn ());
		} else {
			started = false;
		}
	}
}
