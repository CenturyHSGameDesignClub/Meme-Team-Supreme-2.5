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
    public GameObject ScrapMetal1Image;
    public GameObject Battery1Image;
    public GameObject Battery2Image;
    public GameObject Battery3Image;
    public GameObject TorchImage;
    public GameObject WrenchImage;
    public GameObject PasscodeBookImage;
    public GameObject PowerGeneratorImage;
    public GameObject PowerGeneratorBrokenImage;

    public Text GameOverText;
    public Text DeathMessageText;

    private bool OxygenCanister1Full;
    private bool OxygenCanister2Full;
    private bool OxygenCanister3Full;

    private bool ScrapMetal1Collected;
    private bool Battery1Collected;
    private bool Battery2Collected;
    private bool Battery3Collected;
    public bool PasscodeBookCollected;
    private bool PowerGenPartsCollected;

    private bool Hull1Repaired;

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
    private Renderer Battery1ImageRenderer;
    private Renderer Battery2ImageRenderer;
    private Renderer Battery3ImageRenderer;
    private Renderer Hull1RepairedImageRenderer;
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
        Battery1Collected = false;
        Battery2Collected = false;
        Battery3Collected = false;
        PasscodeBookCollected = false;
        PowerGenPartsCollected = false;

        Hull1Repaired = false;
        
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
        Battery1ImageRenderer = Battery1Image.GetComponent<Renderer>();
        Battery2ImageRenderer = Battery2Image.GetComponent<Renderer>();
        Battery3ImageRenderer = Battery3Image.GetComponent<Renderer>();
        Hull1RepairedImageRenderer = Hull1RepairedImage.GetComponent<Renderer>();
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

        if (Hull1Repaired == true)
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
            }
        }

        else if (other.CompareTag("OxygenCanister2"))
        {
            if (keyPressed == true && OxygenCanister2Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
                OxygenCanisterFullImage2Renderer.enabled = false;
                OxygenCanister2Full = false;
            }
        }

        else if (other.CompareTag("OxygenCanister3"))
        {
            if (keyPressed == true && OxygenCanister3Full == true)
            {
                oxygenController.OxygenTimer = oxygenController.OxygenTimer + 60;
                OxygenCanisterFullImage3Renderer.enabled = false;
                OxygenCanister3Full = false;
            }
        }

        else if (other.CompareTag("ScrapMetal1"))
        {
            if (keyPressed == true && ScrapMetal1Collected == false)
            {
                ScrapCount++;
                ScrapMetal1ImageRenderer.enabled = false;
                ScrapMetal1Collected = false;
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
            }
        }

        else if (other.CompareTag("WeldingTorch"))
        {
            if(keyPressed == true && HasTorch == false)
            {
                HasTorch = true;
                TorchImageRenderer.enabled = false;
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
            }
        }

        else if (other.CompareTag("Wrench"))
        {
            if (keyPressed == true && HasWrench == false 
                && allHolesRepaired == true)
            {
                HasWrench = true;
                WrenchImageRenderer.enabled = false;
            }
        }

        else if (other.CompareTag("PasscodeBook"))
        {
            if (keyPressed == true && PasscodeBookCollected == false 
                && allHolesRepaired == true)
            {
                PasscodeBookCollected = true;
                PasscodeBookImageRenderer.enabled = false;
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
        }
    }
}
