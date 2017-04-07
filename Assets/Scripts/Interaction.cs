using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public OxygenController oxygenController;

    public GameObject OxygenCanisterFullImage1;
    public GameObject OxygenCanisterFullImage2;
    public GameObject OxygenCanisterFullImage3;
	public GameObject OxygenCanisterFullImage4;
	public GameObject OxygenCanisterFullImage5;
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
	public GameObject TorqueWrenchImage;
	public GameObject NuclearPowerCell;
	public GameObject Piping1Image;
	public GameObject Piping2Image;
	public GameObject Piping3Image;
	public GameObject CO2Converter;
	public GameObject OxygenGeneratorRepairedImage;

	
	public GameObject Door;
	public GameObject Door2;
	public GameObject Door3;
	public GameObject Door4;
	public GameObject Door5;

    public AudioClip[] Clip;

    public Text GameOverText;
    public Text DeathMessageText;

    private bool OxygenCanister1Full;
    private bool OxygenCanister2Full;
    private bool OxygenCanister3Full;
	private bool OxygenCanister4Full;
	private bool OxygenCanister5Full;

	private bool ScrapMetal1Collected;
	private bool ScrapMetal2Collected;
	private bool ScrapMetal3Collected;
	private bool ScrapMetal4Collected;

	public bool Battery1Collected;
	public bool Battery2Collected;
	public bool Battery3Collected;
	public bool PasscodeBookCollected;

	private bool PowerGenPartsCollected;
	private bool OxygenGenPartsCollected;

	private bool Piping1Collected;
	private bool Piping2Collected;
	private bool Piping3Collected;
	public bool CO2ConverterCollected;
	public bool NuclearPowerCellCollected;

    private bool Hull1Repaired;
	private bool Hull2Repaired;
	private bool Hull3Repaired;
	private bool Hull4Repaired;

    public bool allHolesRepaired;
    private bool PowerGenRepaired;
	private bool OxygenGenRepaired;

	private bool Door1Opened;
	private bool Door2Opened;
	private bool Door3Opened;
	private bool Door4Opened;
	private bool Door5Opened;

	public bool HasTorch;
    public bool HasWrench;
	public bool HasTorqueWrench;

	public int ScrapCount;
	public int BatteryCount;
	public int PipingCount;

    private Renderer OxygenCanisterFullImage1Renderer;
    private Renderer OxygenCanisterFullImage2Renderer;
    private Renderer OxygenCanisterFullImage3Renderer;
	private Renderer OxygenCanisterFullImage4Renderer;
	private Renderer OxygenCanisterFullImage5Renderer;
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
	private Renderer TorqueWrenchImageRenderer;
	private Renderer NuclearPowerCellRenderer;
	private Renderer Piping1ImageRenderer;
	private Renderer Piping2ImageRenderer;
	private Renderer Piping3ImageRenderer;
	private Renderer CO2ConverterRenderer;
	private Renderer OxygenGeneratorRepairedImageRenderer;

	private Renderer DoorClosedImageRenderer;
	private Renderer Door2ClosedImageRenderer;
	private Renderer Door3ClosedImageRenderer;
	private Renderer Door4ClosedImageRenderer;
	private Renderer Door5ClosedImageRenderer;

	private Collider DoorCollider;
	private Collider Door2Collider;
	private Collider Door3Collider;
	private Collider Door4Collider;
	private Collider Door5Collider;

    private bool keyPressed;

	// Use this for initialization
	void Start ()
    {
        OxygenCanister1Full = true;
        OxygenCanister2Full = true;
        OxygenCanister3Full = true;
		OxygenCanister4Full = true;
		OxygenCanister5Full = true;

        ScrapMetal1Collected = false;
		ScrapMetal2Collected = false;
		ScrapMetal3Collected = false;
		ScrapMetal4Collected = false;
        Battery1Collected = false;
        Battery2Collected = false;
        Battery3Collected = false;
        PasscodeBookCollected = false;
		Piping1Collected = false;
		Piping2Collected = false;
		Piping3Collected = false;
		CO2ConverterCollected = false;
		NuclearPowerCellCollected = false;
        PowerGenPartsCollected = false;
		OxygenGenPartsCollected = false;

        Hull1Repaired = false;
		Hull2Repaired = false;
		Hull3Repaired = false;
		Hull4Repaired = false;

        allHolesRepaired = false;
        PowerGenRepaired = false;
		OxygenGenRepaired = false;

		Door1Opened = false;
		Door2Opened = false;
		Door3Opened = false;
		Door4Opened = false;
		Door5Opened = false;

        HasTorch = false;
        HasWrench = false;
		HasTorqueWrench = false;

        ScrapCount = 0;
        BatteryCount = 0;
		PipingCount = 0;

        OxygenCanisterFullImage1Renderer = OxygenCanisterFullImage1.GetComponent<Renderer>();
        OxygenCanisterFullImage2Renderer = OxygenCanisterFullImage2.GetComponent<Renderer>();
        OxygenCanisterFullImage3Renderer = OxygenCanisterFullImage3.GetComponent<Renderer>();
		OxygenCanisterFullImage4Renderer = OxygenCanisterFullImage4.GetComponent<Renderer>();
		OxygenCanisterFullImage5Renderer = OxygenCanisterFullImage5.GetComponent<Renderer>();
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
		TorqueWrenchImageRenderer = TorqueWrenchImage.GetComponent<Renderer> ();
		Piping1ImageRenderer = Piping1Image.GetComponent<Renderer> ();
		Piping2ImageRenderer = Piping2Image.GetComponent<Renderer> ();
		Piping3ImageRenderer = Piping3Image.GetComponent<Renderer> ();
		CO2ConverterRenderer = CO2Converter.GetComponent<Renderer> ();
		NuclearPowerCellRenderer = NuclearPowerCell.GetComponent<Renderer> ();
		OxygenGeneratorRepairedImageRenderer = OxygenGeneratorRepairedImage.GetComponent<Renderer> ();
		DoorClosedImageRenderer = Door.GetComponent<Renderer> ();
		Door2ClosedImageRenderer = Door2.GetComponent<Renderer> ();
		Door3ClosedImageRenderer = Door3.GetComponent<Renderer> ();
		Door4ClosedImageRenderer = Door4.GetComponent<Renderer> ();
		Door5ClosedImageRenderer = Door5.GetComponent<Renderer> ();

		DoorCollider = Door.GetComponent<Collider> ();
		Door2Collider = Door2.GetComponent<Collider> ();
		Door3Collider = Door3.GetComponent<Collider> ();
		Door4Collider = Door4.GetComponent<Collider> ();
		Door5Collider = Door5.GetComponent<Collider> ();
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

		if (PipingCount == 3 && NuclearPowerCellCollected == true
		    && CO2ConverterCollected == true && HasTorqueWrench == true) 
		{
			OxygenGenPartsCollected = true;
		}
			
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag ("OxygenCanister1"))
        {
            if (keyPressed == true && OxygenCanister1Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 50;
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

		else if (other.CompareTag("OxygenCanister4"))
		{
			if (keyPressed == true && OxygenCanister4Full == true)
			{
				oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
				OxygenCanisterFullImage4Renderer.enabled = false;
				OxygenCanister4Full = false;
				GetComponent<AudioSource>().clip = Clip[0];
				GetComponent<AudioSource>().Play();
			}
		}

		else if (other.CompareTag("OxygenCanister5"))
		{
			if (keyPressed == true && OxygenCanister5Full == true)
			{
				oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
				OxygenCanisterFullImage5Renderer.enabled = false;
				OxygenCanister5Full = false;
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
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
			}
		}

		else if (other.CompareTag("ScrapMetal3"))
		{
			if (keyPressed == true && ScrapMetal3Collected == false)
			{
				ScrapCount++;
				ScrapMetal3ImageRenderer.enabled = false;
				ScrapMetal3Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
			}
		}

		else if (other.CompareTag("ScrapMetal4"))
		{
			if (keyPressed == true && ScrapMetal4Collected == false)
			{
				ScrapCount++;
				ScrapMetal4ImageRenderer.enabled = false;
				ScrapMetal4Collected = true;
                GetComponent<AudioSource>().clip = Clip[0];
                GetComponent<AudioSource>().Play();
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
                GetComponent<AudioSource>().clip = Clip[1];
                GetComponent<AudioSource>().Play();
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
				GetComponent<AudioSource>().clip = Clip[1];
				GetComponent<AudioSource>().Play();
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
                GetComponent<AudioSource>().clip = Clip[1];
                GetComponent<AudioSource>().Play();
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

		else if (other.CompareTag("Door1"))
		{
			if (keyPressed == true && PowerGenRepaired == true)
			{
				Door1Opened = !Door1Opened;
				if (Door1Opened == true) {
					DoorClosedImageRenderer.enabled = true;
					DoorCollider.enabled = true;
				} 
				else 
				{
					DoorClosedImageRenderer.enabled = false;
					DoorCollider.enabled = false;
				}
			}
		}

		else if (other.CompareTag("Door2"))
		{
			if (keyPressed == true && PowerGenRepaired == true)
			{
				Door2Opened = !Door2Opened;
				if (Door2Opened == true) {
					Door2ClosedImageRenderer.enabled = true;
					Door2Collider.enabled = true;
				} 
				else 
				{
					Door2ClosedImageRenderer.enabled = false;
					Door2Collider.enabled = false;
				}
			}
		}

		else if (other.CompareTag("Door3"))
		{
			if (keyPressed == true && PowerGenRepaired == true)
			{
				Door3Opened = !Door3Opened;
				if (Door3Opened == true) {
					Door3ClosedImageRenderer.enabled = true;
					Door3Collider.enabled = true;
				} 
				else 
				{
					Door3ClosedImageRenderer.enabled = false;
					Door3Collider.enabled = false;
				}
			}
		}

		else if (other.CompareTag("Door4"))
		{
			if (keyPressed == true && PowerGenRepaired == true)
			{
				Door4Opened = !Door4Opened;
				if (Door4Opened == true) {
					Door4ClosedImageRenderer.enabled = true;
					Door4Collider.enabled = true;
				} 
				else 
				{
					Door4ClosedImageRenderer.enabled = false;
					Door4Collider.enabled = false;
				}
			}
		}

		else if (other.CompareTag("Door5"))
		{
			if (keyPressed == true && PowerGenRepaired == true)
			{
				Door5Opened = !Door5Opened;
				if (Door5Opened == true) {
					Door5ClosedImageRenderer.enabled = true;
					Door5Collider.enabled = true;
				} 
				else 
				{
					Door5ClosedImageRenderer.enabled = false;
					Door5Collider.enabled = false;
				}
			}
		}

		else if (other.CompareTag("Piping1") && Piping1Collected == false && PowerGenRepaired == true)
		{
			Piping1Collected = true;
			PipingCount++;
			Piping1ImageRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("Piping2") && Piping2Collected == false && PowerGenRepaired == true)
		{
			Piping2Collected = true;
			PipingCount++;
			Piping2ImageRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("Piping3") && Piping3Collected == false && PowerGenRepaired == true)
		{
			Piping3Collected = true;
			PipingCount++;
			Piping3ImageRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("CO2Converter") && CO2ConverterCollected == false && PowerGenRepaired == true)
		{
			CO2ConverterCollected = true;
			CO2ConverterRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("NuclearPowerCell") && NuclearPowerCellCollected == false && PowerGenRepaired == true)
		{
			NuclearPowerCellCollected = true;
			NuclearPowerCellRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("TorqueWrench") && HasTorqueWrench == false && PowerGenRepaired == true)
		{
			HasTorqueWrench = true;
			TorqueWrenchImageRenderer.enabled = false;
			GetComponent<AudioSource>().clip = Clip[0];
			GetComponent<AudioSource>().Play();
		}

		else if (other.CompareTag("OxygenGenerator") && OxygenGenPartsCollected == true && 
			PowerGenRepaired == true && OxygenGenRepaired == false)
		{
			OxygenGenRepaired = true;
			OxygenGeneratorRepairedImageRenderer.enabled = true;
			GetComponent<AudioSource>().clip = Clip[2];
			GetComponent<AudioSource>().Play();
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
