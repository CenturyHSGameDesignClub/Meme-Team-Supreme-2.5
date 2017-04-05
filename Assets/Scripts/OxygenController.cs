using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float OxygenTimer = 100;
    public Text OxygenCountText;
    public Text GameOverText;
    public Text deathMessage;

	// Use this for initialization
	void Start ()
    {
        OxygenCountText = GetComponent<Text>();
        GameOverText.text = "";
        deathMessage.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(OxygenTimer > 0)
        {
            OxygenTimer -= Time.deltaTime;
            OxygenCountText.text = "Oxygen Remaining: " + OxygenTimer.ToString("f0");
        }

        if (OxygenTimer <= 0)
        {
            OxygenCountText.text = "Oxygen Remaining: 0";
            playerMovement.enabled = false;
            GameOverText.text = "Game Over";
            deathMessage.text = "You ran out of oxygen.";
        }
        if (Input.GetButtonDown("OxygenCheat"))
        {
            //It is not just for testing Matteas, We get points for cheats.
			OxygenTimer = OxygenTimer + 50;
        }
		if (OxygenTimer > 100) {
			OxygenTimer = 100;
		}
	}
}
