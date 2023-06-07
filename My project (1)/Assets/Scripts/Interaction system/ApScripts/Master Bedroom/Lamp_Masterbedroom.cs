using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Masterbedroom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateLight_MasterBedroom == false)
        {
            moneyCounter.stateLight_MasterBedroom = true;
            moneyCounter.numLight_MasterBedroom = 1;
        }
        else if (moneyCounter.stateLight_MasterBedroom == true)
        {
            moneyCounter.stateLight_MasterBedroom = false;
            moneyCounter.numLight_MasterBedroom = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateLight_MasterBedroom == false)
        {
            moneyCounter.stateLight_MasterBedroom = true;
            moneyCounter.numLight_MasterBedroom = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateLight_MasterBedroom == true && inventory.xRayGoggles == true)
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = true;
        }
        else
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = false;
        }
    }
}
