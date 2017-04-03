using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public OxygenController oxygenController;

    public GameObject OxygenCanisterFullImage1;
    public GameObject OxygenCanisterFullImage2;
    public GameObject OxygenCanisterFullImage3;
    public GameObject Hull1RepairedImage;
	public GameObject Hull2RepairedImage;
	public GameObject Hull3RepairedImage;
	public GameObject Hull4RepairedImage;
    public GameObject ScrapMetal1Image;
	public GameObject ScrapMetal2Image;
	public GameObject ScrapMetal3Image;
	public GameObject ScrapMetal4Image;
    public GameObject Battery1Image;
    public GameObject Battery2Image;
    public GameObject Battery3Image;
    public GameObject TorchImage;
    public GameObject WrenchImage;
    public GameObject PasscodeBookImage;
    public GameObject PowerGeneratorImage;
    public GameObject PowerGeneratorBrokenImage;

    public AudioClip[] Clip;

    public Text GameOverText;
    public Text DeathMessageText;

    private bool OxygenCanister1Full;
    private bool OxygenCanister2Full;
    private bool OxygenCanister3Full;

	private bool ScrapMetal1Collected;
	private bool ScrapMetal2Collected;
	private bool ScrapMetal3Collected;
	private bool ScrapMetal4Collected;

	public bool Battery1Collected;
	public bool Battery2Collected;
	public bool Battery3Collected;
	public bool PasscodeBookCollected;

	private bool PowerGenPartsCollected;

    private bool Hull1Repaired;
	private bool Hull2Repaired;
	private bool Hull3Repaired;
	private bool Hull4Repaired;

    private bool allHolesRepaired;
    private bool PowerGenRepaired;


	public bool HasTorch;
    public bool HasWrench;

	public int ScrapCount;
	public int BatteryCount;

    private Renderer OxygenCanisterFullImage1Renderer;
    private Renderer OxygenCanisterFullImage2Renderer;
    private Renderer OxygenCanisterFullImage3Renderer;
    private Renderer ScrapMetal1ImageRenderer;
	private Renderer ScrapMetal2ImageRenderer;
	private Renderer ScrapMetal3ImageRenderer;
	private Renderer ScrapMetal4ImageRenderer;
    private Renderer Battery1ImageRenderer;
    private Renderer Battery2ImageRenderer;
    private Renderer Battery3ImageRenderer;
    private Renderer Hull1RepairedImageRenderer;
	private Renderer Hull2RepairedImageRenderer;
	private Renderer Hull3RepairedImageRenderer;
	private Renderer Hull4RepairedImageRenderer;
    private Renderer TorchImageRenderer;
    private Renderer WrenchImageRenderer;
    private Renderer PasscodeBookImageRenderer;
    private Renderer PowerGeneratorImageRenderer;
    private Renderer PowerGeneratorBrokenImageRenderer;

    private bool keyPressed;

	// Use this for initialization
	void Start ()
    {
        OxygenCanister1Full = true;
        OxygenCanister2Full = true;
        OxygenCanister3Full = true;

        ScrapMetal1Collected = false;
		ScrapMetal2Collected = false;
		ScrapMetal3Collected = false;
		ScrapMetal4Collected = false;
        Battery1Collected = false;
        Battery2Collected = false;
        Battery3Collected = false;
        PasscodeBookCollected = false;
        PowerGenPartsCollected = false;

        Hull1Repaired = false;
		Hull2Repaired = false;
		Hull3Repaired = false;
		Hull4Repaired = false;

        allHolesRepaired = false;
        PowerGenRepaired = false;

        HasTorch = false;
        HasWrench = false;

        ScrapCount = 0;
        BatteryCount = 0;

        OxygenCanisterFullImage1Renderer = OxygenCanisterFullImage1.GetComponent<Renderer>();
        OxygenCanisterFullImage2Renderer = OxygenCanisterFullImage2.GetComponent<Renderer>();
        OxygenCanisterFullImage3Renderer = OxygenCanisterFullImage3.GetComponent<Renderer>();
        ScrapMetal1ImageRenderer = ScrapMetal1Image.GetComponent<Renderer>();
		ScrapMetal2ImageRenderer = ScrapMetal2Image.GetComponent<Renderer>();
		ScrapMetal3ImageRenderer = ScrapMetal3Image.GetComponent<Renderer>();
		ScrapMetal4ImageRenderer = ScrapMetal4Image.GetComponent<Renderer>();
        Battery1ImageRenderer = Battery1Image.GetComponent<Renderer>();
        Battery2ImageRenderer = Battery2Image.GetComponent<Renderer>();
        Battery3ImageRenderer = Battery3Image.GetComponent<Renderer>();
        Hull1RepairedImageRenderer = Hull1RepairedImage.GetComponent<Renderer>();
		Hull2RepairedImageRenderer = Hull2RepairedImage.GetComponent<Renderer>();
		Hull3RepairedImageRenderer = Hull3RepairedImage.GetComponent<Renderer>();
		Hull4RepairedImageRenderer = Hull4RepairedImage.GetComponent<Renderer>();
        TorchImageRenderer = TorchImage.GetComponent<Renderer>();
        WrenchImageRenderer = WrenchImage.GetComponent<Renderer>();
        PasscodeBookImageRenderer = PasscodeBookImage.GetComponent<Renderer>();
        PowerGeneratorBrokenImageRenderer = PowerGeneratorBrokenImage.GetComponent<Renderer>();
        PowerGeneratorImageRenderer = PowerGeneratorImage.GetComponent<Renderer>();

    }

	// Update is called once per frame
	void Update()
    {
        keyPressed = Input.GetButtonDown("Interact");

		if (Hull1Repaired == true && Hull2Repaired && Hull3Repaired && Hull4Repaired)
        {
            allHolesRepaired = true;
        }

        if (BatteryCount == 3 && HasWrench == true
            && PasscodeBookCollected == true)
        {
            PowerGenPartsCollected = true;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag ("OxygenCanister1"))
        {
            if (keyPressed == true && OxygenCanister1Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
                OxygenCanisterFullImage1Renderer.enabled = false;
                OxygenCanister1Full = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("OxygenCanister2"))
        {
            if (keyPressed == true && OxygenCanister2Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
                OxygenCanisterFullImage2Renderer.enabled = false;
                OxygenCanister2Full = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("OxygenCanister3"))
        {
            if (keyPressed == true && OxygenCanister3Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
                OxygenCanisterFullImage3Renderer.enabled = false;
                OxygenCanister3Full = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("ScrapMetal1"))
        {
            if (keyPressed == true && ScrapMetal1Collected == false)
            {
                ScrapCount++;
                ScrapMetal1ImageRenderer.enabled = false;
                ScrapMetal1Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

		else if (other.CompareTag("ScrapMetal2"))
		{
			if (keyPressed == true && ScrapMetal2Collected == false)
			{
				ScrapCount++;
				ScrapMetal2ImageRenderer.enabled = false;
				ScrapMetal2Collected = true;
			}
		}

		else if (other.CompareTag("ScrapMetal3"))
		{
			if (keyPressed == true && ScrapMetal3Collected == false)
			{
				ScrapCount++;
				ScrapMetal3ImageRenderer.enabled = false;
				ScrapMetal3Collected = true;
			}
		}

		else if (other.CompareTag("ScrapMetal4"))
		{
			if (keyPressed == true && ScrapMetal4Collected == false)
			{
				ScrapCount++;
				ScrapMetal4ImageRenderer.enabled = false;
				ScrapMetal4Collected = true;
			}
		}

        else if (other.CompareTag("HullHole1"))
        {
            if (keyPressed == true && ScrapCount >= 1 &&
                HasTorch == true && Hull1Repaired == false)
            {
                ScrapCount--;
                Hull1RepairedImageRenderer.enabled = true;
                Hull1Repaired = true;
                GetComponent<AudioSource>().clip = Clip[1];
                GetComponent<AudioSource>().Play();
            }
        }

		else if (other.CompareTag("HullHole2"))
		{
			if (keyPressed == true && ScrapCount >= 1 &&
				HasTorch == true && Hull2Repaired == false)
			{
				ScrapCount--;
				Hull2RepairedImageRenderer.enabled = true;
				Hull2Repaired = true;
			}
		}

		else if (other.CompareTag("HullHole3"))
		{
			if (keyPressed == true && ScrapCount >= 1 &&
				HasTorch == true && Hull3Repaired == false)
			{
				ScrapCount--;
				Hull3RepairedImageRenderer.enabled = true;
				Hull3Repaired = true;
			}
		}

		else if (other.CompareTag("HullHole4"))
		{
			if (keyPressed == true && ScrapCount >= 1 &&
				HasTorch == true && Hull4Repaired == false)
			{
				ScrapCount--;
				Hull4RepairedImageRenderer.enabled = true;
				Hull4Repaired = true;
			}
		}

        else if (other.CompareTag("WeldingTorch"))
        {
            if(keyPressed == true && HasTorch == false)
            {
                HasTorch = true;
                TorchImageRenderer.enabled = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("Battery1"))
        {
            if (keyPressed == true && Battery1Collected == false
                && allHolesRepaired == true)
            {
                BatteryCount++;
                Battery1ImageRenderer.enabled = false;
                Battery1Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("Battery2"))
        {
            if (keyPressed == true && Battery2Collected == false
                && allHolesRepaired == true)
            {
                BatteryCount++;
                Battery2ImageRenderer.enabled = false;
                Battery2Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("Battery3"))
        {
            if (keyPressed == true && Battery3Collected == false
                && allHolesRepaired == true)
            {
                BatteryCount++;
                Battery3ImageRenderer.enabled = false;
                Battery3Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("Wrench"))
        {
            if (keyPressed == true && HasWrench == false
                && allHolesRepaired == true)
            {
                HasWrench = true;
                WrenchImageRenderer.enabled = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("PasscodeBook"))
        {
            if (keyPressed == true && PasscodeBookCollected == false
                && allHolesRepaired == true)
            {
                PasscodeBookCollected = true;
                PasscodeBookImageRenderer.enabled = false;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("PowerGenerator"))
        {
            if (keyPressed == true && PowerGenPartsCollected == true
                && PowerGenRepaired == false)
            {
                PowerGenRepaired = true;
                BatteryCount -= 3;
                PowerGeneratorImageRenderer.enabled = true;
                PowerGeneratorBrokenImageRenderer.enabled = false;
                GetComponent<AudioSource>().clip = Clip[2];
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Border"))
        {
            GameOverText.text = "Game Over";
            DeathMessageText.text = "You fell into space, doomed to float through the void until you die.";
            oxygenController.enabled = false;
            GetComponent<AudioSource>().clip = Clip[3];
            GetComponent<AudioSource>().Play();
        }
    }
}
